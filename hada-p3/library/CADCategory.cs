using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {

            constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";

        }

        public bool Read(ENCategory en)
        {
            SqlConnection conexion = new SqlConnection(constring);
            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM Categories WHERE id=@id", conexion);
                com.Parameters.AddWithValue("@id", en.id);

                SqlDataReader dat = com.ExecuteReader();

                if (dat.Read())
                {
                    en.id = int.Parse(dat["id"].ToString());
                    en.name = dat["name"].ToString();

                    dat.Close();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<ENCategory> ReadAll()
        {
            SqlConnection conexion = new SqlConnection(constring);
            List<ENCategory> listaCategorias = new List<ENCategory>();

            try
            {
                conexion.Open();

                SqlCommand com = new SqlCommand("SELECT * FROM Categories", conexion);
                SqlDataReader dat = com.ExecuteReader();

                while (dat.Read())
                {
                    ENCategory cat = new ENCategory();
                    cat.id = int.Parse(dat["id"].ToString());
                    cat.name = dat["name"].ToString();

                    listaCategorias.Add(cat);
                }

                dat.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conexion.Close();

            }

            return listaCategorias;
        }
    }
}
