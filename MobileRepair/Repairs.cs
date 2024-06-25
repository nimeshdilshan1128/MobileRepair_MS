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
    public partial class Repairs : Form
    {
        Functions Con;
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomer();
            GetSpare();
        }
        private void GetCost() 
        {
            string Query = "select * from SpareTbl where SpCode = {0}";
            Query = string.Format(Query, SpareCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();
            }
            //MessageBox.Show("Hello");
        }

        private void GetCustomer() 
        {
            string Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);

        }

        private void GetSpare()
        {
            string Query = "Select * from SpareTbl";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);

        }

        private void ShowRepairs()
        {
            string Query = "select * from RepairTbl";
            RepairsList.DataSource= Con.GetData(Query);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || PhoneTb.Text == "" || DNameTb.Text == "" || ModelTb.Text == "" || ProblemTb.Text == "" || SpareCb.SelectedIndex == -1 || SpareCostTb.Text == "" || TotalTb.Text == "" )
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString("yyyy-MM-dd");
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string Cphone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModel = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
                    String Query = "insert into RepairTbl values('{0}',{1},'{2}','{3}','{4}','{5}',{6},'{7}')";
                    Query = string.Format(Query, RDate ,Customer, Cphone, DeviceName ,DeviceModel, Problem ,Spare,GrdTotal);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Added !");
                    ShowRepairs();
                    //Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SpareCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();  
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select for Delete !");
            }
            else
            {
                try
                {
                   
                    String Query = "Delete from RepairTbl where RepCode = {0} " ;
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Deleted !");
                    ShowRepairs();
                    //Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0; 
        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(RepairsList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repairs Obj = new Repairs();
            Obj.Show();
            this.Hide();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
