using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DTO
{
    public class CategoryDTO
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public CategoryDTO(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public CategoryDTO() { }

        public CategoryDTO(DataRow row)
        {
            this.Id= (int)row[0];
            this.Name = row[1].ToString();

        }
    }
}
