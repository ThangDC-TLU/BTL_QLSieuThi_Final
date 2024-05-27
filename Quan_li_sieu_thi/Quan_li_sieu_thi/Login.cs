using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_sieu_thi
{
    public partial class Login : Form
    {
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin các trường!", "Thông báo");
                return;
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog = QuanLiSieuThi; Integrated Security = True; Encrypt=False"))            
                {
                    connect.Open();
                    string tk = textBox1.Text;
                    string mk = textBox2.Text;
                    string sql = "SELECT Quyen FROM QUANLYTAIKHOAN WHERE TaiKhoan = @tk AND MatKhau = @mk";
                    SqlCommand cmd = new SqlCommand(sql, connect);
                    cmd.Parameters.AddWithValue("@tk", tk);
                    cmd.Parameters.AddWithValue("@mk", mk);

                    SqlDataReader data = cmd.ExecuteReader();
                    if (data.Read())
                    {
                        bool isManager = data.GetBoolean(0);
                        if (isManager)
                        {
                            this.Hide();
                            MessageBox.Show("Đăng nhập thành công! Chào mừng Quản lý.", "Thông báo");
                            Admin ad = new Admin();
                            ad.ShowDialog();
                            this.Show();

                        }
                        else
                        {
                            this.Hide();
                            MessageBox.Show("Đăng nhập thành công! Chào mừng Nhân viên.", "Thông báo");
                            Ban_hang nv = new Ban_hang();
                            nv.ShowDialog();
                            this.Show();

                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin Tài khoản hoặc Mật khẩu không chính xác!", "Thông báo");
                    }
                }
            }
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
