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
using System.Text.RegularExpressions;

namespace WinDesktopApp.Forms
{
    public partial class AddPicture : Form
    {
        IPictureManager manager;
        public event EventHandler PicAdded;
        private string selectedImagePath;

        public AddPicture(IPictureManager pm)
        {
            InitializeComponent();
            manager = pm;
            InitializeGridView();
            FillDataGridView(manager.pictures);
            this.DGVPictures.CellClick += DGVPictures_CellContentClick;
            this.DGVPictures.CellPainting += DGVPictures_CellPainting;
        }

        private void DGVPictures_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVPictures.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; // Default color
                    var textColor = Color.Black; // Default text color


                    if (e.ColumnIndex == DGVPictures.Columns["Delete"].Index)
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


        private void BTNAddPicture_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    var fileName = Path.GetFileName(selectedImagePath);
                    var fileExtension = Path.GetExtension(fileName).ToLower();

                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Only PNG, JPG, and JPEG files are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                    var webAppDirectory = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures");
                    var newImagePath = Path.Combine(webAppDirectory, fileName);

                    try
                    {
                        if (!Directory.Exists(webAppDirectory))
                        {
                            Directory.CreateDirectory(webAppDirectory);
                        }

                        File.Copy(selectedImagePath, newImagePath, true);


                        var relativeFilePath = $"/pictures/News_Pictures/{fileName}";
                        MessageBox.Show($"Image successfully uploaded to: {relativeFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Picture pic = new Picture(fileName);
                        if (manager.AddPicture(pic, out string addPictureError))
                        {
                            pic.Id = manager.GetPicId(pic.PictureURL);
                            PicAdded?.Invoke(this, EventArgs.Empty);
                            FillDataGridView(manager.pictures);
                        }
                        else { MessageBox.Show($"Failed to add picture: {addPictureError}"); }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while uploading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

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

            DGVPictures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVPictures.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVPictures.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVPictures.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVPictures.EnableHeadersVisualStyles = false;
            DGVPictures.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVPictures.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVPictures.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVPictures.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVPictures.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVPictures.DefaultCellStyle.Font = gridFont;
            DGVPictures.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVPictures.RowHeadersDefaultCellStyle.Font = gridFont;
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

                            if (manager.RemovePicture(selectedPic, out string removePictureError))
                            {
                                MessageBox.Show("Picture removed successfully.");
                                FillDataGridView(manager.pictures);
                                break;
                            }
                            else
                            {
                                MessageBox.Show($"Failed to remove picture: {removePictureError}");
                            }
                        }
                    }
                }
            }
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            string url = TBSearch.Text;
            var filteredPics = manager.pictures
                .Where(pic => Regex.IsMatch(pic.PictureURL, Regex.Escape(url), RegexOptions.IgnoreCase))
                .ToList();
            FillDataGridView(filteredPics);
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
