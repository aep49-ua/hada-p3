using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";


        public CADProduct()
        {


            SqlConnection conexion = new SqlConnection(constring);


        }


        public bool Create(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);

            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("INSERT INTO Products(name, code, amount, price, category, creationDate, code) VALUES(@name, @code, @amount, @price, @category, @creationDate)", conexion);

                com.Parameters.AddWithValue("@name", en.name);
                com.Parameters.AddWithValue("@code", en.code);
                com.Parameters.AddWithValue("@amount", en.amount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);

                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Update(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("UPDATE Products SET name=@name, code=@code, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code", conexion);

                com.Parameters.AddWithValue("@name", en.name);
                com.Parameters.AddWithValue("@code", en.code);
                com.Parameters.AddWithValue("@amount", en.amount);
                com.Parameters.AddWithValue("@price", en.price);
                com.Parameters.AddWithValue("@category", en.category);
                com.Parameters.AddWithValue("@creationDate", en.creationDate);



                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Delete(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("DELETE FROM Products WHERE code=@code", conexion);

                com.Parameters.AddWithValue("@code", en.code);



                return com.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool Read(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE code@code", conexion);

                com.Parameters.AddWithValue("@code", en.code);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = dat["code"].ToString();
                    en.amount = int.Parse(dat["amount"].ToString());
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = int.Parse(dat["category"].ToString());
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool ReadFirst(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products", conexion);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = dat["code"].ToString();
                    en.amount = int.Parse(dat["amount"].ToString());
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = int.Parse(dat["category"].ToString());
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool ReadNext(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE code>@code ORDER BY code ASC", conexion);
                com.Parameters.AddWithValue("@code", en.code);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = dat["code"].ToString();
                    en.amount = int.Parse(dat["amount"].ToString());
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = int.Parse(dat["category"].ToString());
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
        public bool ReadPrev(ENProduct en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("Select * FROM Products WHERE code<@code ORDER BY code DESC", conexion);
                com.Parameters.AddWithValue("@code", en.code);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.name = dat["name"].ToString();
                    en.code = dat["code"].ToString();
                    en.amount = int.Parse(dat["amount"].ToString());
                    en.price = float.Parse(dat["price"].ToString());
                    en.category = int.Parse(dat["category"].ToString());
                    en.creationDate = DateTime.Parse(dat["creationDate"].ToString());

                    dat.Close();

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: ", e.Message);

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
