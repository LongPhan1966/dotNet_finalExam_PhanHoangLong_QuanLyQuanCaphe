using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DTO
{
    public class DrinkDTO
    {
        private int id;
        private string name;
        private int idCategory;
        private float price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public float Price { get => price; set => price = value; }

        public DrinkDTO(int id, string name, int idcategory, float price)
        {
            this.Id = id;
            this.Name = name;
            this.IdCategory = idcategory;
            this.Price = price;
        }

        public DrinkDTO() { }

        public DrinkDTO(DataRow row)
        {
            this.Id = (int)row[0];
            this.Name = row[1].ToString();
            this.IdCategory = (int)row[2];
            this.Price = (float)Convert.ToDouble(row[3].ToString());
        }
    }
}
