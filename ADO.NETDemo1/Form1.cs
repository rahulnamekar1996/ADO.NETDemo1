using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ADO.NETDemo1
{
    public partial class Form1 : Form
    {
        ProductCrud crud;
        List<Category> list;

        public Form1()
        {
            InitializeComponent();
            crud = new ProductCrud();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                list = crud.GetCategories();
                 cmbcategory.DataSource = list;
                cmbcategory.DisplayMember = "Cname";
                cmbcategory.ValueMember = "Cid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.Name = txtpname.Text;
                p.Price = Convert.ToInt32(txtpprice.Text);
                p.Cid = Convert.ToInt32(txtpid.SelectedValue);
                int res = crud.AddProduct(p);
                if (res > 0)
                {
                    MessageBox.Show("Record inserted..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }
}
