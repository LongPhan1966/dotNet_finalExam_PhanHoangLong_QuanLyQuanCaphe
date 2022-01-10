using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        private TableDAO()
        {

        }

        public static int Width = 110;
        public static int Height = 110;


        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> ds = new List<TableDTO>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec dbo.USP_GetTableById ");

            foreach(DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                ds.Add(table);
            }

            return ds;
        }
    }
}
