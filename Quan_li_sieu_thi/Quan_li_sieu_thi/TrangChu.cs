using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_sieu_thi
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void menuItemLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login dang_Nhap = new Login();
            dang_Nhap.ShowDialog();
            this.Show();
            
        }

        private bool isExiting = false;
        private void exitConfirm()
        {
            if (isExiting)
                return;

            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả của hộp thoại
            if (result == DialogResult.Yes)
            {
                isExiting = true;
                Application.Exit();
            }
        }
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            
            exitConfirm();

        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isExiting)
            {
                e.Cancel = true;
                exitConfirm();
            }
            
        }

        private void menuItemInfor_Click(object sender, EventArgs e)
        {
            string message = "Phần mềm Quản lý Siêu thị\n" +
                     "Phiên bản: 1.0.0\n" +
                     "Sinh viên thực hiện:\n" + 
                     "+Đinh Cao Thắng - 2251162149\n+Vũ Hoàng Anh - 2251162149\n+Nguyễn Vũ Nguyên - 2251162149\n+Nguyễn Thị Vân Anh - 2251162149\n";
                    

            MessageBox.Show(message, "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
