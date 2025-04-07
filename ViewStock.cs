using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeapplianceShop
{
    public partial class ViewStock : Form
    {
        public ViewStock()
        {
            InitializeComponent();
        }
        Operations Op = new Operations();
        string myquery;

        private void GetProduct()
        {
            myquery = "select * from ProductTbl";
            var ds = Op.populate(myquery);
            ProductDGV.DataSource = ds.Tables[0];
        }
        private void ViewStock_Load(object sender, EventArgs e)
        {
            GetProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                myquery = "Delete from ProductTbl where ID=" + ProdIdTb.Text + ";";
                Op.deleteProd(myquery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ProdIdTb.Text = ProductDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdNameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdBrandCb.SelectedItem = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdCatCb.SelectedItem = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            ProdQtyTb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            ProdPriceCb.Text = ProductDGV.SelectedRows[0].Cells[5].Value.ToString();
        }
        private void clear()
        {
            ProdIdTb.Text = "";
            ProdNameTb.Text = "";
            ProdCatCb.SelectedIndex = -1;
            ProdBrandCb.SelectedIndex = -1;
            ProdQtyTb.Text = "";
            ProdPriceCb.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {


                myquery = "update ProductTbl set ProductName='" + ProdNameTb.Text + "',ProdBrand='" + ProdBrandCb.SelectedItem.ToString() + "',ProdCat='" + ProdCatCb.SelectedItem.ToString() + "',ProdQty=" + ProdQtyTb.Text + ",ProdPrice=" + ProdPriceCb.Text + " where ID=" + ProdIdTb.Text + ";";
                Op.Editdata(myquery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm menu = new MainForm();
            menu.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            (ProductDGV.DataSource as DataTable).DefaultView.RowFilter =
                  string.Format("ProductName like '%" + keywordTextBox.Text + "%'");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserManual User = new UserManual();
            User.Show();
            this.Hide();
        }
    }
}