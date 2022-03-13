using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsFormsApp
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            errCustForm.SetError(textBox1, "");
            errCustForm.SetError(textBox5, "");
            errCustForm.SetError(textBox3, "");
            errCustForm.SetError(textBox4, "");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag=true;
            if(textBox1.Text=="")
            {
                errCustForm.SetError(textBox1, "Please Specify a Valid Car Number.");
                    flag=false;
            }
            else
            {
                errCustForm.SetError(textBox1, "");
            }
            if (textBox3.Text == "")
            {
                errCustForm.SetError(textBox3, "Please Specify a Valid Make.");
                      flag = false;
            }
            else
            {
                errCustForm.SetError(textBox3, "");
            }
            if (textBox5.Text == "")
            {
                errCustForm.SetError(textBox5, "Please Specify a Valid Address.");
                      flag = false;
            }
            else
            {
                errCustForm.SetError(textBox5, "");
            }
            if (textBox4.Text == "")
            {
                errCustForm.SetError(textBox4, "Please Specify a Valid Name.");
                      flag = false;
            }
            else
            {
                errCustForm.SetError(textBox4, "");
            }
            if (flag == false)
                return;
            else
            {
                //database code
                sqlDataAdapter1.Update(customerDataSet1);
                MessageBox.Show("Database Updated");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            customerDataSet1.Clear();
            sqlDataAdapter1.Fill(customerDataSet1);
            CurrentPosition();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.BindingContext[customerDataSet1, "tblCustomer"].Position += 1;
            CurrentPosition();
        }
        private void CurrentPosition()
        {
            int currentPosition, ctr;
            ctr = this.BindingContext[customerDataSet1, "tblCustomer"].Count;
            if(ctr == 0)
            {
                textBox2.Text = "No records";
            }
            else
            {
                currentPosition = this.BindingContext[customerDataSet1, "tblCustomer"].Position + 1;
                textBox2.Text = currentPosition.ToString()+"of"+ctr.ToString();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            btnPrevious.BindingContext[customerDataSet1, "tblCustomer"].Position -= 1;
            CurrentPosition();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            customerDataSet1.Clear();
        }
    }
}
