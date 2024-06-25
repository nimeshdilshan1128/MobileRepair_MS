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
    public partial class Customers : Form
    {
        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            string Query = "select * from CustomerTbl";
            CustomersList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string Cname = CustNameTb.Text;
                    string Cphone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                    String Query = "insert into CustomerTbl values('{0}','{1}','{2}')";
                    Query = string.Format(Query, Cname, Cphone, CAdd);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Added !");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data !");
            }
            else
            {
                try
                {
                    string Cname = CustNameTb.Text;
                    string Cphone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                    String Query = "update CustomerTbl set CustName = '{0}',CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3}";
                    Query = string.Format(Query, Cname, Cphone, CAdd,key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Updated !");
                    ShowCustomers();
                    Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Clear()
        {
            CustNameTb.Text = "";
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";
            key = 0;

        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("select a customer !");
            }
            else
            {
                try
                {
           
                    String Query = "delete from CustomerTbl where CustCode= {0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    MessageBox.Show("Customer Deleted !");
                    ShowCustomers();
                    Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        int key = 0;
        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustomersList.SelectedRows[0].Cells[1].Value.ToString();
            CustPhoneTb.Text = CustomersList.SelectedRows[0].Cells[2].Value.ToString();
            CustAddTb.Text = CustomersList.SelectedRows[0].Cells[3].Value.ToString();
            if(CustNameTb.Text == "")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(CustomersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repairs Obj = new Repairs();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }
    }

}

