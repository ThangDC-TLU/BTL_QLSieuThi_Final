using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Quan_li_sieu_thi
{
    public partial class Quan_li_nha_cc : Form
    {
        public Quan_li_nha_cc()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=.\SQLEXPRESS;Initial Catalog = QuanLiSieuThi; Integrated Security = True; Encrypt=False";
        private void load()
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
                string sql = "SELECT * FROM NhaCungCap";
                SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                dataGridView1.DataSource = tb;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
        }
       
        private void Quan_li_nha_cc_Load(object sender, EventArgs e)
        {
            load();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        void reset()
        {
            txtMaNCC.ResetText();
            txtTenNCC.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
            load();
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Biểu thức chính quy kiểm tra định dạng số điện thoại
            string pattern = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

            // Kiểm tra xem chuỗi nhập vào có phù hợp với định dạng không
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
                {
                    if (IsValidPhoneNumber(txtSDT.Text))
                    {
                        con.Open();
                        string sql = "INSERT INTO NhaCungCap(MaNCC, TenNCC, DiaChi, SDT) VALUES (@MaNCC, @TenNCC, @DiaChi, @SDT)";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                        cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm Thành Công");
                            load();
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Thêm Thất Bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập đủ thông tin");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Nhà cung cấp đã tồn tại ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: ");
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
            private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
                string sql = "UPDATE NhaCungCap SET TenNCC = @TenNCC, DiaChi = @DiaChi, SDT = @SDT WHERE MaNCC = @MaNCC";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                int kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    load();
                    reset();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(chuoiketnoi);
                con.Open();

                
                string checkSql = "SELECT COUNT(*) FROM SanPham WHERE MaNCC = @MaNCC";
                SqlCommand checkCmd = new SqlCommand(checkSql, con);
                checkCmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                int productCount = (int)checkCmd.ExecuteScalar();

                if (productCount > 0)
                {
                    
                    DialogResult confirmDelete = MessageBox.Show("Nhà cung cấp này đang có sản phẩm tồn tại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (confirmDelete == DialogResult.OK)
                    {
                        con.Close();
                        return; 
                    }
                }
                else
                {

                    string sql = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    load(); 
                    reset();
                    con.Close();
                }

            }
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            exitConfirm();
        }

        private void Quan_li_nha_cc_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
                {
                    con.Open();
                    //Nếu tìm kiếm rỗng thì sẽ load lại dữ liệu
                    if (txtTimKiem.Text == "")
                    {
                        string sql = "SELECT * FROM NhaCungCap";
                        SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                        DataTable tb = new DataTable();
                        dt.Fill(tb);
                        dataGridView1.DataSource = tb;
                    }

                    string loc = string.Format("TenNCC LIKE '%{0}%'", txtTimKiem.Text);
                    //Chuyển đổi thành DataTable để sử dụng thuộc tính RowFilter để lọc
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = loc;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            
        }
    }


}



