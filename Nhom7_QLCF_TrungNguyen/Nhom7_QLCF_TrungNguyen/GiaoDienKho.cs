using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Giaodiendangnhap
{
    public partial class GiaoDienKho : Form
    {
        public GiaoDienKho()
        {
            InitializeComponent();
            cboDVT.Items.Add("Kg");
            cboDVT.Items.Add("Lon");
            cboDVT.Items.Add("Hủ");
            cboDVT.Items.Add("g");
            cboDVT.Items.Add("Gói");
            cboDVT.Items.Add("Chai");
            cboDVT.Items.Add("Hộp");
        }

        string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCOFFEE_TRUNGNGUYEN;Integrated Security=True";
        string sql;
        SqlConnection connection;
        SqlDataReader reader;
        SqlCommand command;

        int i = 0;

        public void hienthi()
        {
            listView1.Items.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                {
                    connection.Open();
                    sql = @"Select MaSP, TenSP, DVT, SltonKho, CLSP FROM QuanLyKho";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            i = 0;
                            while (reader.Read())
                            {
                                listView1.Items.Add(reader[0].ToString());
                                listView1.Items[i].SubItems.Add(reader[1].ToString());
                                listView1.Items[i].SubItems.Add(reader[2].ToString());
                                listView1.Items[i].SubItems.Add(reader[3].ToString());
                                listView1.Items[i].SubItems.Add(reader[4].ToString());
                                i++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void GiaoDienKho_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(chuoiketnoi);
            listView1.Items.Clear();

        }

        private void GiaoDienKho_Click(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtSP.Text = listView1.SelectedItems[0].SubItems[1].Text;
            cboDVT.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtSltonKho.Text = listView1.SelectedItems[0].SubItems[3].Text;
            cboChatLuong.Text = listView1.SelectedItems[0].SubItems[4].Text;

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã sản phẩm");
                txtMaSP.Focus();
                return;
            }
            if (txtSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên sản phẩm");
                txtSP.Focus();
                return;
            }
            if (cboDVT.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin đơn vị tính");
                cboDVT.Focus();
                return;
            }
            if (txtSltonKho.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin số lượng tồn kho");
                txtSltonKho.Focus();
                return;
            }
            if (cboChatLuong.Text == string.Empty)
            {
                MessageBox.Show("Chưa chọn chất lượng");
                cboChatLuong.Focus();
                return;
            }
            try
            {
                connection.Open();
                string sqlINSERT = "INSERT INTO QuanLyKho values(@MaSP, @TenSP, @DVT, @SltonKho, @CLSP)";
                SqlCommand command = new SqlCommand(sqlINSERT, connection);
                command.Parameters.AddWithValue("MaSP", txtMaSP.Text);
                command.Parameters.AddWithValue("TenSP", txtSP.Text);
                command.Parameters.AddWithValue("DVT", cboDVT.SelectedItem.ToString());
                command.Parameters.AddWithValue("SltonKho", txtSltonKho.Text);
                command.Parameters.AddWithValue("CLSP", cboChatLuong.SelectedItem.ToString());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure that the connection is closed, even if an exception occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            hienthi();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connection.Open();
            sql = @"Delete FROM QuanLyKho Where (MaSP = N'" + txtMaSP.Text + @"')";
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            hienthi();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connection.Open();
            sql = @"UPDATE QuanLyKho SET
            MaSP = N'" + txtMaSP.Text + @"', TenSP = N'" + txtSP.Text + @"', DVT = N'" + cboDVT.Text + @"', SltonKho = N'" + txtSltonKho.Text + @"', CLSP = N'" + cboChatLuong.Text + @"'
WHERE       (MaSP = N'" + txtMaSP.Text + @"')";
            command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
            hienthi();
        }
        private bool userConfirmedExit = false;
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                userConfirmedExit = true; // Người dùng đã xác nhận muốn thoát
                this.Close(); // Đóng form
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Truyen_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Comeback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.ShowDialog();
            h = null;
        }

        private void GiaoDienKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userConfirmedExit)
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy sự kiện đóng form nếu người dùng chọn "No"
                }
            }
            // Nếu người dùng chọn "Yes", hoặc nếu đã xác nhận thoát từ nút thoát, thì đóng form bình thường
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(chuoiketnoi))
                    {
                        connection.Open();
                        sql = @"SELECT MaSP, TenSP, DVT, SltonKho, CLSP FROM QuanLyKho WHERE MaSP LIKE @Keyword OR TenSP LIKE @Keyword";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                listView1.Items.Clear();

                                i = 0;
                                while (reader.Read())
                                {
                                    listView1.Items.Add(reader[0].ToString());
                                    listView1.Items[i].SubItems.Add(reader[1].ToString());
                                    listView1.Items[i].SubItems.Add(reader[2].ToString());
                                    listView1.Items[i].SubItems.Add(reader[3].ToString());
                                    listView1.Items[i].SubItems.Add(reader[4].ToString());
                                    i++;
                                }
                            }
                        }

                        // Kiểm tra xem có dữ liệu được tìm thấy hay không
                        if (listView1.Items.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu bạn vừa nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                hienthi();
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
