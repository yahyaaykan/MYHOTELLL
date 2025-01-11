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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\\YAHYA\OneDrive\Belgeler\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        private Bunifu.UI.WinForms.BunifuDataGridView GetRoomsDGV()
        {
            return UserDGV;
        }

        private void populate()
        {

            Con.Open();
            string Query = "select * from UserTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
            populate();
        }
        private void EditUsers()
        {
            if (UnameTb.Text == "" || GenderCb.SelectedIndex == -1 || PasswordTb.Text == "" || UPhoneTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update UserTb1 set UName=@UN,Uphone=@UP,UGender=@UG,Upassword=@UPa where UNum=@UKey ", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", UPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UPa", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Uptated !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void DeleteUsers()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a User !!! ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from UserTb1 where Unum = @UKey", Con);
                    cmd.Parameters.AddWithValue("UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted !!! ");
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

        private void InsertUsers()
        {
            if (UnameTb.Text == "" || GenderCb.SelectedIndex == -1 || PasswordTb.Text == "" || UPhoneTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTb1(UName,Uphone,UGender,Upassword) values(@UN,@UP,@UG,@UPa)", Con);
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", UPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UG", GenderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@UPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Added !!!");
                    Con.Close();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertUsers();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteUsers();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditUsers();
        }
        int Key = 0;
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            UPhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();
            PasswordTb.Text = UserDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (UnameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
