using library;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                ClearForm();
            }
        }

        private void LoadCategories()
        {
            try
            {
                ENCategory categoryEN = new ENCategory();
                List<ENCategory> categories = ENCategory.ReadAll();

                DropDownList1.Items.Clear();
                DropDownList1.Items.Add(new ListItem("-- Select Category --", "-1"));

                foreach (ENCategory cat in categories)
                {
                    DropDownList1.Items.Add(new ListItem(cat.name, cat.id.ToString()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar las categorias: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            Label1.Text = string.Empty;
            Label2.Text = string.Empty;
            Label3.Text = string.Empty;
            Label4.Text = string.Empty;
            Label5.Text = string.Empty;
            Label6.SelectedIndex = 0;
            //lblMessage.Text = string.Empty;
        }

        private void ShowMessage(string text, bool isError)
        {
            lblMessage.Text = text;
            lblMessage.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            if (isError) Console.WriteLine("Product operation has failed. Error: {0}", text);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = Label1.Text.Trim() };
                if (prod.read())
                {
                    ShowMessage("El producto ya existe.", true);
                    return;
                }

                prod.name = Label1.Text.Trim();
                prod.amount = int.Parse(Label2.Text);
                prod.price = float.Parse(Label3.Text);
                prod.category = int.Parse(DropDownList1.SelectedValue);
                prod.date = DateTime.Now;

                if (prod.create())
                {
                    ShowMessage("Product created successfully.", false);
                    txtCreationDate.Text = prod.date.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = Label1.Text.Trim() };
                if (prod.read())
                {
                    DisplayProduct(prod);
                    ShowMessage("Product found successfully.", false);
                }
                else ShowMessage("Product not found.", true);
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // REQUISITO: Comprobar si existe antes de actualizar
                ENProduct prod = new ENProduct { code = Label1.Text.Trim() };
                if (!prod.read())
                {
                    ShowMessage("Product not found. Cannot update.", true);
                    return;
                }

                prod.name = Label2.Text.Trim();
                prod.amount = int.Parse(Label3.Text);
                prod.price = float.Parse(txtPrice.Text);
                prod.category = int.Parse(ddlCategory.SelectedValue);

                if (prod.update()) ShowMessage("Product updated successfully.", false);
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = txtCode.Text.Trim() };
                if (prod.delete())
                {
                    ClearForm();
                    ShowMessage("Product deleted successfully.", false);
                }
                else ShowMessage("Product not found or could not be deleted.", true);
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct();
                if (prod.readFirst())
                {
                    DisplayProduct(prod);
                    ShowMessage("First product loaded.", false);
                }
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = txtCode.Text.Trim() };
                if (prod.readNext()) DisplayProduct(prod);
                else ShowMessage("No next product found.", true);
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct prod = new ENProduct { code = txtCode.Text.Trim() };
                if (prod.readPrev()) DisplayProduct(prod);
                else ShowMessage("No previous product found.", true);
            }
            catch (Exception ex) { ShowMessage(ex.Message, true); }
        }

        private void DisplayProduct(ENProduct product)
        {
            txtCode.Text = product.code;
            txtName.Text = product.name;
            txtAmount.Text = product.amount.ToString();
            txtPrice.Text = product.price.ToString();
            txtCreationDate.Text = product.date.ToString("dd/MM/yyyy HH:mm:ss");
            ddlCategory.SelectedValue = product.category.ToString();
        }
    }
}