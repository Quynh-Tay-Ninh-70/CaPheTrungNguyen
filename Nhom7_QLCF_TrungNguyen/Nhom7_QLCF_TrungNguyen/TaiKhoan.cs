using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giaodiendangnhap
{
    public class TaiKhoan
    {

        public string TenTaiKhoan
        {
            get
            {
                return tenTaiKhoan;
            }

            set
            {
                tenTaiKhoan = value;
            }
        }
        private string tenTaiKhoan;
        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        private string matKhau;

        public TaiKhoan(string tentaikhoan, string matkhau)
        {
            this.TenTaiKhoan = tentaikhoan;
            this.MatKhau = matkhau;
        }
    }
}
