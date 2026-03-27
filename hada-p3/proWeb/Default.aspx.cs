using System;
using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var categorias = ENCategory.ReadAll();

                    DropDownList1.DataSource = categorias;
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();

                    ClearForm();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error cargando categorías";
                    Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                }
            }
        }

        // Ponemos los valores de los campos vacios
        private void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            DropDownList1.SelectedIndex = 0;
            lblMessage.Text = "";
        }

        private void ShowMessage(string text, bool isError)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private bool ValidateInputs(out int amount, out float price)
        {
            amount = 0;
            price = 0;

            if (!int.TryParse(TextBox3.Text, out amount))
            {
                ShowMessage("Cantidad invalida", true);
                return false;
            }

            if (!float.TryParse(TextBox4.Text, out price))
            {
                ShowMessage("Precio invalido", true);
                return false;
            }

            return true;
        }

        private ENProduct GetProductFromForm()
        {
            return new ENProduct(
                TextBox1.Text.Trim(),
                TextBox2.Text.Trim(),
                int.Parse(TextBox3.Text),
                float.Parse(TextBox4.Text),
                int.Parse(DropDownList1.SelectedValue),
                DateTime.Parse(TextBox5.Text)
            );
        }

        // Almacenamos los valores de los campos en los atributos
        private void FillForm(ENProduct p)
        {
            TextBox1.Text = p.code;
            TextBox2.Text = p.name;
            TextBox3.Text = p.amount.ToString();
            TextBox4.Text = p.price.ToString();
            DropDownList1.SelectedValue = p.category.ToString();
            TextBox5.Text = p.creationDate.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Evento para crear un nuevo producto
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (prod.Read())
                {
                    ShowMessage("El producto ya existe", true);
                    return;
                }

                if (!ValidateInputs(out int amount, out float price)) return;

                prod.name = TextBox2.Text.Trim();
                prod.amount = amount;
                prod.price = price;
                prod.category = int.Parse(DropDownList1.SelectedValue);
                prod.creationDate = DateTime.Now;

                if (prod.Create())
                {
                    TextBox5.Text = prod.creationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ShowMessage("Producto creado", false);
                }
                else
                {
                    ShowMessage("Error al crear el producto", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al crear el producto", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para leer los productos
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (prod.Read())
                {
                    FillForm(prod);
                    ShowMessage("Producto no encontrado", false);
                }
                else
                {
                    ShowMessage("Producto no encontrado.", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al leer el producto", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para actualizar los productos
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (!prod.Read())
                {
                    ShowMessage("Producto no encontrado", true);
                    return;
                }

                if (!ValidateInputs(out int amount, out float price)) return;

                prod.name = TextBox2.Text.Trim();
                prod.amount = amount;
                prod.price = price;
                prod.category = int.Parse(DropDownList1.SelectedValue);

                if (prod.Update())
                {
                    ShowMessage("Producto actualizado", false);
                }
                else
                {
                    ShowMessage("Error al actualizar el producto", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al actualizar el producto", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para eliminar un producto
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (prod.Delete())
                {
                    ClearForm();
                    ShowMessage("Producto eliminado", false);
                }
                else
                {
                    ShowMessage("Producto no enconrtado", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error al eliminar el producto", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para leer el producto primero
        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct();

                if (prod.ReadFirst())
                {
                    FillForm(prod);
                    ShowMessage("Cargado el primer producto", false);
                }
                else
                {
                    ShowMessage("No hay productos.", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error.", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para ver el producto siguiente
        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (prod.ReadNext())
                {
                    FillForm(prod);
                }
                else
                {
                    ShowMessage("No existe el otro producto.", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error.", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }

        // Evento para ver el producto anterior
        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = TextBox1.Text.Trim() };

                if (prod.ReadPrev())
                {
                    FillForm(prod);
                }
                else
                {
                    ShowMessage("No hay otro producto anterior", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error.", true);
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
    }
}