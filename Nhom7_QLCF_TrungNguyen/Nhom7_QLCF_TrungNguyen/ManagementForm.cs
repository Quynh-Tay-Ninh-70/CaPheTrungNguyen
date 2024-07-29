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
using Giaodiendangnhap;

namespace Nhom7_QLCF_TrungNguyen
{
    public partial class ManagementForm : Form
    {
        private const string connectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCOFFEE_TRUNGNGUYEN;Integrated Security=True";
        SqlConnection con;
        string sql;
        SqlCommand command;
        SqlDataReader reader;
        int i = 0;
        public ManagementForm()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            string sql = "SELECT * FROM NguyenLieu";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu.");
            }
            dr.Close();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void ManagementForm_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            // Đổi tên của tab
            tabControl1.TabPages[0].Text = "Quản lí nguyên liệu";
            tabControl1.TabPages[1].Text = "Quản lí sản phẩm";
            tabControl1.TabPages[2].Text = "Quản lí hợp đồng";
            tabControl1.TabPages[3].Text = "Quản lí nhập nguyên liệu";
            tabControl1.TabPages[4].Text = "Quản lí xuất sản phẩm";
            tabControl1.TabPages[5].Text = "Quản lí Kho";
            comboBox1.Items.Add("Lon");
            comboBox1.Items.Add("Kg");
            comboBox1.Items.Add("Hủ");
            comboBox1.Items.Add("Chai");
            comboBox1.Items.Add("Hộp");
            // Sản phẩm 
            cbbDVT.Items.Add("Gói");
            cbbDVT.Items.Add("Chai");
            cbbDVT.Items.Add("Hộp");
            // chất lượng sản phẩm 
            CLSP.Items.Add("Loại 1");
            CLSP.Items.Add("Loại 2");
            CLSP.Items.Add("Loại 3");
            CLSP.Items.Add("Loại 4");
            CLSP.Items.Add("Loại 5");
            hienthi();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        
         
