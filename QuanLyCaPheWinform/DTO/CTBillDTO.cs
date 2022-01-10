using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCaPheWinform.DTO
{
    public class CTBillDTO
    {
        private int id;
        private int billId;
        private int drinkId;
        private int count;

        public int Id { get => id; set => id = value; }
        public int BillId { get => billId; set => billId = value; }
        public int DrinkId { get => drinkId; set => drinkId = value; }
        public int Count { get => count; set => count = value; }

        public CTBillDTO(int id, int billId, int drinkId, int count)
        {
            this.Id = id;
            this.BillId= billId;
            this.DrinkId= drinkId;
            this.Count = count;
        }

        public CTBillDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.BillId = (int)row["idBill"];
            this.DrinkId = (int)row["idDrink"];
            this.Count = (int)row["count"];
        }
    }
}
