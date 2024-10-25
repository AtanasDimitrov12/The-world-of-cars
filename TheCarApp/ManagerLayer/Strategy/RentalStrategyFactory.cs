using InterfaceLayer;

namespace ManagerLayer.Strategy
{
    public class RentalStrategyFactory : IRentalStrategyFactory
    {
        private IRentalStrategy rentalStrategy;

        public RentalStrategyFactory()
        {

        }

        public IRentalStrategy GetRentalStrategy(DateTime startDate, DateTime endDate)
        {
            if (IsPeakSeason(startDate, endDate))
            {
                rentalStrategy = new PeakSeasonRentalStrategy();
            }
            else
            {
                rentalStrategy = new StandardRentalStrategy();
            }
            return rentalStrategy;
        }

        private static bool IsPeakSeason(DateTime startDate, DateTime endDate)
        {
            // Define peak season logic
            // June to August is peak season
            return startDate.Month >= 6 && startDate.Month <= 8;
        }
    }
}
