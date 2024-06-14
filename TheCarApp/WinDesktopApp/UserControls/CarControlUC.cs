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
using WinDesktopApp.Forms;
using InterfaceLayer;
using Entity_Layer;
using WinDesktopApp.Models;
using WinDesktopApp.UserControls;

namespace DesktopApp
{
    public partial class CarControlUC : UserControl
    {
        IRentManager rentManager;
        ICarManager carManager;
        IExtraManager extraManager;
        IPictureManager pictureManager;
        public AdminInfoUC admInfo { get; set; }
        public RentalsUC rentalsUC { get; set; }

        public CarControlUC(IRentManager rm, ICarManager cm, IExtraManager em, IPictureManager picM)
        {
            InitializeComponent();
            this.rentManager = rm;
            this.carManager = cm;
            this.extraManager = em;
            this.pictureManager = picM;
            InitializeGridView();
            FillDataGridView(carManager.GetCars());
            this.DGVCars.CellPainting += DGVCars_CellPainting;

        }

        private void BTNAddCar_Click(object sender, EventArgs e)
        {
            ICarFormFactory factory = new AddCarFormFactory();
            var addForm = factory.CreateCarForm(null, carManager, extraManager, pictureManager);
            addForm.AddCarClicked += AddCar_CarAdded;
            addForm.ShowForm();
        }

        private void AddCar_CarAdded(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars());
            admInfo.DisplayDataInfo();
        }


        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCarsDESC());
            TBSearchByYear.Clear();
        }

        private void RBDesc_CheckedChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCarsASC());
            TBSearchByYear.Clear();
        }

        private void DGVCars_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGVCars.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var buttonRect = e.CellBounds;
                    var buttonColor = Color.White; 
                    var textColor = Color.Black; 

                    if (e.ColumnIndex == DGVCars.Columns["View"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Modify"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#588157");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Delete"].Index)
                    {
                        buttonColor = ColorTranslator.FromHtml("#3A5A40");
                        textColor = Color.White;
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Change Status"].Index)
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

        

        private void InitializeGridView()
        {
            Font gridFont = new Font("Arial Rounded MT Bold", 10);

            this.DGVCars.ColumnCount = 5;
            this.DGVCars.Columns[0].Name = "Brand";
            this.DGVCars.Columns[0].Width = 100;
            this.DGVCars.Columns[1].Name = "Model";
            this.DGVCars.Columns[1].Width = 100;
            this.DGVCars.Columns[2].Name = "Year";
            this.DGVCars.Columns[2].Width = 80;
            this.DGVCars.Columns[3].Name = "VIN";
            this.DGVCars.Columns[3].Width = 100;
            this.DGVCars.Columns[4].Name = "Status";
            this.DGVCars.Columns[4].Width = 100;

            var btnView = new DataGridViewButtonColumn();
            btnView.Name = "View";
            btnView.HeaderText = "View";
            btnView.Text = "View";
            btnView.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnView);

            var btnModify = new DataGridViewButtonColumn();
            btnModify.Name = "Modify";
            btnModify.HeaderText = "Modify";
            btnModify.Text = "Modify";
            btnModify.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnModify);

            var btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Delete";
            btnDelete.HeaderText = "Delete";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnDelete);

            var btnStatus = new DataGridViewButtonColumn();
            btnStatus.Name = "Change Status";
            btnStatus.HeaderText = "Change Status";
            btnStatus.Text = "Change";
            btnStatus.UseColumnTextForButtonValue = true;
            DGVCars.Columns.Add(btnStatus);

            DGVCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCars.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#344E41");
            DGVCars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVCars.ColumnHeadersDefaultCellStyle.Font = new Font(gridFont, FontStyle.Bold);
            DGVCars.EnableHeadersVisualStyles = false;
            DGVCars.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DGVCars.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#588157");
            DGVCars.DefaultCellStyle.SelectionForeColor = Color.White;
            DGVCars.BackgroundColor = ColorTranslator.FromHtml("#DAD7CD");
            DGVCars.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#A3B18A");
            DGVCars.DefaultCellStyle.Font = gridFont;
            DGVCars.ColumnHeadersDefaultCellStyle.Font = gridFont;
            DGVCars.RowHeadersDefaultCellStyle.Font = gridFont;
        }

        private void FillDataGridView(List<Car> cars)
        {
            this.DGVCars.Rows.Clear();
            foreach (var car in cars)
            {
                this.DGVCars.Rows.Add(car.Brand, car.Model, car.FirstRegistration.ToShortDateString(), car.VIN, car.CarStatus);
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBSearchByYear.Text == "")
                {
                    FillDataGridView(carManager.GetCars());
                }
                else
                {
                    int year = int.Parse(TBSearchByYear.Text);
                    var filteredCars = carManager.GetCars().Where(car => car.FirstRegistration.Year == year).ToList();
                    FillDataGridView(filteredCars);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGVCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var carVIN = DGVCars.Rows[e.RowIndex].Cells["VIN"].Value.ToString();
                var selectedCar = carManager.GetCars().FirstOrDefault(car => car.VIN == carVIN);

                if (selectedCar != null)
                {
                    ICarFormFactory factory = null;

                    if (e.ColumnIndex == DGVCars.Columns["View"].Index)
                    {
                        factory = new ViewCarFormFactory();
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Modify"].Index)
                    {
                        factory = new ModifyCarFormFactory();
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Delete"].Index)
                    {
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to delete that car? If you delete it, it will affect users' rentals.",
                            "Confirmation",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            var rentsToRemove = rentManager.RentalHistory
                                .Where(rent => rent.car.Id == selectedCar.Id)
                                .ToList();

                            foreach (var rent in rentsToRemove)
                            {
                                rentManager.RemoveRent(rent, out string errorMessage);
                            }

                            if (carManager.RemoveCar(selectedCar, out string updateCarError))
                            {
                                MessageBox.Show("Car removed successfully.");
                                FillDataGridView(carManager.GetCars());
                                admInfo.DisplayDataInfo();
                                rentalsUC.FillDataGridView(rentManager.RentalHistory);
                                return;
                            }
                            else
                            {
                                MessageBox.Show($"Failed to update car: {updateCarError}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Deletion canceled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (e.ColumnIndex == DGVCars.Columns["Change Status"].Index)
                    {
                        ChangeCarStatus changeStatus = new ChangeCarStatus(selectedCar, carManager);
                        changeStatus.Show();
                        changeStatus.StatusChanged += ChangeCarStatus_StatusChanged;
                        return;
                    }

                    if (factory != null)
                    {
                        var carForm = factory.CreateCarForm(selectedCar, carManager, extraManager, pictureManager);
                        carForm.AddCarClicked += AddCar_CarAdded;
                        carForm.ShowForm();
                    }
                }
            }
        }


        private void ChangeCarStatus_StatusChanged(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars());
        }

        private void BTNShowAll_Click(object sender, EventArgs e)
        {
            FillDataGridView(carManager.GetCars());
        }
    }
}
