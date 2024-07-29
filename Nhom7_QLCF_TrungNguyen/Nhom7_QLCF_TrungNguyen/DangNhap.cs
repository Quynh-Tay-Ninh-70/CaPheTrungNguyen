using Nhom7_QLCF_TrungNguyen;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            if (tentk.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!"); 
            } 
            else if (matkhau.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu!"); }
            else
            {
                string query = "Select * from TaiKhoan where TenTaiKhoan ='" + tentk + "' and MatKhau = '" + matkhau + "'";
                if (modify.TaiKhoans(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ManagementForm trangchu = new ManagementForm();
                    trangchu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
            quenMatKhau = null;
            this.Show();
        }

        private void linkLabel2_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKy dangKy = new DangKy();
            dangKy.ShowDialog();
            dangKy = null;
            this.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
