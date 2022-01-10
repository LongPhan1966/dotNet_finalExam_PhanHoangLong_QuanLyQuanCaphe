using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DTO
{
    public class MenuDTO
    {
        private string drinkName;
        private int count;
        private float price;
        private float total;

        public string DrinkName { get => drinkName; set => drinkName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float Total { get => total; set => total = value; }

        public MenuDTO(string drinkname, int count, float price, float total = 0)
        {
            this.DrinkName = drinkname;
            this.Count = count;
            this.Price = price;
            this.Total = total;
        }
        public MenuDTO() { }

        public MenuDTO(DataRow row)
        {
            this.DrinkName = row[0].ToString();
            this.Count = (int)row[1];
            this.Price = (float)Convert.ToDouble(row[2].ToString());
            this.Total = (float)Convert.ToDouble(row[3].ToString());
        }
    }
}
