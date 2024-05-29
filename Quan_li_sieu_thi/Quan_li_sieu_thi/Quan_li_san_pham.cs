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
using System.Runtime.Remoting;

namespace Quan_li_sieu_thi
{
    public partial class Quan_li_san_pham : Form
    {
        
        
        public Quan_li_san_pham()
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
                string sql = "SELECT *FROM SanPham";
                SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                tabledata.DataSource = tb;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
        }
        
        private void MaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void TenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void MaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        public bool KiemTraMaSP(string MaSP)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            con.Open();
            string sql = "SELECT MaSP from SanPham where MaSP = N'" +MaSP+ "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read()==true) // nếu đã tồn tại mã SP trong CSDL rồi thì trả về true
            {
                con.Close();
                return true;
            }    
            con.Close();
            return false;
        }
        
        private void Thêm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                if (MaSP.Text!="" && TenSP.Text!="" && MaNCC.Text!="" && GiaNhap.Text!="" && GiaBan.Text!="" && SoLuong.Text!=""&& HSD.Text!="" && DonViTinh.Text!="" )
                {
                    if (KiemTraMaSP(MaSP.Text)==true) 
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại");
                    }
                    else
                    {
                        con.Open();
                        string sql = "INSERT INTO SanPham(MaSP, TenSP, MaNCC, GiaNhap, GiaBan, SoLuong, HSD, DonViTinh) VALUES (N'" + MaSP.Text + "', N'" + TenSP.Text + "', N'" + MaNCC.Text + "', N'" + GiaNhap.Text + "', N'" + GiaBan.Text + "', N'" + SoLuong.Text + "', N'" + HSD.Text + "', N'" + DonViTinh.Text + "')";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        int kq = (int)cmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Thêm thành công");
                            load();
                            reset();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập đủ thông tin");
                }
                
                
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Lỗi kết nối: "+ex.Message);    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao=MessageBox.Show("Bạn có muốn xóa hay không ?", "Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(chuoiketnoi);
                con.Open();
                string sql = "DELETE FROM SanPham WHERE MaSP = '" + MaSP.Text + "'";
                SqlCommand cmd = new SqlCommand (sql, con); 
                cmd.ExecuteNonQuery ();
                MessageBox.Show("Xóa thành công!");
                load();
                reset();
                con.Close();
            }
        }

        private void Sửa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
                string sql = "UPDATE SanPham SET MaSP = N'" + MaSP.Text + "', TenSP = N'" + TenSP.Text + "', MaNCC = N'" + MaNCC.Text + "', GiaNhap = N'" + GiaNhap.Text + "', GiaBan = N'" + GiaBan.Text + "', SoLuong = N'" + SoLuong.Text + "', HSD = N'" + HSD.Text + "', DonViTinh = N'" + DonViTinh.Text + "'WHERE MaSP = '" + MaSP.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int kq = (int)cmd.ExecuteNonQuery();
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
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
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

        private void button4_Click(object sender, EventArgs e)
        {
            exitConfirm();
        }

        void reset()
        {
            MaSP.ResetText();
            TenSP.ResetText();
            MaNCC.ResetText();
            GiaNhap.ResetText();
            GiaBan.ResetText();
            SoLuong.ResetText();
            HSD.ResetText();
            DonViTinh.ResetText();
            TimKiem.ResetText();
        }
        private void ttreset_Click(object sender, EventArgs e)
        {
            reset();
            load();
        }
        
        private void Quan_li_san_pham_Load(object sender, EventArgs e)
        {
            load();
            MaNCC_TextChanged(sender, e);
        }

        private void tabledata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MaSP.Text = tabledata.CurrentRow.Cells[0].Value.ToString();
            TenSP.Text = tabledata.CurrentRow.Cells[1].Value.ToString();
            MaNCC.Text = tabledata.CurrentRow.Cells[2].Value.ToString();
            GiaNhap.Text = tabledata.CurrentRow.Cells[3].Value.ToString();
            GiaBan.Text = tabledata.CurrentRow.Cells[4].Value.ToString();
            SoLuong.Text = tabledata.CurrentRow.Cells[5].Value.ToString();
            HSD.Text = tabledata.CurrentRow.Cells[6].Value.ToString();
            DonViTinh.Text = tabledata.CurrentRow.Cells[7].Value.ToString();
        }

       

        private void GiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)|| char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled= true;
            }
        }

        private void GiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Quan_li_san_pham_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MaNCC_TextChanged(object sender, EventArgs e)
        {
            MaNCC.Items.Clear();
                

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection con = new SqlConnection(chuoiketnoi))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT MaNCC FROM NhaCungCap";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    // Thực thi truy vấn và đọc dữ liệu
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Thêm dữ liệu vào ComboBox
                        MaNCC.Items.Add(reader["MaNCC"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void TimKiem_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
                if (TimKiem.Text == "")
                {
                    string sql = "SELECT MaSP, TenSP, MaNCC, GiaNhap, GiaBan, SoLuong, HSD, DonViTinh FROM SanPham";
                    SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                    DataTable tb = new DataTable();
                    dt.Fill(tb);
                    tabledata.DataSource = tb;
                }

                string loc = string.Format("TenSP LIKE '%{0}%'", TimKiem.Text);
                //Chuyển đổi thành DataTable để sử dụng thuộc tính RowFilter để lọc
                (tabledata.DataSource as DataTable).DefaultView.RowFilter = loc;
            
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
