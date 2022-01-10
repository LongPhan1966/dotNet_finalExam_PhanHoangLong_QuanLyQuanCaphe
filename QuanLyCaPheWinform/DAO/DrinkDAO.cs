using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    public class DrinkDAO
    {
        private static DrinkDAO instance;

        public static DrinkDAO Instance
        {
            get { if (instance == null) instance = new DrinkDAO(); return DrinkDAO.instance; }
            private set { DrinkDAO.instance = value; }
        }

        private DrinkDAO()
        {

        }

        public List<DrinkDTO> GetListDrinkByCategoryId(int id)
        {
            List<DrinkDTO> list = new List<DrinkDTO>();
            string sql = "select * from Drink where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach(DataRow item in data.Rows)
            {
                DrinkDTO drink = new DrinkDTO(item);
                list.Add(drink);
            }
            return list;
        }
    }
}
