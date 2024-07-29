using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giaodiendangnhap
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private bool userConfirmedExit = false;
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (f == DialogResult.Yes)
            {
                // Nếu người dùng chọn "Yes", đặt biến userConfirmedExit thành true
                userConfirmedExit = true;

                // Đóng form hiện tại
                this.Close();
                this.Hide();
                // Tạo và hiển thị form Đăng Nhập
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
            }
            // Nếu người dùng chọn "No", vẫn giữ nguyên như cũ
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiaoDienKho gdk = new GiaoDienKho();
            gdk.ShowDialog();
            gdk = null;
        }
    }
}
