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
using System.Text.RegularExpressions;

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
            this.DGVExtras.CellPainting += DGVExtras_CellPainting;
        }

        private void DGVExtras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVExtras.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White;
                    var textColor = Color.Black;


                    if (e.ColumnIndex == DGVExtras.Columns["Delete"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        textColor = Color.White;
                    }

                    var adjustedRect = new Rectangle(buttonRect.X + 1, buttonRect.Y + 1, buttonRect.Width - 2, buttonRect.Height - 2);

                    using (Brush brush = new SolidBrush(buttonColor))
                    {
                        e.Graphics.FillRectangle(brush, adjustedRect);
                    }

                    var buttonText = (string)e.FormattedValue;
                    var textSize = TextRenderer.MeasureText(buttonText, e.CellStyle.Font);
                    var textLocation = new Point(
                        e.CellBounds.Left + (e.CellBounds.Width - textSize.Width) / 2,
                        e.CellBounds.Top + (e.CellBounds.Height - textSize.Height) / 2);

                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, textLocation, textColor);

                    e.Graphics.DrawRectangle(Pens.Black, adjustedRect);

                    if ((e.State & DataGridViewElementStates.Selected) != 0 || (e.State & DataGridViewElementStates.Displayed) != 0)
                    {
                        var hoverRect = new Rectangle(adjustedRect.X - 1, adjustedRect.Y - 1, adjustedRect.Width + 2, adjustedRect.Height + 2);
                        e.Graphics.DrawRectangle(Pens.DarkGray, hoverRect);
                    }

                    e.Handled = true;
                }
            }
        }


        private void BTNAddExtra_Click(object sender, EventArgs e)
        {
            Extra extra = new Extra(RTBExtraName.Text);
            if (manager.AddExtra(extra, out string addExtraError))
            {
                extra.Id = manager.GetExtraId(extra.ExtraName);

                ExtraAdded?.Invoke(this, EventArgs.Empty);
                FillDataGridView(manager.extras);
                RTBExtraName.Clear();
            }
            else
            {
                MessageBox.Show($"Failed to add extra: {addExtraError}");
            }
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

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

            DGVExtras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVExtras.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVExtras.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVExtras.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVExtras.EnableHeadersVisualStyles = false;
            DGVExtras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVExtras.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVExtras.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVExtras.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVExtras.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVExtras.DefaultCellStyle.Font = gridFont;
            DGVExtras.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVExtras.RowHeadersDefaultCellStyle.Font = gridFont;
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
                            if (manager.RemoveExtra(selectedExtras, out string removeExtraError))
                            {
                                FillDataGridView(manager.extras);
                                break;
                            }
                            else
                            {
                                MessageBox.Show($"Failed to remove extra: {removeExtraError}");
                            }
                        }
                    }
                }
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            string extraName = TBSearch.Text;
            var filteredExtras = manager.extras
                .Where(extra => Regex.IsMatch(extra.ExtraName, Regex.Escape(extraName), RegexOptions.IgnoreCase))
                .ToList();
            FillDataGridView(filteredExtras);
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
