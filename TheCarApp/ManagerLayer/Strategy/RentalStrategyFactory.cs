using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Strategy
{
    public class RentalStrategyFactory : IRentalStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RentalStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRentalStrategy GetRentalStrategy(DateTime startDate, DateTime endDate)
        {
            if (IsPeakSeason(startDate, endDate))
            {
                return _serviceProvider.GetService(typeof(PeakSeasonRentalStrategy)) as PeakSeasonRentalStrategy;
            }
            return _serviceProvider.GetService(typeof(StandardRentalStrategy)) as StandardRentalStrategy;
        }

        private static bool IsPeakSeason(DateTime startDate, DateTime endDate)
        {
            // Define peak season logic
            // Example: June to August is peak season
            return startDate.Month >= 6 && startDate.Month <= 8;
        }
    }
}
