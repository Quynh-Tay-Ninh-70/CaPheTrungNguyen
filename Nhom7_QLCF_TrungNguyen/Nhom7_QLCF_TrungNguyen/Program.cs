using Giaodiendangnhap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom7_QLCF_TrungNguyen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DangNhap());

            //Application.Run(new DangKy());
            //Application.Run(new QuenMatKhau());
            //--------------------------------------------
            // tuyền Làm
            Application.Run(new ManagementForm());
            ////--------------------------------------------
            //Application.Run(new GiaoDienKho());
            //Application.Run(new Home());

        }
    }
}
