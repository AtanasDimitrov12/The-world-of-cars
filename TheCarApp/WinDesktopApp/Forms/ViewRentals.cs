using DTO;
using DTO.Enums;
using InterfaceLayer;


namespace WinDesktopApp.Forms
{
    public partial class ViewRentals : Form
    {
        RentACarDTO rent;
        IRentManager manager;
        ICarManager carManager;
        IUserManager userManager;
        bool IsView;
        private bool isInitializing = true; 

        public event EventHandler RentChanged;

        public ViewRentals(RentACarDTO rent, IRentManager rm, bool View, ICarManager cm, IUserManager um)
        {
            InitializeComponent();
            this.rent = rent;
            manager = rm;
            IsView = View;
            carManager = cm;
            userManager = um;
            DisplayRentInfo(rent, View);
            CheckForView();
            isInitializing = false; 
        }

        public void CheckForView()
        {
            if (IsView)
            {
                BTNClose.Location = new Point(450, 294);
                BTNUpdate.Visible = false;
                BTNUpdate.Enabled = false;
            }
        }

        public void DisplayRentInfo(RentACarDTO rent, bool View)
        {
            TBUsername.Text = userManager.GetUserNameById(rent.UserId);
            TBCar.Text = $"{carManager.SearchForCar(rent.CarId).Brand} {carManager.SearchForCar(rent.CarId).Model}";
            DTPStartDate.Value = rent.StartDate;
            DTPEndDate.Value = rent.EndDate;
            TBTotalPrice.Text = rent.TotalPrice.ToString();
            TBCar.Enabled = false;
            TBUsername.Enabled = false;
            TBTotalPrice.Enabled = false;
            if (IsView)
            {
                TBRentStatus.Text = rent.Status.ToString();
                CBRentStatus.Visible = false;
                CBRentStatus.Enabled = false;
                DTPStartDate.Enabled = false;
                DTPEndDate.Enabled = false;
                TBRentStatus.Enabled = false;
                BTNUpdate.Text = "Close";
            }
            else
            {
                foreach (var status in Enum.GetValues(typeof(RentStatus)))
                {
                    CBRentStatus.Items.Add(status.ToString().ToLower());
                }
                TBRentStatus.Enabled = false;
                TBRentStatus.Visible = false;
            }
        }

        private async void BTNUpdate_Click(object sender, EventArgs e)
        {
            if (CBRentStatus.SelectedItem != null)
            {
                RentStatus newStatus;
                if (Enum.TryParse<RentStatus>(CBRentStatus.Text, true, out newStatus))
                {
                    rent.StartDate = DTPStartDate.Value;
                    rent.EndDate = DTPEndDate.Value;
                    rent.TotalPrice = manager.CalculatePrice(userManager.FindUserById(rent.UserId), carManager.SearchForCar(rent.CarId).PricePerDay, DTPStartDate.Value, DTPEndDate.Value);

                    (bool Response, string ErrorMessage) = await manager.UpdateRentStatusAsync(rent, newStatus);
                    if (Response)
                    {
                        RentChanged?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(ErrorMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please first select Rent Status first!");
            }
        }

        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DTPStartDate_ValueChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                CalculateTotalPrice();
            }
        }

        private void DTPEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (!isInitializing)
            {
                CalculateTotalPrice();
            }
        }

        public void CalculateTotalPrice()
        {
            if (DTPEndDate.Value <= DTPStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                TBTotalPrice.Text = manager.CalculatePrice(userManager.FindUserById(rent.UserId), carManager.SearchForCar(rent.CarId).PricePerDay, DTPStartDate.Value, DTPEndDate.Value).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in OnPostCalculatePrice: " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
