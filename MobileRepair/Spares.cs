using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileRepair
{
    public partial class Spares : Form
    {
        Functions Con;
        public Spares()
        {
            InitializeComponent();
            Con = new Functions();
            ShowSpares();
        }

        private void ShowSpares()
        {
            string Query = "select * from SpareTbl";
            PartsList.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            PartNameTb.Text = "";
            PartCostTb.Text = "";
            key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "" )
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string Pname = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "insert into SpareTbl values('{0}','{1}')";
                    Query = string.Format(Query, Pname, Cost);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Addded !");
                    ShowSpares();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;    
        private void PartsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PartNameTb.Text = PartsList.SelectedRows[0].Cells[1].Value.ToString();
            PartCostTb.Text = PartsList.SelectedRows[0].Cells[2].Value.ToString();
            if (PartNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PartsList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PartNameTb.Text == "" || PartCostTb.Text == "")
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "update SpareTbl set SpName = '{0}',SpCost = {1} where SpCode = {2}";
                    Query = string.Format(Query, PName, Cost,key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Updated !");
                    ShowSpares();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string PName = PartNameTb.Text;
                    int Cost = Convert.ToInt32(PartCostTb.Text);
                    String Query = "delete from SpareTbl where SpCode = {0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Spare Deleted !");
                    ShowSpares();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login(); 
            Obj.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
          Customers Obj = new Customers();
          Obj.Show();
          this.Hide();
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repairs Obj = new Repairs();
            Obj.Show();
            this.Hide();
        }
    }
}
