using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Entity_Layer;
using InterfaceLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using System.IO;

namespace DesktopApp
{
    public partial class AddNews : Form
    {
        private string selectedImagePath;
        private CarNews newsData;
        private INewsManager NewsManager;
        public event EventHandler NewsAdded;
        private bool IsView;
        private bool Modify;

        public AddNews(CarNews news, INewsManager newsManager, bool View)
        {
            InitializeComponent();
            newsData = news;
            NewsManager = newsManager;
            this.IsView = View;
            if (newsData != null)
            {
                Modify = true;
                LoadNewsData();
                BTNAdd.Text = "Update News";
                groupBox1.Text = "Update News";
                btnBrowseImage.Text = "Change picture";
            }
            if (View)
            {
                BTNAdd.Enabled = false;
                BTNAdd.Visible = false;
                btnBrowseImage.Enabled = false;
                btnBrowseImage.Visible = false;
            }
        }

        private void LoadNewsData()
        {
            TBNewsTitle.Text = newsData.Title;
            TBNewsAuthor.Text = newsData.Author;
            RTBNewsIntro.Text = newsData.ShortIntro;
            RTBNewsDescription.Text = newsData.NewsDescription;

            ClearPictureBoxImage();

            try
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                var imagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", newsData.ImageURL);

                if (File.Exists(imagePath))
                {
                    using (var imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxNewsImage.Image = Image.FromStream(imgStream);
                    }
                }
                else
                {
                    MessageBox.Show($"Image file not found: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearPictureBoxImage()
        {
            if (pictureBoxNewsImage.Image != null)
            {
                pictureBoxNewsImage.Image.Dispose();
                pictureBoxNewsImage.Image = null;
            }
        }

        private bool AreFieldsNotEmpty()
        {
            if (string.IsNullOrEmpty(TBNewsTitle.Text) ||
                string.IsNullOrEmpty(TBNewsAuthor.Text) ||
                string.IsNullOrEmpty(RTBNewsIntro.Text) ||
                string.IsNullOrEmpty(RTBNewsDescription.Text) ||
                pictureBoxNewsImage.Image == null)
            {
                MessageBox.Show("All fields must be filled out, and an image must be selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if (!AreFieldsNotEmpty())
            {
                return;
            }

            if (!Modify && !IsView)
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    string fileName = Path.GetFileName(selectedImagePath);

                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                    var newImagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", fileName);


                    CarNews news = new CarNews(RTBNewsDescription.Text, dateTime, fileName, TBNewsTitle.Text, TBNewsAuthor.Text, RTBNewsIntro.Text);
                    if (NewsManager.AddNews(news, out string addNewsError))
                    {
                        MessageBox.Show("You successfully added this news!");
                        NewsAdded?.Invoke(this, EventArgs.Empty);
                        ClearPictureBoxImage();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add news: {addNewsError}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"You need first to properly add picture. " + ex.Message);
                }

            }
            else if (Modify == true)
            {
                string fileName = null;

                bool hasChanged = false;

                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    fileName = Path.GetFileName(selectedImagePath);
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                    var newImagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", fileName);

                    if (selectedImagePath != null && File.Exists(selectedImagePath))
                    {
                        File.Copy(selectedImagePath, newImagePath, true);
                        hasChanged = true;
                    }
                }
                else
                {
                    fileName = newsData.ImageURL;
                }

                if (TBNewsAuthor.Text != newsData.Author ||
                    TBNewsTitle.Text != newsData.Title ||
                    RTBNewsIntro.Text != newsData.ShortIntro ||
                    RTBNewsDescription.Text != newsData.NewsDescription ||
                    fileName != newsData.ImageURL)
                {
                    hasChanged = true;
                }

                if (hasChanged)
                {
                    newsData.Author = TBNewsAuthor.Text;
                    newsData.Title = TBNewsTitle.Text;
                    newsData.ShortIntro = RTBNewsIntro.Text;
                    newsData.NewsDescription = RTBNewsDescription.Text;
                    newsData.ImageURL = fileName;
                    if (NewsManager.UpdateNews(newsData, out string updateNewsError))
                    {
                        MessageBox.Show("You successfully updated this news!");
                        NewsAdded?.Invoke(this, EventArgs.Empty);
                        ClearPictureBoxImage();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to update news: {updateNewsError}");
                    }
                }
                else
                {
                    MessageBox.Show("No changes were made to the news item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show(
                        "Do you want to close the form?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        ClearPictureBoxImage();
                        this.Close();
                    }
                }
            }
        }

        private void TBNewsTitle_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 50;
            if (TBNewsTitle.Text.Length > maxLength)
            {
                MessageBox.Show("Input is too long. Please enter a maximum of 50 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNewsTitle.Text = TBNewsTitle.Text.Substring(0, maxLength);
                TBNewsTitle.SelectionStart = TBNewsTitle.Text.Length;
            }
        }

        private void TBNewsAuthor_TextChanged_1(object sender, EventArgs e)
        {
            const int maxLength = 50;
            if (TBNewsAuthor.Text.Length > maxLength)
            {
                MessageBox.Show("Input is too long. Please enter a maximum of 50 characters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNewsAuthor.Text = TBNewsAuthor.Text.Substring(0, maxLength);
                TBNewsAuthor.SelectionStart = TBNewsAuthor.Text.Length;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
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
                    var webAppDirectory = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures");
                    var newImagePath = Path.Combine(webAppDirectory, fileName);

                    try
                    {
                        if (!Directory.Exists(webAppDirectory))
                        {
                            Directory.CreateDirectory(webAppDirectory);
                        }

                        File.Copy(selectedImagePath, newImagePath, true);

                        pictureBoxNewsImage.Image = Image.FromFile(newImagePath);

                        var relativeFilePath = $"/pictures/News_Pictures/{fileName}";
                        MessageBox.Show($"Image successfully uploaded to: {relativeFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while uploading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pictureBoxNewsImage_Click(object sender, EventArgs e)
        {

        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
