using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO()
        {

        }

        public bool Login(string userName, string passWord)
        {
            string sql = "select * from Acount where username = N'"+userName+"' and password = N'"+passWord+"' ";

            DataTable rs = DataProvider.Instance.ExecuteQuery(sql);
            
            return rs.Rows.Count > 0;
        }

        public int  getBillIdByTableid(int id)
        {
            return (int)DataProvider.Instance.ExecuteScalar("select * form Bill");
        }

    }
}
