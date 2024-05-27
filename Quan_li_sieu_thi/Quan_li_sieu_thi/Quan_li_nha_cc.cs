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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNCC.ResetText();
            txtTenNCC.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                if (txtMaNCC.Text != "" && txtTenNCC.Text != "" && txtDiaChi.Text != "" && txtSDT.Text != "")
                {
                    if (txtSDT.Text.Length == 9 && txtSDT.Text.All(char.IsDigit))
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
                        }
                        else
                        {
                            MessageBox.Show("Thêm Thất Bại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại phải có đúng 9 chữ số.");
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

                // Check if the supplier has any existing products
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
                    con.Close();
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = chuoiketnoi;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string searchValue = txtTimKiem.Text;

                    string sql = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaNCC", searchValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Tìm kiếm thành công");
    
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhà cung cấp");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if( f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }    
        }

   
    }


}



