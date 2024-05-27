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

        private void GiaNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void GiaBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void SoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void HSD_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DonViTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void ttnguoinhap_TextChanged(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ttreset_Click(object sender, EventArgs e)
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
        
        private void Quan_li_san_pham_Load(object sender, EventArgs e)
        {
            load();
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

        private void tttimkiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(chuoiketnoi);
            try
            {
                con.Open();
                string searchValue = MaSP.Text;
                string sql = "SELECT *FROM SanPham WHERE MaSP = '" + TimKiem.Text + "'";
                SqlDataAdapter dt = new SqlDataAdapter(sql, con);
                DataTable tb = new DataTable();
                dt.Fill(tb);

                if (tb.Rows.Count > 0 )
                {
                    tabledata.DataSource = tb;
                    MessageBox.Show("Tìm kiếm thành công");
                    load();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phầm nào");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối" + ex.Message);
            }
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
    }
}
