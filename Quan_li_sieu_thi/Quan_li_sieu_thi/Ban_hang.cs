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
    public partial class Ban_hang : Form
    {
        DataTable tblCTHDB; //Bảng chi tiết hoá đơn bán
        public Ban_hang()
        {
            InitializeComponent();
        }

        private void Ban_hang_Load(object sender, EventArgs e)
        {
            Functions.Connect(); //Mở kết nối
            dgvSanPham.DataSource = Functions.GetDataToTable("SELECT MaSP, TenSP, GiaBan, SoLuong FROM SanPham");
            btn_them.Enabled = true;
            btn_luu.Enabled = false;
       

            txb_MaSP.ReadOnly = true;
            txb_TenSP.ReadOnly = true ;
            txb_DonGia.ReadOnly = true;
            txb_SLton.ReadOnly = true;
            txb_ThanhTien.ReadOnly = true;
            txb_TongTien.ReadOnly = true;
            txb_MaHD.ReadOnly = true;
            txb_TongTien.Text = "0";
            txb_ChietKhau.Text = "0";


            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txb_MaHD.Text != "")
            {
                Load_TongTien();
           
            }
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaSP, b.TenSP, a.SoLuong, b.GiaBan, a.GiamGia,a.ThanhTien FROM ChiTietHD AS a, SanPham AS b WHERE a.MaHD = N'" + txb_MaHD.Text + "' AND a.MaSP=b.MaSP";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgv_ChiTietHD.DataSource = tblCTHDB;
            dgv_ChiTietHD.Columns[0].HeaderText = "MaSP";
            dgv_ChiTietHD.Columns[1].HeaderText = "TenSp";
            dgv_ChiTietHD.Columns[2].HeaderText = "So Luong";
            dgv_ChiTietHD.Columns[3].HeaderText = "Don Gia";
            dgv_ChiTietHD.Columns[4].HeaderText = "Giam Gia %";
            dgv_ChiTietHD.Columns[5].HeaderText = "Thanh Tien";
            dgv_ChiTietHD.Columns[0].Width = 80;
            dgv_ChiTietHD.Columns[1].Width = 130;
            dgv_ChiTietHD.Columns[2].Width = 80;
            dgv_ChiTietHD.Columns[3].Width = 90;
            dgv_ChiTietHD.Columns[4].Width = 90;
            dgv_ChiTietHD.Columns[5].Width = 90;
            dgv_ChiTietHD.AllowUserToAddRows = false;
            dgv_ChiTietHD.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Load_TongTien()
        {
            string str;
            str = "SELECT TongTien FROM HoaDon WHERE MaHD = N'" + txb_MaHD.Text + "'";
            txb_TongTien.Text = Functions.GetFieldValues(str);
        }



        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvSanPham.CurrentRow.Index;
            txb_MaSP.Text = dgvSanPham.Rows[i].Cells[0].Value.ToString();
            txb_TenSP.Text = dgvSanPham.Rows[i].Cells[1].Value.ToString();
            txb_DonGia.Text = dgvSanPham.Rows[i].Cells[2].Value.ToString();
            txb_SLton.Text = dgvSanPham.Rows[i].Cells[3].Value.ToString();

           
        }


        private void ResetValues()
        {
            dtp_ngayban.Text = DateTime.Now.ToShortTimeString();
            txb_TenSP.Text = "";
            txb_DonGia.Text = "";
            txb_MaHD.Text = "";
            txb_TongTien.Text = "0";
            txb_MaSP.Text = "";
            txb_SLmua.Text = "";
            txb_SLton.Text = "";
            txb_ChietKhau.Text = "0";
            txb_ThanhTien.Text = "0";
        }

        private void ResetValuesHang()
        {
            txb_MaSP.Text = "";
            txb_TenSP.Text = "";
            txb_DonGia.Text = "";
            txb_SLton.Text = "";
            txb_SLmua.Text = "";
            txb_ChietKhau.Text = "0";
            txb_ThanhTien.Text = "0";
        }








        private void btn_them_Click(object sender, EventArgs e)
        { 
            btn_luu.Enabled = true;
     
            btn_them.Enabled = false;
            ResetValues();
            txb_MaHD.Text = Functions.CreateKey("HDB");
            LoadDataGridView();

        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn thoát không?", "Xác nhận thoát",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Functions.Disconnect();

                this.Close();
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            double tong, Tongmoi;
            int sl, SLcon;
            sql = "SELECT MaHD FROM HoaDon WHERE MaHD=N'" + txb_MaHD.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                
                sql = "INSERT INTO HoaDon(MaHD, NgayBan, TongTien) VALUES (N'" + txb_MaHD.Text.Trim() + "','" +
                        dtp_ngayban.Value +"'," + txb_TongTien.Text + ")";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (txb_MaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txb_MaSP.Focus();
                return;
            }
            if ((txb_SLmua.Text.Trim().Length == 0) || (txb_SLmua.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txb_SLmua.Text = "";
                txb_SLmua.Focus();
                return;
            }
            if (txb_ChietKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txb_ChietKhau.Focus();
                return;
            }
            sql = "SELECT MaSP FROM ChiTietHD WHERE MaSP=N'" + txb_MaSP.Text.Trim() + "' AND MaHD = N'" + txb_MaHD.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                txb_MaSP.Focus();
                return;
            }
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            
            sl = Convert.ToInt32(Functions.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + txb_MaSP.Text.Trim()+ "'"));
            if (Convert.ToInt32(txb_SLmua.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txb_SLmua.Text = "";
                txb_SLmua.Focus();
                return;
            }
            
            sql = "INSERT INTO ChiTietHD(MaHD,MaSP,SoLuong,DonGia, GiamGia,ThanhTien) VALUES('" + txb_MaHD.Text.Trim() + "','" + txb_MaSP.Text.Trim() + "'," + txb_SLmua.Text + "," + txb_DonGia.Text + "," + txb_ChietKhau.Text + "," + txb_ThanhTien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();
            
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToInt32(txb_SLmua.Text);
            sql = "UPDATE SanPham SET SoLuong =" + SLcon + " WHERE MaSP= N'" +txb_MaSP.Text.Trim() + "'";
            Functions.RunSQL(sql);
            
            
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDon WHERE MaHD = '" + txb_MaHD.Text.Trim() + "'"));
            Tongmoi = tong + Convert.ToDouble(txb_ThanhTien.Text);
            sql = "UPDATE HoaDon SET TongTien =" + Tongmoi + " WHERE MaHD = N'" + txb_MaHD.Text + "'";
            Functions.RunSQL(sql);
            txb_TongTien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btn_them.Enabled = true;
            //Load lại dữ liệu sản phẩm
            dgvSanPham.DataSource = DataAccess.GetData("SELECT MaSP, TenSP, GiaBan, SoLuong FROM SanPham");

        }
        private void txb_SLmua_TextChanged(object sender, EventArgs e)
        {
         
            // Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt = 0, dg = 0, gg = 0;
            int sl = 0;

            try
            {
                if (string.IsNullOrWhiteSpace(txb_SLmua.Text))
                {
                    sl = 0;
                }
                else
                {
                    sl = Convert.ToInt32(txb_SLmua.Text);
                }    


                if (string.IsNullOrWhiteSpace(txb_ChietKhau.Text))
                {
                    gg = 0;
                }    
                else
                {
                    gg = Convert.ToDouble(txb_ChietKhau.Text);
                }


                if (string.IsNullOrWhiteSpace(txb_DonGia.Text))
                {
                    dg = 0;
                }
                else
                {
                    dg = Convert.ToDouble(txb_DonGia.Text);
                }

                tt = sl * dg - sl * dg * gg / 100;
                txb_ThanhTien.Text = tt.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_SLmua.Text = "";
            }

        }



        private void txb_ChietKhau_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt=0, dg=0, gg=0;
            int sl = 0;
            try
            {

                if (txb_SLmua.Text == "")
                    sl = 0;
                else
                    sl = Convert.ToInt32(txb_SLmua.Text);
                if (txb_ChietKhau.Text == "")
                    gg = 0;
                else
                    gg = Convert.ToDouble(txb_ChietKhau.Text);
                if (txb_DonGia.Text == "")
                    dg = 0;
                else
                    dg = Convert.ToDouble(txb_DonGia.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_ChietKhau.Text = "";
            }

            tt = sl * dg - sl * dg * gg / 100;
            txb_ThanhTien.Text = tt.ToString();
        }

        private void dgv_ChiTietHD_DoubleClick(object sender, EventArgs e)
        {
            string MaSPxoa, sql;
            Double ThanhTienxoa, tong, tongmoi;
            int SLmuaxoa, sl, slcon;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaSPxoa = dgv_ChiTietHD.CurrentRow.Cells["MaSP"].Value.ToString();
                SLmuaxoa = Convert.ToInt32(dgv_ChiTietHD.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgv_ChiTietHD.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE ChiTietHD WHERE MaHD=N'" + txb_MaHD.Text + "' AND MaSP = N'" + MaSPxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToInt32(Functions.GetFieldValues("SELECT SoLuong FROM SanPham WHERE MaSP = N'" + MaSPxoa + "'"));
                slcon = sl + SLmuaxoa;
                sql = "UPDATE SanPham SET SoLuong =" + slcon + " WHERE MaSP= N'" + MaSPxoa + "'";
                Functions.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM HoaDon WHERE MaHD = N'" + txb_MaHD.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE HoaDon SET TongTien =" + tongmoi + " WHERE MaHD = N'" + txb_MaHD.Text + "'";
                Functions.RunSQL(sql);
                txb_TongTien.Text = tongmoi.ToString();
                LoadDataGridView();
            }
            dgvSanPham.DataSource = DataAccess.GetData("SELECT MaSP, TenSP, GiaBan, SoLuong FROM SanPham");
        }

        private void txb_searchSP_TextChanged(object sender, EventArgs e)
        {
            if(txb_searchSP.Text == "")
            {
                dgvSanPham.DataSource = Functions.GetDataToTable("SELECT MaSP, TenSP, GiaBan, SoLuong FROM SanPham");
            }
            string filterExpression = string.Format("TenSP LIKE '%{0}%'", txb_searchSP.Text);
            (dgvSanPham.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }
    }
}
