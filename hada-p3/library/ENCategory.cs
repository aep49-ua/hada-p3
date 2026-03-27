using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        // Definimos los atributos de la clase ENCategory
        private int _id;
        private string _name;

        // Declaramos los getters y setters de los atributos de la clase
        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }



        // Constructor por defectos
        public ENCategory()
        {
            _id = 0;
            _name = "";
        }

        // Constructor de copia
        public ENCategory(int id, string name)
        {
            _id = id;
            _name = name;
        }

        // Método público para leer la categoria de la BD
        public bool Read()
        {
            CADCategory newCategory = new CADCategory();
            return newCategory.Read(this);
        }

        // Método público para leer todas las categorias de la BD
        public static List<ENCategory> ReadAll()
        {
            CADCategory newCategory = new CADCategory();
            return newCategory.ReadAll();
        }
    }
}
