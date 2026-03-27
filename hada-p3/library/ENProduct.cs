using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        // Declaramos los atributos privados de la clase ENProduct
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        // Definimos los getters y setter para los atributos de la clase
        public string code { get => _code; set => _code = value; }
        public string name { get => _name; set => _name = value; }
        public int amount { get => _amount; set => _amount = value; }
        public float price { get => _price; set => _price = value; }
        public int category { get => _category; set => _category = value; }
        public DateTime creationDate { get => _creationDate; set => _creationDate = value; }




        // Constructor por defecto        
        public ENProduct()
        {
            _code = "";
            _name = "";
            _amount = 0;
            _price = 0;
            _category = 0;
            _creationDate = DateTime.Now;

        }

        // Constructor de copia
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this._code = code;
            this._name = name;
            this._amount = amount;
            this._price = price;
            this._category = category;
            this._creationDate = creationDate;
        }

        // Método público para guardar un producto en la BD
        public bool Create()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.Create(this);
        }

        // Método público para actualizar un producto en la BD
        public bool Update()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.Update(this);

        }

        // Método público para eliminar un producto en la BD
        public bool Delete()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.Delete(this);
        }

        // Método público para leer un producto en la BD
        public bool Read()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.Read(this);
        }

        // Método público que devuelve el primer producto de la BD 
        public bool ReadFirst()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.ReadFirst(this);
        }

        // Método públic que devuelve el siguiente producto de la BD
        public bool ReadNext()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.ReadNext(this);
        }

        // Método público que devuelve el producto anterior de la BD
        public bool ReadPrev()
        {
            CADProduct newProduct = new CADProduct();
            return newProduct.ReadPrev(this);
        }
    }
}
