using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    public class CTBillDAO
    {
        private static CTBillDAO instance;

        public static CTBillDAO Instance
        {
            get { if (instance == null) instance = new CTBillDAO(); return CTBillDAO.instance; }
            private set { CTBillDAO.instance = value; }
        }

        private CTBillDAO()
        {

        }

        public List<CTBillDTO> GetListChiTietBill(int id)
        {
            List<CTBillDTO> list = new List<CTBillDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from BillInfo where idBill = " + id);

            foreach(DataRow item in data.Rows)
            {
                CTBillDTO ctb = new CTBillDTO(item);
                list.Add(ctb);
            }
            return list;
        }

        public void InsertCTBill(int idBill,int idDrink, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("InsertCTBill @idBill , @idDrink , @count", new object[] { idBill, idDrink, count });
        }
    }
}
