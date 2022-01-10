using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO()
        {

        }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idTable = " + id + " and status = 0");
            if (data.Rows.Count > 0)
            {
                BillDTO bill = new BillDTO(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec InsertBill @idTable", new object[]{id});
        }

        public int GetMaxBillId()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select MAX(id) from dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        public void checkOut(int id)
        {
            string sql = "Update dbo.Bill set status =1 where id = " + id;
            DataProvider.Instance.ExecuteNonQuery(sql);
        }
    }
}
