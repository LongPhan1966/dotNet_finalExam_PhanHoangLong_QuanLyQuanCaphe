using QuanLyCaPheWinform.DAO;
using QuanLyCaPheWinform.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCaPheWinform
{
    public partial class FrmManager1 : Form
    {
        public FrmManager1()
        {
            InitializeComponent();

            loadTable();
            loadCategory();
        }

        #region Method

            void loadCategory()
            {
                List<CategoryDTO> category = CategoryDAO.Instance.GetCategory();
                cbCategory.DataSource = category;
                cbCategory.DisplayMember = "Name";
            }

            void loadDrinkByCategory(int id)
            {
                List<DrinkDTO> drink = DrinkDAO.Instance.GetListDrinkByCategoryId(id);
                cbDrink.DataSource = drink;
                cbDrink.DisplayMember = "Name";
            }
            void loadTable()
            {
                List<TableDTO> tableList = TableDAO.Instance.LoadTableList();

                foreach(TableDTO item in tableList)
                {
                    Button btn = new Button() { Width = TableDAO.Width, Height = TableDAO.Height };

                    btn.Text = item.Name + Environment.NewLine + item.Status;
                    btn.Click += Btn_Click;
                    btn.Tag = item;
                    if(item.Status == "Trống")
                    {
                        btn.BackColor = Color.Green;
                    }
                    else
                    {
                        btn.BackColor = Color.OrangeRed;
                    }

                    flpTable.Controls.Add(btn);
                }

            }

        void ShowBill(int id)
        {
            lvBill.Items.Clear();
            float Total = 0;
            List<MenuDTO> list = MenuDAO.Instance.GetMenuByTable(id);
            foreach (MenuDTO item in list)
            {
                ListViewItem lsvi = new ListViewItem(item.DrinkName.ToString());
                lsvi.SubItems.Add(item.Count.ToString());
                lsvi.SubItems.Add(item.Price.ToString());
                lsvi.SubItems.Add(item.Total.ToString());
                Total += item.Total;
                lvBill.Items.Add(lsvi);
            }
            txbTotal.Text = Total.ToString();
        }
        #endregion



        #region Event
        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as TableDTO).Id;
            lvBill.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
            {
                return;
            }
            CategoryDTO selected = cb.SelectedItem as CategoryDTO;
            id = selected.Id;
            loadDrinkByCategory(id);
        }
        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            TableDTO table = lvBill.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
            int drinkid = (cbDrink.SelectedItem as DrinkDTO).Id;
            int count = (int)txtCount.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);
                CTBillDAO.Instance.InsertCTBill(BillDAO.Instance.GetMaxBillId(), drinkid, count);
            }
            else
            {
                CTBillDAO.Instance.InsertCTBill(idBill, drinkid, count);
            }

            ShowBill(table.Id);
        }
        //Chức năng thanh toán
        private void button2_Click(object sender, EventArgs e)
        {
            TableDTO table = lvBill.Tag as TableDTO;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);

            if(idBill != -1)
            {
                if(MessageBox.Show("Thanh toán cho bàn "+ table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.checkOut(idBill);
                    ShowBill(table.Id);
                }
            }

        }


        #endregion

        private void FrmManager1_Load(object sender, EventArgs e)
        {

        }
    }
}
