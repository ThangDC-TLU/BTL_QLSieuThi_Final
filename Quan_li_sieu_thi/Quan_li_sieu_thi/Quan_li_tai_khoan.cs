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
    public partial class Quan_li_tai_khoan : Form
    {
        string connectstring = @"Data Source=.\SQLEXPRESS;Initial Catalog = QuanLiSieuThi; Integrated Security = True; Encrypt=False";
        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;

        private void LoadData()
        {
            connect.Open();
            command = new SqlCommand("SELECT * FROM QUANLYTAIKHOAN", connect);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            connect.Close();
            dataGridView.DataSource = table;
        }

        private bool IsAccountExists(string tk)
        {
            bool exists = false;
            try
            {
                connect.Open();
                string query = "SELECT COUNT(*) FROM QUANLYTAIKHOAN WHERE TaiKhoan = @TaiKhoan";
                using (command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", tk);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        exists = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            return exists;
        }
        private void InsertData(string tk, string mk, string name, int role, DateTime date)
        {
            if (mk.Length > 10)
            {
                MessageBox.Show("Mật khẩu không quá 10 ký tự!");
                return;
            }
            if (IsAccountExists(tk))
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng nhập tài khoản khác!");
                return;
            }


            connect.Open();
                string query = "INSERT INTO QUANLYTAIKHOAN (TaiKhoan, MatKhau, HoVaTen, NgayTao, Quyen) VALUES (@TaiKhoan, @MatKhau, @HoVaTen, @NgayTao, @Quyen)";
                using (command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", tk);
                    command.Parameters.AddWithValue("@MatKhau", mk);
                    command.Parameters.AddWithValue("@HoVaTen", name);
                    command.Parameters.AddWithValue("@NgayTao", date);
                    command.Parameters.AddWithValue("@Quyen", role);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm tài khoản thành công!");
            
            
                connect.Close();
            
        }
        private void DeleteData(string tk)
        {
            try
            {
                connect.Open();
                string query = "DELETE FROM QUANLYTAIKHOAN WHERE TaiKhoan = @TaiKhoan";
                using (command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", tk);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void UpdateData(string tk, string mk, string name, int role, DateTime date)
        {
            try
            {
                connect.Open();
                string query = "UPDATE QUANLYTAIKHOAN SET MatKhau = @MatKhau, HoVaTen = @HoVaTen, NgayTao = @NgayTao, Quyen = @Quyen WHERE TaiKhoan = @TaiKhoan";
                using (command = new SqlCommand(query, connect))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", tk);
                    command.Parameters.AddWithValue("@MatKhau", mk);
                    command.Parameters.AddWithValue("@HoVaTen", name);
                    command.Parameters.AddWithValue("@NgayTao", date);
                    command.Parameters.AddWithValue("@Quyen", role);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        private void ClearInputFields()
        {
           
            textBox_TK.Text = "";
            textBox_Name.Text = "";
            textBox_MK.Text = "";
            ChV.SelectedIndex = -1; 
            Date.Value = DateTime.Now; 
        }

        public Quan_li_tai_khoan()
        {
            InitializeComponent();
        }
        private void Quan_li_tai_khoan_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(connectstring);
            table = new DataTable();
            LoadData();
            ChV.Items.Add("Quản lý");
            ChV.Items.Add("Nhân viên");
            dataGridView.CellContentClick += dataGridView1_CellContentClick;
            this.Size = new Size(905, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex  >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

               
                textBox_TK.Text = row.Cells["TaiKhoan"].Value.ToString();
                textBox_Name.Text = row.Cells["HoVaTen"].Value.ToString();
                textBox_MK.Text = row.Cells["MatKhau"].Value.ToString();
                object quyenValue = row.Cells["Quyen"].Value;
                if (quyenValue != DBNull.Value)
                {
                    int roleValue = Convert.ToInt32(quyenValue);
                    ChV.SelectedItem = roleValue == 1 ? "Quản lý" : "Nhân viên";
                }
                else
                {
                    ChV.SelectedIndex = -1;
                }
                Date.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            }
            textBox_TK.Enabled = false;
            Date.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TK_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ChV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string tk = textBox_TK.Text;
            string name = textBox_Name.Text;
            int role = ChV.SelectedItem != null ? (ChV.SelectedItem.ToString() == "Quản lý" ? 1 : 0) : -1;
            DateTime date = Date.Value;
            string mk = textBox_MK.Text;

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(name) || role == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường!");
                return;
            }

            

            InsertData(tk, mk, name, role, date);
            LoadData();
            ClearInputFields();
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            string tk = textBox_TK.Text;

            if (string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Vui lòng nhập tài khoản hợp lệ để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn xóa tài khoản này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteData(tk);
                LoadData();
            }
            ClearInputFields();
            textBox_TK.Enabled = true;
            Date.Enabled = true;
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            string tk = textBox_TK.Text;
            string name = textBox_Name.Text;
            int role = ChV.SelectedItem != null ? (ChV.SelectedItem.ToString() == "Quản lý" ? 1 : 0) : -1;
            DateTime date = Date.Value;
            string mk = textBox_MK.Text;

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk) || string.IsNullOrEmpty(name) || role == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường!");
                return;
            }

            UpdateData(tk, mk, name, role, date);
            LoadData();
            ClearInputFields();
            textBox_TK.Enabled = true;
            Date.Enabled = true;
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

        private void button_Exit_Click(object sender, EventArgs e)
        {
            exitConfirm();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void Quan_li_tai_khoan_FormClosing(object sender, FormClosingEventArgs e)
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
