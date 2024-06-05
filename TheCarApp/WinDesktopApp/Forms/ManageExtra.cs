using Entity_Layer;
using Manager_Layer;
using ManagerLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceLayer;

namespace WinDesktopApp.Forms
{
    public partial class AddExtra : Form
    {
        IExtraManager manager;
        public event EventHandler ExtraAdded;

        public AddExtra(IExtraManager em)
        {
            InitializeComponent();
            manager = em;
            InitializeGridView();
            FillDataGridView(manager.extras);
            this.DGVExtras.CellClick += DGVExtras_CellContentClick;
        }

        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            Extra extra = new Extra(RTBExtraName.Text);
            string ReturnMessage = manager.AddExtra(extra);
            extra.Id = manager.GetExtraId(extra.ExtraName);
            if (ReturnMessage == "done")
            {
                ExtraAdded?.Invoke(this, EventArgs.Empty);
                FillDataGridView(manager.extras);
                RTBExtraName.Clear();   
            }
            else { MessageBox.Show(ReturnMessage); }
        }

        private void InitializeGridView()
        {
            this.DGVExtras.ColumnCount = 2;
            this.DGVExtras.Columns[0].Name = "ID";
            this.DGVExtras.Columns[0].Width = 50;
            this.DGVExtras.Columns[1].Name = "Extra";
            this.DGVExtras.Columns[1].Width = 150;


            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVExtras.Columns.Add(btnDelete);
        }

        private void FillDataGridView(List<Extra> extras)
        {
            this.DGVExtras.Rows.Clear();
            foreach (var extra in extras)
            {
                this.DGVExtras.Rows.Add(extra.Id, extra.ExtraName);
            }
        }

        private void DGVExtras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVExtras.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var extraId = Convert.ToInt32(DGVExtras.Rows[e.RowIndex].Cells["ID"].Value);

                    foreach (var selectedExtras in manager.extras)
                    {
                        if (selectedExtras.Id == extraId)
                        {
                            manager.RemoveExtra(selectedExtras);
                            FillDataGridView(manager.extras);
                            break;
                        }
                    }
                }
            }
        }
    }
}
