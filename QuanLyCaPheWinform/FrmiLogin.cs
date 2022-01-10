using QuanLyCaPheWinform.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaPheWinform
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtus.Text;
            string pass = txtpass.Text;
            if(Login(userName, pass))
            {
                FrmMainMenu1 f = new FrmMainMenu1();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
        }
        bool Login(string userName, string pass)
        {
            return AccountDAO.Instance.Login(userName, pass);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Thoát ứng dụng ?","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
