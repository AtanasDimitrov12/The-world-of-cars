using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Enums;
using DTO.Interfaces;
using InterfaceLayer;
using Manager_Layer;
using DTO;

namespace WinDesktopApp.Forms
{
    public partial class RequestedRentsUC : Form
    {
        IRentManager rentManager;
        ICarManager carManager;
        IUserManager userManager;
        List<RentACarDTO> rentals;
        public event EventHandler RentChanged;
        public RequestedRentsUC(IRentManager rm, ICarManager cm, IUserManager um)
        {
            InitializeComponent();
            rentManager = rm;
            carManager = cm;
            userManager = um;
            InitializeGridView();
            UpdateDGV();
            this.DGVRequestRents.CellPainting += DGVRequestRents_CellPainting;
        }

        private void UpdateDGV()
        {
            rentals = rentManager.RentalHistory.Where(rent => rent.Status == RentStatus.REQUESTED.ToString()).ToList();
            FillDataGridView(rentals);
        }

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

            this.DGVRequestRents.ColumnCount = 6;
            this.DGVRequestRents.Columns[0].Name = "Username";
            this.DGVRequestRents.Columns[0].Width = 100;
            this.DGVRequestRents.Columns[1].Name = "Car";
            this.DGVRequestRents.Columns[1].Width = 100;
            this.DGVRequestRents.Columns[2].Name = "Start Date";
            this.DGVRequestRents.Columns[2].Width = 100;
            this.DGVRequestRents.Columns[3].Name = "End Date";
            this.DGVRequestRents.Columns[3].Width = 100;
            this.DGVRequestRents.Columns[4].Name = "Total Price";
            this.DGVRequestRents.Columns[4].Width = 50;
            this.DGVRequestRents.Columns[5].Name = "Status";
            this.DGVRequestRents.Columns[5].Width = 100;


            var btnApprove = new DataGridViewButtonColumn();
            btnApprove.Name = "Approve";
            btnApprove.HeaderText = "Approve";
            btnApprove.Text = "Approve";
            btnApprove.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnApprove);


            var btnCancel = new DataGridViewButtonColumn();
            btnCancel.Name = "Cancel";
            btnCancel.HeaderText = "Cancel";
            btnCancel.Text = "Cancel";
            btnCancel.UseColumnTextForButtonValue = true;
            DGVRequestRents.Columns.Add(btnCancel);

            DGVRequestRents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVRequestRents.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVRequestRents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVRequestRents.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVRequestRents.EnableHeadersVisualStyles = false;
            DGVRequestRents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVRequestRents.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVRequestRents.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVRequestRents.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVRequestRents.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVRequestRents.DefaultCellStyle.Font = gridFont;
            DGVRequestRents.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVRequestRents.RowHeadersDefaultCellStyle.Font = gridFont;
        }

        private void DGVRequestRents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVRequestRents.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; // Default color
                    var textColor = Color.Black; // Default text color

                    if (e.ColumnIndex == DGVRequestRents.Columns["Approve"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        //buttonColor = ColorTranslator.FromHtml("#588157");
                        textColor = Color.White;
                        //buttonColor = ColorTranslator.FromHtml("#A3B18A");
                    }
                    else if (e.ColumnIndex == DGVRequestRents.Columns["Cancel"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#588157");
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

        private void FillDataGridView(List<RentACarDTO> rentals)
        {
            this.DGVRequestRents.Rows.Clear();

            foreach (var rent in rentals)
            {
                string Car = $"{carManager.SearchForCar(rent.CarId).Brand} {carManager.SearchForCar(rent.CarId).Model}";
                this.DGVRequestRents.Rows.Add(userManager.GetUserNameById(rent.UserId), Car, rent.StartDate.ToShortDateString(), rent.EndDate.ToShortDateString(), rent.TotalPrice, rent.Status);

            }
        }



        private async void DGVRequestRents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVRequestRents.Columns["Approve"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {

                    var Username = DGVRequestRents.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRequestRents.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRequestRents.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.RentalHistory)
                    {
                        if (userManager.GetUserNameById(selectedRental.UserId) == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{carManager.SearchForCar(selectedRental.CarId).Brand} {carManager.SearchForCar(selectedRental.CarId).Model}" == car)
                        {
                            (bool Response, string errorMessage) = await rentManager.UpdateRentStatusAsync(selectedRental, RentStatus.SCHEDULE);
                            if (Response)
                            {
                                RentChanged?.Invoke(this, EventArgs.Empty);
                                UpdateDGV();
                                break;
                            }
                            else
                            {
                                MessageBox.Show(errorMessage);
                            }
                        }
                    }
                }
            }

            if (e.ColumnIndex == DGVRequestRents.Columns["Cancel"].Index && e.RowIndex >= 0)
            {
                if (e.RowIndex != -1)
                {
                    var Username = DGVRequestRents.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                    var StartDateString = DGVRequestRents.Rows[e.RowIndex].Cells["Start Date"].Value.ToString();
                    var car = DGVRequestRents.Rows[e.RowIndex].Cells["Car"].Value.ToString();

                    foreach (var selectedRental in rentManager.RentalHistory)
                    {
                        if (userManager.GetUserNameById(selectedRental.UserId) == Username && selectedRental.StartDate.ToShortDateString() == StartDateString && $"{carManager.SearchForCar(selectedRental.CarId).Brand}   {carManager.SearchForCar(selectedRental.CarId).Model}" == car)
                        {
                            (bool Response, string errorMessage) = await rentManager.UpdateRentStatusAsync(selectedRental, RentStatus.CANCELLED);
                            if (Response)
                            {
                                RentChanged?.Invoke(this, EventArgs.Empty);
                                UpdateDGV();
                                break;
                            }
                            else
                            {
                                MessageBox.Show(errorMessage);
                            }
                        }
                    }
                }
            }
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
