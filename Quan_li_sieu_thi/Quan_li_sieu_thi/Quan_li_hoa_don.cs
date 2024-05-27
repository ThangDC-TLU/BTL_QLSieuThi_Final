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
    public partial class Quan_li_hoa_don : Form
    {
        public Quan_li_hoa_don()
        {
            InitializeComponent();
        }

        private void Quan_li_hoa_don_Load(object sender, EventArgs e)
        {
            Functions.Connect(); //Mở kết nối
            LoadHoaDon();
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = true;

            LoadDataGridView();
        }

        private void LoadHoaDon() {
            dgvHoaDon.DataSource = Functions.GetDataToTable("SELECT MaHD, NgayBan, TongTien FROM HoaDon");
            dgvHoaDon.Columns[0].HeaderText = "MaHD";
            dgvHoaDon.Columns[1].HeaderText = "NgayBan";
            dgvHoaDon.Columns[2].HeaderText = "TongTien";

            dgvHoaDon.Columns[0].Width = 130;
            dgvHoaDon.Columns[1].Width = 130;
            dgvHoaDon.Columns[2].Width = 80;

            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT SanPham.TenSP, ChiTietHD.SoLuong, SanPham.GiaBan, ChiTietHD.GiamGia, ChiTietHD.ThanhTien, HoaDon.NgayBan FROM ChiTietHD INNER JOIN HoaDon ON ChiTietHD.MaHD = HoaDon.MaHD INNER JOIN SanPham ON ChiTietHD.MaSP = SanPham.MaSP WHERE ChiTietHD.MaHD = '" + txbMaHoaDon.Text + "'";

            dgvChiTietHoaDon.DataSource = Functions.GetDataToTable(sql);
            dgvChiTietHoaDon.Columns[0].HeaderText = "TenSp";
            dgvChiTietHoaDon.Columns[1].HeaderText = "So Luong";
            dgvChiTietHoaDon.Columns[2].HeaderText = "Don Gia";
            dgvChiTietHoaDon.Columns[3].HeaderText = "Giam Gia %";
            dgvChiTietHoaDon.Columns[4].HeaderText = "Thanh Tien";
            dgvChiTietHoaDon.Columns[5].HeaderText = "Ngay Ban";

            dgvChiTietHoaDon.Columns[0].Width = 130;
            dgvChiTietHoaDon.Columns[1].Width = 90;
            dgvChiTietHoaDon.Columns[2].Width = 90;
            dgvChiTietHoaDon.Columns[3].Width = 90;
            dgvChiTietHoaDon.Columns[4].Width = 100;
            dgvChiTietHoaDon.Columns[5].Width = 140;
            dgvChiTietHoaDon.AllowUserToAddRows = false;
            dgvChiTietHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txbMaHoaDon.Text = dgvHoaDon.Rows[i].Cells[0].Value.ToString();

            LoadDataGridView();
            btnXoa.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa không?", "Thông báo",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maHD = txbMaHoaDon.Text;
                // Xóa chi tiết hóa đơn
                string sql1 = "DELETE ChiTietHD WHERE MaHD=@maHD";

                // Sử dụng SqlCommand để thực thi câu lệnh SQL và truyền giá trị của biến maHD vào
                SqlCommand cmd = new SqlCommand(sql1, Functions.Con);
                cmd.Parameters.AddWithValue("@maHD", maHD);
                cmd.ExecuteNonQuery();


                // Xóa hóa đơn
                string sql2 = "DELETE HoaDon WHERE MaHD=@maHD";

                // Sử dụng SqlCommand để thực thi câu lệnh SQL và truyền giá trị của biến maHD vào
                SqlCommand cmd1 = new SqlCommand(sql2, Functions.Con);
                cmd1.Parameters.AddWithValue("@maHD", maHD);
                cmd1.ExecuteNonQuery();

                txbMaHoaDon.Text = "";
                btnXoa.Enabled = false;

            }

            //Load lại dữ liệu
            LoadDataGridView();
            LoadHoaDon();
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

        private void Quan_li_hoa_don_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
          
            string start = dtp_start.Value.ToString("yyyy-MM-dd 00:00:00");
            string end = dtp_end.Value.ToString("yyyy-MM-dd 23:59:59");

     
            if (DateTime.Parse(end) < DateTime.Parse(start))
            {
                MessageBox.Show("Ngày kết thúc không thể nhỏ hơn ngày bắt đầu.");
                return;
            }

         
            string sql = "SELECT MaHD, NgayBan, TongTien FROM HoaDon WHERE NgayBan BETWEEN @start AND @end";

            // Đảm bảo kết nối cơ sở dữ liệu đã mở
            if (Functions.Con.State != ConnectionState.Open)
            {
                Functions.Con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(sql, Functions.Con))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvHoaDon.DataSource = dt;

                       
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn nào trong khoảng thời gian đã chỉ định.");
                        }
                        else
                        {
                            MessageBox.Show("Tìm thấy " + dt.Rows.Count + " hóa đơn.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }


        private void btn_Reset_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }
    }
}
