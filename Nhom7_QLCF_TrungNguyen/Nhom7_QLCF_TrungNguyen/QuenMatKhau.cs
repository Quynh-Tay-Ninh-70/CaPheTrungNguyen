using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Giaodiendangnhap
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
            label1.Text = "";
        }
        Modify modify = new Modify();

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email đăng kí!");
            }
            else
            {
                if (IsValidEmail(email))
                {
                    string query = "Select * from TaiKhoan where Email = '" + email + "'";
                    if (modify.TaiKhoans(query).Count != 0)
                    {
                        label1.ForeColor = Color.Blue;
                        label1.Text = "Mật khẩu: " + modify.TaiKhoans(query)[0].MatKhau;
                    }
                    else
                    {
                        label1.ForeColor = Color.Red;
                        label1.Text = "Email này chưa được đăng kí!";
                    }
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "Phải nhập đúng định dạng email!";
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
