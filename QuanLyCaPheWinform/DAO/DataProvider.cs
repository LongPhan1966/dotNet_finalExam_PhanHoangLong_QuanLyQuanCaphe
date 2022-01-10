using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    class DataProvider  
    {
        private static DataProvider instance;

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        public DataProvider()
        {

        }


        private string connectionSTR = @"Data Source=LAPCN-LONGPH;Initial Catalog=QuanLyCaPhe;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable(); // tạo đối tượng data table;

            using (SqlConnection connection = new SqlConnection(connectionSTR))// kết nối xuống server bằng CHUỖI KẾT NỐI| Dùng using để
                                                                               // giải phóng bộ khi khối lệnh dưới được đóng
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection); //thực thi câu lệnh query trên kết nối này

                if (parameter != null) 
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);// trung gian thực thi câu lệnh để lấy dữ liệu ra

                adapter.Fill(data); // đổ dữ liệu vào tối tượng data

                connection.Close();// đóng kết nối
            } 

            return data;
        }

        internal DataTable ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))// kết nối xuống server bằng CHUỖI KẾT NỐI| Dùng using để
                                                                               // giải phóng bộ khi khối lệnh dưới được đóng
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection); //thực thi câu lệnh query trên kết nối này

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                connection.Close();// đóng kết nối
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0; // tạo đối tượng data table;

            using (SqlConnection connection = new SqlConnection(connectionSTR))// kết nối xuống server bằng CHUỖI KẾT NỐI| Dùng using để
                                                                               // giải phóng bộ khi khối lệnh dưới được đóng
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection); //thực thi câu lệnh query trên kết nối này

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                connection.Close();// đóng kết nối
            }

            return data;
        }
    }
}
