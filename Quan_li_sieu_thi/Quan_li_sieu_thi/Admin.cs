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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
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
                this.Close();
            }
        }

        private void menu_item_QLTK_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quan_li_tai_khoan qltk = new Quan_li_tai_khoan();
            qltk.ShowDialog();
            this.Show();
        }

        private void menu_item_QLHD_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quan_li_hoa_don qlhd = new Quan_li_hoa_don();
            qlhd.ShowDialog();
            this.Show();
        }

        private void menu_item_BanHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ban_hang ban_Hang = new Ban_hang();
            ban_Hang.ShowDialog();
            this.Show();
        }

        private void menu_item_Info_Click(object sender, EventArgs e)
        {
            string message = "Phần mềm Quản lý Siêu thị\n" +
                    "Phiên bản: 1.0.0\n" +
                    "Sinh viên thực hiện:\n" +
                    "+Đinh Cao Thắng - 2251162149\n+Vũ Hoàng Anh - 2251161947\n+Nguyễn Vũ Nguyên - 2251162092\n+Nguyễn Thị Vân Anh - 2251161943\n";


            MessageBox.Show(message, "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menu_item_Exit_Click(object sender, EventArgs e)
        {
            exitConfirm();

        }

        private void menu_item_QLNCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quan_li_nha_cc ncc = new Quan_li_nha_cc();
            ncc.ShowDialog();
            this.Show();
        }

        private void menu_item_QLSP_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quan_li_san_pham sp = new Quan_li_san_pham();
            sp.ShowDialog();
            this.Show();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExiting)
            {
                DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy bỏ việc đóng form
                }
                else
                {
                    isExiting = true; // Cho phép đóng form nếu người dùng chọn Yes
                }
            }
        }
    }
}
