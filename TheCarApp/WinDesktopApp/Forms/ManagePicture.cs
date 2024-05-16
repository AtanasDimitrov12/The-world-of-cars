using Entity_Layer;
using EntityLayout;
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
using DesktopApp;

namespace WinDesktopApp.Forms
{
    public partial class AddPicture : Form
    {
        IPictureManager manager;
        public event EventHandler PicAdded;

        public AddPicture(IPictureManager pm)
        {
            InitializeComponent();
            manager = pm;
            InitializeGridView();
            FillDataGridView(manager.pictures);
            this.DGVPictures.CellClick += DGVPictures_CellContentClick;
        }

        private void BTNAddPicture_Click(object sender, EventArgs e)
        {
            Picture pic = new Picture(TBPictureURL.Text);
            string ReturnMessage = manager.AddPicture(pic);
            if (ReturnMessage == "done")
            {
                PicAdded?.Invoke(this, EventArgs.Empty);
                FillDataGridView(manager.pictures);
                TBPictureURL.Clear();
            }
            else { MessageBox.Show(ReturnMessage); }
        }

        private void InitializeGridView()
        {
            this.DGVPictures.ColumnCount = 2;
            this.DGVPictures.Columns[0].Name = "ID";
            this.DGVPictures.Columns[0].Width = 50;
            this.DGVPictures.Columns[1].Name = "PictureURL";
            this.DGVPictures.Columns[1].Width = 150;


            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVPictures.Columns.Add(btnDelete);
        }

        private void FillDataGridView(List<Picture> pics)
        {
            this.DGVPictures.Rows.Clear();
            foreach (var pic in pics)
            {
                this.DGVPictures.Rows.Add(pic.Id, pic.PictureURL);
            }
        }

        private void DGVPictures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVPictures.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var picId = Convert.ToInt32(DGVPictures.Rows[e.RowIndex].Cells["ID"].Value);

                    foreach (var selectedPic in manager.pictures)
                    {
                        if (selectedPic.Id == picId)
                        {
                            manager.RemovePicture(selectedPic);
                            FillDataGridView(manager.pictures);
                            break;
                        }
                    }
                }
            }
        }
    }
}
