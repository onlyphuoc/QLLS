using QLLS.DAO;
using QLLS.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            btnDangNhap.Enter += (send, e) => DangNhap();
            btnDangNhap.Click += (send, e) => DangNhap();
          


        }

      

        private void DangNhap()
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            if (Login(userName, passWord))
            {

                frmMain f = new frmMain();
                f.Show();

            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== Convert.ToChar(Keys.Enter))
            {
                DangNhap();
            }
        }
    }
}
