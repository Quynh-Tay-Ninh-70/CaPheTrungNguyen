using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Giaodiendangnhap;
using System.Data.SqlClient;

namespace Giaodiendangnhap
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$");
        }

        public bool checkEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        Modify modify = new Modify();
        private void btn_DangKy_Click(object sender, EventArgs e)
        {  
            string tentk = txt_TenTaiKhoan.Text;
            string matkhau = txt_MatKhau.Text;
            string xnmatkhau = txt_XacNhan.Text;
            string email = txt_Email.Text;
            if (!checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if (!checkAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập tên mật khẩu dài 6-24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }
            if(xnmatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác!");
                return;
            }
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!");
                return;
            }
            if (modify.TaiKhoans("Select * from TaiKhoan where Email = '" + email + "'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng kí, vui lòng đăng kí email khác!");
                return;
            }
            try
            {
                string query = "Insert into TaiKhoan values ('" + tentk + "','" + matkhau + "', '" + email + "')"; 
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập luôn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Hide();
                    DangNhap dn = new DangNhap();
                    dn.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng kí tên tài khoản khác !");
            }
        }

        private void txt_TenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
