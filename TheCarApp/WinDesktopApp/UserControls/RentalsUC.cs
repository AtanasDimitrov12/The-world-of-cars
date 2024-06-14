using DesktopApp;
using Entity_Layer;
using InterfaceLayer;
using Manager_Layer;
using ManagerLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDesktopApp.Forms;

namespace WinDesktopApp.UserControls
{
    public partial class RentalsUC : UserControl
    {
        IPeopleManager peopleManager;
        IRentManager rentManager;
        public RentalsUC(IPeopleManager pm, IRentManager rentManager)
        {
            InitializeComponent();
            peopleManager = pm;
            this.rentManager = rentManager;
            InitializeGridView();
            FillDataGridView(rentManager.RentalHistory);
            UpdateRequestedLabel();
            this.DGVRentals.CellPainting += DGVRentals_CellPainting;
        }

        private void UpdateRequestedLabel()
        {
            int RequestedRentals = rentManager.RentalHistory.Where(r => r.RentStatus == Entity_Layer.Enums.RentStatus.REQUESTED).Count();
            TBRents.Text = RequestedRentals.ToString();
            TBRents.Enabled = false;
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

            this.DGVRentals.ColumnCount = 6;
            this.DGVRentals.Columns[0].Name = "Username";
            this.DGVRentals.Columns[0].Width = 100;
            this.DGVRentals.Columns[1].Name = "Car";
            this.DGVRentals.Columns[1].Width = 100;
            this.DGVRentals.Columns[2].Name = "Start Date";
            this.DGVRentals.Columns[2].Width = 100;
            this.DGVRentals.Columns[3].Name = "End Date";
            this.DGVRentals.Columns[3].Width = 100;
            this.DGVRentals.Columns[4].Name = "Total Price";
            this.DGVRentals.Columns[4].Width = 50;
            this.DGVRentals.Columns[5].Name = "Status";
            this.DGVRentals.Columns[5].Width = 100;

            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnView);

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";
            btnModify.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnModify);

            var btnRemove = new DataGridViewButtonColumn();
            btnRemove.Name = "Remove";
            btnRemove.HeaderText = "Remove";
            btnRemove.Text = "Remove";
            btnRemove.UseColumnTextForButtonValue = true;
            DGVRentals.Columns.Add(btnRemove);

            DGVRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVRentals.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVRentals.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVRentals.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVRentals.EnableHeadersVisualStyles = false;
            DGVRentals.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVRentals.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVRentals.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVRentals.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVRentals.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVRentals.DefaultCellStyle.Font = gridFont;
            DGVRentals.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVRentals.RowHeadersDefaultCellStyle.Font = gridFont;

        }

        private void DGVRentals_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVRentals.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; 
                    var textColor = Color.Black; 

                    if (e.ColumnIndex == DGVRentals.Columns["View"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVRentals.Columns["Modify"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#588157");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVRentals.Columns["Remove"].Index)
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

        public void FillDataGridView(List<RentACar> rentals)
        {
            this.DGVRentals.Rows.Clear();

            foreach (var rent in rentals)
            {
                string Car = $"{rent.car.Brand} {rent.car.Model}";
                this.DGVRentals.Rows.Add(rent.user.Username, Car, rent.StartDate.ToShortDateString(), rent.ReturnDate.ToShortDateString(), rent.TotalPrice, rent.RentStatus);

            }
        }

        private void LBLAdminUsername_Click(object sender, EventArgs e)
        {

        }

        private void TBNewsTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNSearchByUsername_Click(object sender, EventArgs e)
        {
            string Username = TBUsername.Text;
            var filteredRentals = rentManager.RentalHistory
                .Where(rent => Regex.IsMatch(rent.user.Username, Regex.Escape(Username), RegexOptions.IgnoreCase))
                .ToList();
            FillDataGridView(filteredRentals);
        }

        private void RBASC_CheckedChanged(object sender, EventArgs e)
        {
            List<RentACar> rentals = rentManager.RentalHistory;
            rentals = rentals.OrderBy(r => r.StartDate).ToList();
            FillDataGridView(rentals);
        }

        private void RBDESC_CheckedChanged(object sender, EventArgs e)
        {
            List<RentACar> rentals = rentManager.RentalHistory;
            rentals = rentals.OrderByDescending(r => r.StartDate).ToList();
            FillDataGridView(rentals);
        }

        
        private void BTNCheckRentals_Click(object sender, EventArgs e)
        {
            RequestedRentsUC checkRentals = new RequestedRentsUC(rentManager);
            checkRentals.RentChanged += ChangeRent_RentChanged;
            checkRentals.Show();
        }

        private void ChangeRent_RentChanged(object sender, EventArgs e)
        {
            FillDataGridView(rentManager.RentalHistory);
            UpdateRequestedLabel();
        }

        private void DGVRentals_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var Username = DGVRentals.Rows[e.RowIndex].Cells["Username"].Value?.ToString();
            var StartDateString = DGVRentals.Rows[e.RowIndex].Cells["Start Date"].Value?.ToString();
            var car = DGVRentals.Rows[e.RowIndex].Cells["Car"].Value?.ToString();

            if (Username == null || StartDateString == null || car == null)
            {
                return;
            }

            if (e.ColumnIndex == DGVRentals.Columns["View"].Index)
            {
                foreach (var selectedRental in rentManager.RentalHistory)
                {
                    if (selectedRental?.user?.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car?.Brand} {selectedRental.car?.Model}" == car)
                    {
                        ViewRentals viewRent = new ViewRentals(selectedRental, rentManager, true);
                        viewRent.Show();
                        break;
                    }
                }
            }
            else if (e.ColumnIndex == DGVRentals.Columns["Modify"].Index)
            {
                foreach (var selectedRental in rentManager.RentalHistory)
                {
                    if (selectedRental?.user?.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car?.Brand} {selectedRental.car?.Model}" == car)
                    {
                        ViewRentals modifyRent = new ViewRentals(selectedRental, rentManager, false);
                        modifyRent.RentChanged += ChangeRent_RentChanged;
                        modifyRent.Show();
                        UpdateRequestedLabel();
                        break;
                    }
                }
            }
            else if (e.ColumnIndex == DGVRentals.Columns["Remove"].Index)
            {
                foreach (var selectedRental in rentManager.RentalHistory)
                {
                    if (selectedRental?.user?.Username == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{selectedRental.car?.Brand} {selectedRental.car?.Model}" == car)
                    {
                        if (rentManager.RemoveRent(selectedRental, out string ErrorMessage))
                        {
                            FillDataGridView(rentManager.RentalHistory);
                            break;
                        }
                        else
                        {
                            MessageBox.Show(ErrorMessage);
                        }
                    }
                }
            }
            
        }

    }
}
