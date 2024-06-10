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
                BTNAdd.Text = "Update Car";
            }
            if (View)
            {
                BTNAdd.Text = "Close";
            }
        }

        private void LoadNewsData()
        {
            TBNewsTitle.Text = newsData.Title;
            TBNewsAuthor.Text = newsData.Author;
            RTBNewsIntro.Text = newsData.ShortIntro;
            RTBNewsDescription.Text = newsData.NewsDescription;

            // Clear the existing image from the PictureBox
            ClearPictureBoxImage(pictureBoxNewsImage);

            try
            {
                // Get the base directory of the application
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // Navigate up to the root directory of the project
                var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                // Combine the project root directory with the relative path to the News_Pictures folder
                var imagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", newsData.ImageURL);

                if (File.Exists(imagePath))
                {
                    pictureBoxNewsImage.Image = Image.FromFile(imagePath);
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

        // Method to clear the PictureBox image
        private void ClearPictureBoxImage(PictureBox pictureBox)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
        }




        private void BTNAdd_Click(object sender, EventArgs e)
        {
            if (!Modify && !IsView)
            {
                DateTime dateTime = DateTime.Now;
                string fileName = Path.GetFileName(selectedImagePath);

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                var newImagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", fileName);


                CarNews news = new CarNews(RTBNewsDescription.Text, dateTime, fileName, TBNewsTitle.Text, TBNewsAuthor.Text, RTBNewsIntro.Text);
                string ReturnMessage = NewsManager.AddNews(news);
                if (ReturnMessage == "done")
                {
                    MessageBox.Show("You successfully added this news!");
                    NewsAdded?.Invoke(this, EventArgs.Empty);
                    ClearPictureBoxImage(pictureBoxNewsImage);
                    this.Close();
                }
                else { MessageBox.Show(ReturnMessage); }
            }
            else if (IsView)
            {
                ClearPictureBoxImage(pictureBoxNewsImage);
                this.Close();
            }
            else if (Modify == true)
            {
                string fileName = Path.GetFileName(selectedImagePath);

                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                var newImagePath = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures", fileName);


                newsData.Author = TBNewsAuthor.Text;
                newsData.Title = TBNewsTitle.Text;
                newsData.ShortIntro = RTBNewsIntro.Text;
                newsData.NewsDescription = RTBNewsDescription.Text;
                newsData.ImageURL = fileName;
                string ReturnMessage = NewsManager.UpdateNews(newsData);
                if (ReturnMessage == "done")
                {
                    MessageBox.Show("You successfully updated this news!");
                    NewsAdded?.Invoke(this, EventArgs.Empty);
                    ClearPictureBoxImage(pictureBoxNewsImage);
                    this.Close();
                }
                else { MessageBox.Show(ReturnMessage); }
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

                    // Check if the file is of the allowed types
                    var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        MessageBox.Show("Only PNG, JPG, and JPEG files are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Get the base directory of the application
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    // Navigate up to the root directory of the project
                    var projectRootDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\..\.."));
                    // Combine the project root directory with the relative path to the News_Pictures folder
                    var webAppDirectory = Path.Combine(projectRootDirectory, "TheCarApp", "TheCarApp", "wwwroot", "pictures", "News_Pictures");
                    var newImagePath = Path.Combine(webAppDirectory, fileName);

                    // Print the path to verify
                    Console.WriteLine(newImagePath);  // This will show the correct single backslash path

                    try
                    {
                        // Ensure the directory exists
                        if (!Directory.Exists(webAppDirectory))
                        {
                            Directory.CreateDirectory(webAppDirectory);
                        }

                        // Copy the file to the new path
                        File.Copy(selectedImagePath, newImagePath, true);

                        // Display the image in the PictureBox
                        pictureBoxNewsImage.Image = Image.FromFile(newImagePath);

                        // Optionally, you can store the relative path if needed
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


    }
}
