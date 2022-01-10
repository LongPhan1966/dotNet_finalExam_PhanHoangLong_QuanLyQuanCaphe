using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO()
        {

        }

        public List<MenuDTO> GetMenuByTable(int id)
        {
            List<MenuDTO> listMenu = new List<MenuDTO>();

            string query = "select d.name,bi.count, d.price, d.price*bi.count as 'Total' from BillInfo as bi inner join Bill as b on bi.idBill = b.id inner join Drink as d on bi.idDrink = d.id where bi.idBill = b.id and bi.idDrink = d.id and b.idTable = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                MenuDTO menu = new MenuDTO(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
