using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO()
        {

        }

        public List<CategoryDTO> GetCategory()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();

            string sql = "select * from dbo.Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            foreach(DataRow item in data.Rows)
            {
                CategoryDTO category = new CategoryDTO(item);
                list.Add(category);
            }
            return list;
        }
    }
}
