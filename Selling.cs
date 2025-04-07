using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeapplianceShop
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        Operations Op = new Operations();
        private void GetProduct()
        {
            string myquery = "select * from ProductTbl";
            var ds = Op.populate(myquery);
            ProductDGV.DataSource = ds.Tables[0];
        }
        private void Selling_Load(object sender, EventArgs e)
        {
            GetProduct();
        }
        int oldQty = 0,Pid,newQty;
        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdNameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            //ProdQtyTb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
            ProdPriceTb.Text = ProductDGV.SelectedRows[0].Cells[5].Value.ToString();
            oldQty = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[4].Value.ToString());
            Pid = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        int GrdTotal = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            if(ProdQtyTb.Text == "" || Convert.ToInt32(ProdQtyTb.Text) > oldQty)
            {
                MessageBox.Show("Not Enough Stock");
            }
            else
            {
                int total = Convert.ToInt32(ProdQtyTb.Text) * Convert.ToInt32(ProdPriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);

                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProdNameTb.Text;
                newRow.Cells[2].Value = ProdQtyTb.Text;
                newRow.Cells[3].Value = ProdPriceTb.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                Amttbl.Text = "" + GrdTotal;
            }
            newQty = oldQty - Convert.ToInt32(ProdQtyTb.Text);
            string myquery = "update ProductTbl set ProdQty=" + newQty + " where ID=" + Pid + ";";
            Op.Editdata(myquery);
            GetProduct();
        }
    }
}