        private void btnTruyen_Click_1(object sender, EventArgs e)
        {
            hienthi();
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//sửa
        {
            try
            {
                string sqlEdit = "Update NguyenLieu Set TenNL= @TenNL, DVT=@DVT ,SltonKho=@SltonKho Where MaNL = @MaNL";
                SqlCommand cmd = new SqlCommand(sqlEdit, con);
                cmd.Parameters.AddWithValue("MaNL", textBox1.Text);
                cmd.Parameters.AddWithValue("@TenNL", textBox2.Text);//
                cmd.Parameters.AddWithValue("DVT", comboBox1.SelectedItem.ToString()); // Lấy giá trị đã chọn từ ComboBox
                cmd.Parameters.AddWithValue("SltonKho", textBox4.Text);
                cmd.ExecuteNonQuery();
                hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("ĐÃ XẢY RA LỖI KHI SỬA", "THÔNG BÁO");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã nguyên liệu");
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên nguyên liệu");
                textBox2.Focus();
                return;
            }

            if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên nguyên liệu");
                textBox4.Focus();
                return;
            }
            try
            {
                string sqlINSERT = "INSERT INTO NguyenLieu values(@MaNL, @TenNL, @DVT, @SltonKho)";
                SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                cmd.Parameters.AddWithValue("@MaNL", textBox1.Text);
                cmd.Parameters.AddWithValue("@TenNL", textBox2.Text);
                cmd.Parameters.AddWithValue("@DVT", comboBox1.SelectedItem.ToString()); // Lấy giá trị đã chọn từ ComboBox
                cmd.Parameters.AddWithValue("@SltonKho", textBox4.Text);
                cmd.ExecuteNonQuery();
                hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("ĐÃ XẢY RA LỖI KHI THÊM", "THÔNG BÁO");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From NguyenLieu Where MaNL= @MaNL";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("MaNL", textBox1.Text);
                cmd.Parameters.AddWithValue("@TenNL", textBox2.Text);
                SqlParameter sqlParameter = cmd.Parameters.AddWithValue("DVT", comboBox1.SelectedItem.ToString()); // Lấy giá trị đã chọn từ ComboBox
                cmd.Parameters.AddWithValue("SltonKho", textBox4.Text);
                cmd.ExecuteNonQuery();
                hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show("ĐÃ XẢY RA LỖI KHI XÓA", "THÔNG BÁO");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox4, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(textBox4, "Nhap so");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox2, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sqlSearch = "Select * from NguyenLieu Where MaNL = @MaNL";

            SqlCommand cmd = new SqlCommand(sqlSearch, con);
            cmd.Parameters.AddWithValue("@MaNL", textBox5.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Index = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[Index].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[Index].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[Index].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[Index].Cells[3].Value.ToString();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }




        // form quản lí sản phẩm 
        public void hienthiSP()
        {
            string sqlSelect = "select * from SanPham";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DTGVSanPham.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hienthiSP();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtMSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã sản phẩm");
                txtMSP.Focus();
                return;
            }
            if (txtTSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên sản phẩm");
                txtTSP.Focus();
                return;
            }
            if (txtSLT.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin số lượng tồn");
                txtSLT.Focus();
                return;
            }
            if (txtMNL.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã nguyên liệu");
                txtMNL.Focus();
                return;
            }
            if (cbbDVT.Text == string.Empty)
            {
                MessageBox.Show("Chưa chọn đơn vị tính");
                cbbDVT.Focus();
                return;
            }
            try
            {
                string sqlINSERT = "INSERT INTO SanPham values(@MaSP, @TenSP, @DVT, @SltonKho, @MaNL, @CLSP)";
                SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                cmd.Parameters.AddWithValue("MaSP", txtMSP.Text);
                cmd.Parameters.AddWithValue("TenSP", txtTSP.Text);
                cmd.Parameters.AddWithValue("DVT", cbbDVT.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("SltonKho", txtSLT.Text);
                cmd.Parameters.AddWithValue("MaNL", txtMNL.Text);
                cmd.Parameters.AddWithValue("CLSP", CLSP.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
                hienthiSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From SanPham Where MaSP= @MaSP";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("MaSP", txtMSP.Text);
                cmd.ExecuteNonQuery();
                hienthiSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suaSP_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlEdit = "Update SanPham Set TenSP= @TenSP, DVT=@DVT ,SltonKho=@SltonKho,MaNL = @MaNL Where MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sqlEdit, con);
                cmd.Parameters.AddWithValue("MaSP", txtMSP.Text);
                cmd.Parameters.AddWithValue("TenSP", txtTSP.Text);
                cmd.Parameters.AddWithValue("DVT", cbbDVT.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("SltonKho", txtSLT.Text);
                cmd.Parameters.AddWithValue("MaNL", txtMNL.Text);
                cmd.ExecuteNonQuery();
                hienthiSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kiemSP_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSearch = "Select * from SanPham Where MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("MaSP", txtTim.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DTGVSanPham.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DTGVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Index = DTGVSanPham.CurrentRow.Index;
                txtMSP.Text = DTGVSanPham.Rows[Index].Cells[0].Value.ToString();
                txtTSP.Text = DTGVSanPham.Rows[Index].Cells[1].Value.ToString();
                cbbDVT.Text = DTGVSanPham.Rows[Index].Cells[2].Value.ToString();
                txtSLT.Text = DTGVSanPham.Rows[Index].Cells[3].Value.ToString();
                txtMNL.Text = DTGVSanPham.Rows[Index].Cells[4].Value.ToString();
                CLSP.Text = DTGVSanPham.Rows[Index].Cells[5].Value.ToString();
            }
        }

        private void txtMSP_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTSP_Leave(object sender, EventArgs e)
        {
            if (txtTSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTSP, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        // form quản lí hợp đồng 
        public void hienthiHD()
        {
            string sqlSelect = "SELECT * FROM HopDong";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DTGVHopDong.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hienthiHD();
        }

        private void themHD_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã hợp đồng");
                textBox3.Focus();
                return;
            }

            if (textBox8.Text == string.Empty && textBox10.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã sản phẩm hoặc mã nguyên liệu");
                textBox8.Focus();
                return;
            }

            try
            {
                string sqlINSERT = "INSERT INTO HopDong (MaHD, NgayKi, ThoiHan, GiaTri, MaNL, MaSP, LoaiHD) " +
                                   "VALUES (@MaHD, @NgayKi, @ThoiHan, @GiaTri, " +
                                   (textBox10.Text == string.Empty ? "NULL, " : "@MaNL, ") +
                                   (textBox8.Text == string.Empty ? "NULL, " : "@MaSP, ") +
                                   "@LoaiHD)";

                SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                cmd.Parameters.AddWithValue("@MaHD", textBox3.Text);
                cmd.Parameters.AddWithValue("@NgayKi", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@ThoiHan", textBox7.Text);
                cmd.Parameters.AddWithValue("@GiaTri", textBox9.Text);
                if (textBox10.Text != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@MaNL", textBox10.Text);
                }
                if (textBox8.Text != string.Empty)
                {
                    cmd.Parameters.AddWithValue("@MaSP", textBox8.Text);
                }
                cmd.Parameters.AddWithValue("@LoaiHD", textBox6.Text);
                cmd.ExecuteNonQuery();
                hienthiHD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void xoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "DELETE FROM HopDong WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@MaHD", textBox1.Text);
                cmd.ExecuteNonQuery();
                hienthiHD();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void SuaHD_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string sqlEdit = "UPDATE HopDong SET MaHD = @MaHD, NgayKi = @NgayKi, ThoiHan = @ThoiHan, GiaTri = @GiaTri, MaNL = @MaNL, MaSP = @MaSP, LoaiHD = @LoaiHD WHERE MaHD = @MaHD";
            //    SqlCommand cmd = new SqlCommand(sqlEdit, con);
            //    cmd.Parameters.AddWithValue("@MaHD", textBox3.Text);
            //    cmd.Parameters.AddWithValue("@NgayKi", dateTimePicker1.Value);
            //    cmd.Parameters.AddWithValue("@GiaTri", textBox9.Text);
            //    cmd.Parameters.AddWithValue("@MaNL", textBox10.Text);
            //    cmd.Parameters.AddWithValue("@MaSP", textBox8.Text);
            //    cmd.Parameters.AddWithValue("@LoaiHD", textBox6.Text);

            //    int thoiHan;
            //    if (int.TryParse(textBox7.Text, out thoiHan))
            //    {
            //        cmd.Parameters.AddWithValue("@ThoiHan", thoiHan);
            //        cmd.ExecuteNonQuery();
            //        hienthiHD();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Thời hạn không hợp lệ. Vui lòng nhập một số nguyên.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
            try
            {
                string sqlEdit = "UPDATE HopDong SET MaHD = @MaHD, NgayKi = @NgayKi, ThoiHan = @ThoiHan, GiaTri = @GiaTri, MaNL = @MaNL, MaSP = @MaSP, LoaiHD = @LoaiHD WHERE MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sqlEdit, con);
                cmd.Parameters.AddWithValue("@MaHD", textBox3.Text);
                cmd.Parameters.AddWithValue("@NgayKi", dateTimePicker1.Value);

                int thoiHan;
                if (int.TryParse(textBox7.Text, out thoiHan))
                {
                    cmd.Parameters.AddWithValue("@ThoiHan", thoiHan);
                }
                else
                {
                    MessageBox.Show("Thời hạn không hợp lệ. Vui lòng nhập một số nguyên.");
                    return; // Exit the method or handle the error as needed
                }

                decimal giaTri;
                if (decimal.TryParse(textBox9.Text, out giaTri))
                {
                    cmd.Parameters.AddWithValue("@GiaTri", giaTri);
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ. Vui lòng nhập một số hợp lệ.");
                    return; // Exit the method or handle the error as needed
                }

                cmd.Parameters.AddWithValue("@MaNL", textBox10.Text);
                cmd.Parameters.AddWithValue("@MaSP", textBox8.Text);
                cmd.Parameters.AddWithValue("@LoaiHD", textBox6.Text);

                cmd.ExecuteNonQuery();
                hienthiHD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
           
        private void kiemHD_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSearch = "Select * from HopDong Where MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("@MaHD", textBox3.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DTGVHopDong.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
        }


        private void DTGVHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                int Index = DTGVHopDong.CurrentRow.Index;
                textBox3.Text = DTGVHopDong.Rows[Index].Cells[0].Value.ToString();
                textBox7.Text = DTGVHopDong.Rows[Index].Cells[2].Value.ToString();
                textBox9.Text = DTGVHopDong.Rows[Index].Cells[3].Value.ToString();
                textBox10.Text = DTGVHopDong.Rows[Index].Cells[4].Value.ToString();
                textBox8.Text = DTGVHopDong.Rows[Index].Cells[5].Value.ToString();
                textBox6.Text = DTGVHopDong.Rows[Index].Cells[6].Value.ToString();
                dateTimePicker1.Text = DTGVHopDong.Rows[Index].Cells[1].Value.ToString();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox1, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox2, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox3, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox10, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox5, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(textBox6, "Chua nhap lieu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }



        // form nhập nguyên liệu 
        private void label26_Click(object sender, EventArgs e)
        {

        }
        public void hienthi_ttNNL()
        {
            string sqlSelect = "select * from NhapNguyenLieu ";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataNNL.DataSource = dt;
            dataNNL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        
        
        
        private void TRUYENHDN_Click(object sender, EventArgs e)
        {
            hienthi_ttNNL();
        }

        private void THEMHDN_Click(object sender, EventArgs e)
        {
            if (NNL.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã nguyên liệu ");
                NNL.Focus();
                return;
            }
            if (TNNL.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên nguyên liệu");
                TNNL.Focus();
                return;
            }
            if (MHDN.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hợp đồng ");
                MHDN.Focus();
                return;
            }
            if (SLN.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập số lượng nhập");
                SLN.Focus();
                return;
            }
            if (NKNNL.Text == string.Empty)
            {
                MessageBox.Show("Chưa chọn ngày kí hợp đồng.");
                NKNNL.Focus();
                return;
            }
            try
            {
                string sqlINSERT = "INSERT INTO NhapNguyenLieu values(@MaNL, @MaHD, @NgayKi, @SoLuong, @TenNL)";
                SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                cmd.Parameters.AddWithValue("MaNL", NNL.Text);
                cmd.Parameters.AddWithValue("MaHD", MHDN.Text);
                cmd.Parameters.AddWithValue("@NgayKi", NKNNL.Value);
                cmd.Parameters.AddWithValue("SoLuong", SLN.Text);
                cmd.Parameters.AddWithValue("TenNL", TNNL.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttNNL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Đảm bảo rằng MÃ HỢP ĐỒNG đã được thêm vào bảng HỢP ĐỒNG  " );
            }
        }

        private void NNL_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chưa nhập liệu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TNNL_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chưa nhập liệu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void MHDN_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chưa nhập liệu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void SLN_TextChanged(object sender, EventArgs e)
        {

        }

        private void SLN_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chưa nhập liệu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void NKNNL_Leave(object sender, EventArgs e)
        {
            if (txtMSP.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtMSP, "Chưa nhập liệu");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void dataNNL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataNNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Index = dataNNL.CurrentRow.Index;
                NNL.Text = dataNNL.Rows[Index].Cells[0].Value.ToString();
                TNNL.Text =dataNNL.Rows[Index].Cells[4].Value.ToString();
                MHDN.Text =dataNNL.Rows[Index].Cells[1].Value.ToString();
                SLN.Text = dataNNL.Rows[Index].Cells[3].Value.ToString();
                NKNNL.Text = dataNNL.Rows[Index].Cells[2].Value.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void XOAHDN_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From NhapNguyenLieu Where MaNL= @MaNL";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("MaNL", NNL.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttNNL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: không thể xóa vì có liên quan đến bảng HỢP ĐỒNG " );
            }
        }

        private void SUAHDNHAP_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlUpdate = "UPDATE NhapNguyenLieu SET SoLuong = @SoLuong WHERE MaNL = @MaNL AND MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@SoLuong", SLN.Text);
                cmd.Parameters.AddWithValue("@MaNL", NNL.Text);
                cmd.Parameters.AddWithValue("@MaHD", TNNL.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttNNL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KIMNGAYNHAP_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSearch = "Select * from NhapNguyenLieu Where MaNL = @MaNL";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("MaNL", NNL.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataNNL.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }



        public void hienthi_ttXSP()
        {
            string sqlSelect = "select * from XuatSanPham";
            SqlCommand cmd = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dtXSP.DataSource = dt;
            dtXSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void TrXK_Click(object sender, EventArgs e)
        {
            hienthi_ttXSP();
        }

        private void themXK_Click(object sender, EventArgs e)
        {
            if (maSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin mã sản phẩm ");
                maSP.Focus();
                return;
            }
            if (tenSP.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập thông tin tên sản phẩm ");
                tenSP.Focus();
                return;
            }
            if (MHD.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã hợp đồng ");
                MHD.Focus();
                return;
            }
            if (SLX.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập số lượng xuất");
                SLX.Focus();
                return;
            }
            if (NXK.Text == string.Empty)
            {
                MessageBox.Show("Chưa chọn ngày kí hợp đồng.");
                NXK.Focus();
                return;
            }
            try
            {
                string sqlINSERT = "INSERT INTO XuatSanPham values(@MaSP, @MaHD, @NgayKi, @SoLuong, @TenSP)";
                SqlCommand cmd = new SqlCommand(sqlINSERT, con);
                cmd.Parameters.AddWithValue("MaSP", maSP.Text);
                cmd.Parameters.AddWithValue("MaHD", MHD.Text);
                cmd.Parameters.AddWithValue("@NgayKi", NXK.Value);
                cmd.Parameters.AddWithValue("SoLuong", SLX.Text);
                cmd.Parameters.AddWithValue("TemaSP", tenSP.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttXSP();
            }
            catch (Exception )
            {
                MessageBox.Show("Lỗi: Đảm bảo rằng MÃ HỢP ĐỒNG đã được thêm vào bảng HỢP ĐỒNG  ");
            }

        }

        private void dtXSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Index = dtXSP.CurrentRow.Index;
                maSP.Text = dtXSP.Rows[Index].Cells[0].Value.ToString();
                tenSP.Text = dtXSP.Rows[Index].Cells[4].Value.ToString();
                MHD.Text = dtXSP.Rows[Index].Cells[1].Value.ToString();
                SLX.Text = dtXSP.Rows[Index].Cells[3].Value.ToString();
                NXK.Text = dtXSP.Rows[Index].Cells[2].Value.ToString();
            }

        }

        private void XoaXK_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlDelete = "Delete From XuatSanPham Where MaSP= @MaSP";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("MaSP", maSP.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttXSP();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi: không thể xóa vì có liên quan đến bảng HỢP ĐỒNG ");
            }

        }

        private void SuaXK_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlUpdate = "UPDATE XuatSanPham SET SoLuong = @SoLuong WHERE MaSP = @MaSP AND MaHD = @MaHD";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@SoLuong", SLX.Text);
                cmd.Parameters.AddWithValue("@MaSP", NNL.Text);
                cmd.Parameters.AddWithValue("@MaHD", TNNL.Text);
                cmd.ExecuteNonQuery();
                hienthi_ttXSP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void kimXK_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSearch = "Select * from XuatSanPham Where MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("MaSP", maSP.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dtXSP.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ManagementForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Close();

            MessageBox.Show("Bạn có muốn đóng ứng dụng!", "Thông báo", MessageBoxButtons.OK);
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
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
                con.Open();
                string sqlINSERT = "INSERT INTO QuanLyKho values(@MaSP, @TenSP, @DVT, @SltonKho, @CLSP)";
                SqlCommand command = new SqlCommand(sqlINSERT, con);
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
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            hienthi();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            sql = @"Delete FROM QuanLyKho Where (MaSP = N'" + txtMaSP.Text + @"')";
            command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
            hienthi();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            sql = @"UPDATE QuanLyKho SET
            MaSP = N'" + txtMaSP.Text + @"', TenSP = N'" + txtSP.Text + @"', DVT = N'" + cboDVT.Text + @"', SltonKho = N'" + txtSltonKho.Text + @"', CLSP = N'" + cboChatLuong.Text + @"'
WHERE       (MaSP = N'" + txtMaSP.Text + @"')";
            command = new SqlCommand(sql, con);
            command.ExecuteNonQuery();
            con.Close();
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

        private void tabPage6_Click(object sender, EventArgs e)
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

        private void txtMaSP_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //GiaoDienKho kho = new GiaoDienKho();
            //kho.ShowDialog();
        }

        private void btn_Comeback_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home h = new Home();
            h.ShowDialog();
            h = null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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
    }

}

