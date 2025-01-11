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
    public partial class Bookings : Form
    {
        public Bookings()
        {
            InitializeComponent();
            populate();
            GetRooms();
            GetCustomers();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\\YAHYA\OneDrive\Belgeler\HotelDbase.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");

        private Bunifu.UI.WinForms.BunifuDataGridView GetRoomsDGV()
        {
            return BookingDGV;
        }

        private void populate()
        {

            Con.Open();
            string Query = "select * from BookingTb1";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
            populate();
        }

        private void GetRooms()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from RoomTb1 where Rstatus = 'Available'", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RNum", typeof(int));
            dt.Load(rdr);
            RoomCb.ValueMember = "RNum";
            RoomCb.DataSource = dt;
            Con.Close();
        }
        private void GetCustomers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from CustomerTb1", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustNum", typeof(int));
            dt.Load(rdr);
            CustomerCb.ValueMember = "CustNum";
            CustomerCb.DataSource = dt;
            Con.Close();
        }
        int Price = 1;
        private void fetchCost()
        {
            Con.Open();
            string Query = "select TypeCost from RoomTb1 join TypeTb1 on RType=TypeNum where Rnum=" + RoomCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Price = Convert.ToInt32(dr["TypeCost"].ToString());
            }
            Con.Close();
        }

        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCb.SelectedIndex == -1 || RoomCb.SelectedIndex == -1 || AmountTb.Text == "" || DurationTb.Text == "")
            {
                MessageBox.Show("Missing İnformation !!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BookingTb1(Room,Customer,BookDate,Duration,Cost) values(@R,@C,@BD,@Dura,@Cost)", Con);
                    cmd.Parameters.AddWithValue("@C", RoomCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@C", CustomerCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BD", BDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Dura", DurationTb.Text);
                    cmd.Parameters.AddWithValue("@Cost", AmountTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Booked !!!");
                    Con.Close();
                    populate();
                    setBooked();
                    GetRooms();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void RoomCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCost();
        }

        private void DurationTb_TextChanged(object sender, EventArgs e)
        {
            if (AmountTb.Text == "")
            {
                AmountTb.Text = "Rs 0";
            }
            else
            {
                try
                {
                    int Total = Price * Convert.ToInt32(DurationTb.Text);
                    AmountTb.Text = "" + Total;
                }
                catch (Exception Ex)
                {


                }
            }
        }
        int Key = 0;
        private void CancelBooking()
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Booking !!! ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from BookingTb1 where BookNum = @BKey", Con);
                    cmd.Parameters.AddWithValue("BKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Booking Canceled !!! ");
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CancelBooking();
            setaAvailable();
            GetRooms();
        }
        private void setBooked()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update RoomTb1 set RStatus=@RS where Rnum = @RKey", Con);
                cmd.Parameters.AddWithValue("@RS", "Booked");
                cmd.Parameters.AddWithValue("@RKey", RoomCb.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated !!!");
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setaAvailable()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("update RoomTb1 set RStatus=@RS where Rnum = @RKey", Con);
                cmd.Parameters.AddWithValue("@RS", "Available");
                cmd.Parameters.AddWithValue("@RKey", RoomCb.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Updated !!!");
                Con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BookingDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RoomCb.Text = BookingDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustomerCb.Text = BookingDGV.SelectedRows[0].Cells[2].Value.ToString();
            BDate.Text = BookingDGV.SelectedRows[0].Cells[3].Value.ToString();
            DurationTb.Text = BookingDGV.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = BookingDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (AmountTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BookingDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
