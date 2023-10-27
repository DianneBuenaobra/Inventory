using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private int _Quantity;
        private double _SellingPrice;
        private string _ProductName, _Category, _MfgDate
            , _ExpDate, _Description;
        BindingSource showProductList;
       
        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }
        public class NumberFormatException : Exception
        {
            public NumberFormatException(string numformat) : base(numformat) { }
        }
        public class StringFormatException : Exception
        {
            public StringFormatException(string stringformat) : base(stringformat) { }
        }
        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string conformat) : base(conformat) { }
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = {"Beverages", "Bread/Bakery",
            "Canned/Jarred Goods","Dairy","Frozen Goods","Meat","Personal Care",
            "Other"};

            foreach(string cat in ListOfProductCategory)
            {
                cbCategory.Items.Add(cat);
            }
        }
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new StringFormatException(name);
                return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                throw new NumberFormatException(qty);
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                throw new CurrencyFormatException(price);
                return Convert.ToDouble(price);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMjgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellingPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category
                    , _MfgDate, _ExpDate, _SellingPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;

            }
            catch (NumberFormatException numE)
            {
                MessageBox.Show("Invalid format for Quantity.(" + numE.Message+")","Exception Handling",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (StringFormatException strE)
            {
                MessageBox.Show("Invalid format for Product name.(" + strE.Message+")", "Exception Handling",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(CurrencyFormatException conE)
            {
                MessageBox.Show("Invalid format for Selling Price.(" + conE.Message+")", "Exception Handling",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtProductName.Clear();txtQuantity.Clear();txtSellPrice.Clear();richTxtDescription.Clear();
                cbCategory.Text = "";
            }
        }
    }
}
