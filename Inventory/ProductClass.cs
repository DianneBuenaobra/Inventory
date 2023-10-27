using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class ProductClass
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _ManufacturingDate
            , _ExpirationDate, _Description;


        public ProductClass(string Productname, string cat, string mfgDate,
            string ExpDate, double price, int qty, string desc)
        {
            this._Category = cat; this._Description = desc;
            this._Quantity = qty;
            this._SellingPrice = price;
            this._ProductName = Productname;
            this._ManufacturingDate = mfgDate; this._ExpirationDate = ExpDate;
        }

        public string productName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        public string category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public string manufacturingDate
        {
            get { return _ManufacturingDate; }
            set { _ManufacturingDate = value; }
        }
        public string expirationDate
        {
            get { return _ExpirationDate; }
            set { _ExpirationDate = value; }
        }
        public string description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double sellingPrice
        {
            get { return _SellingPrice;  }
            set { _SellingPrice = value; }
        }
    }
}
