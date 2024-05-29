using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Quan_li_sieu_thi
{
    internal class Functions
    {
        public static SqlConnection Con;      

        public static void Connect()
        {
            Con = new SqlConnection();   
            Con.ConnectionString = ConnectionString.connectionString;
            Con.Open();                  
            //Kiểm tra kết nối
            if (Con.State == ConnectionState.Open)
                MessageBox.Show("Kết nối thành công");
            else MessageBox.Show("Không thể kết nối với dữ liệu");

        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
            }
        }


  
        public static void RunSQL(string sql)
        {
            SqlCommand cmd; 
            cmd = new SqlCommand();
            cmd.Connection = Con; 
            cmd.CommandText = sql; 
            try
            {
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }

      

        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = Functions.Con; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        


        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }

        //Hàm tạo khóa có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            // Lấy ngày giờ hiện tại
            DateTime now = DateTime.Now;

            // Tạo khóa bằng cách kết hợp tiền tố với ngày tháng năm và giờ phút giây
            string key = String.Format("{0}{1:ddMMyyyy}_{2:HHmmss}", tiento, now, now);

            return key;
        }


        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }



    }
}
