using Newtonsoft.Json.Bson;
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
    public partial class Types : Form
    {
        public Types()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\\Users\\YAHYA\\OneDrive\\Belgeler\\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True;Context Connection=False");
       private void populate()
        {
            Con.Open();
            string Query = "select ' from TypeTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder =new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TypesDGV.DataSource = ds.Tables[0];
            Con.Close();
            populate();
        }
        private void DeleteCategories()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Catagory !!! ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from TypeTb1 where Typenum = @TKey", Con);
                    cmd.Parameters.AddWithValue("TKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cattagory Deleted !!! ");
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
        private void InsertCatagories()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TypeTb1(TypeName,TypeCost)values(@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    cmd.Parameters.AddWithValue("@TC", CostTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Inserted !!!");
                    Con.Close();
                    populate() ;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            InsertCatagories();
        }
        private void EditCatagories()
        {
            if (TypeNameTb.Text == "" || CostTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update TypeTb1 set TypeName=@TN,TypeCost=@TC where TypeNum = Tkey", Con);
                    cmd.Parameters.AddWithValue("@TN", TypeNameTb.Text);
                    cmd.Parameters.AddWithValue("@TC", CostTb.Text);
                    cmd.Parameters.AddWithValue("@TKey", Key );
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Uptated !!!");
                    Con.Close();
                    populate();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            EditCatagories();
        }
        int Key = 0;
        private void TypesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TypeNameTb.Text = TypesDGV.SelectedRows[0].Cells[1].Value.ToString();
            CostTb.Text = TypesDGV.SelectedRows[0].Cells[2].Value.ToString();
                if (TypeNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TypesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteCategories();
        }
    }
}
