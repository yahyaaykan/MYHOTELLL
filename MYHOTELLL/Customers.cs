using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MYHOTELLL
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\\YAHYA\OneDrive\Belgeler\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        private Bunifu.UI.WinForms.BunifuDataGridView GetRoomsDGV()
        {
            return CustomersDGV;
        }

        private void populate()
        {

            Con.Open();
            string Query = "select * from CustomerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            Con.Close();
            populate();
        }
        private void EditCustomers()
        {
            if (CNameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTb1 set CName=@CN , CustPhone=@CP , CustGender= @CG where CustNum=CKey", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Uptaded !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void DeleteCustomer()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Room !!! ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CustomerTb1 where CustNum = @CKey", Con);
                    cmd.Parameters.AddWithValue("CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted !!! ");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    throw;
                }
            }
        }

        private void InsertCustomer()
        {
            if (CNameTb.Text == "" || GenderCb.SelectedIndex == -1 || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTb1(CName,CustPhone,CustGender) values(@CN,@CP,@CG)", Con);
                    cmd.Parameters.AddWithValue("@CN", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@CP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CG", GenderCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Added !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditCustomers();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCustomer();
        }
        int Key = 0;
        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text =  CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (CNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }
    }
}
