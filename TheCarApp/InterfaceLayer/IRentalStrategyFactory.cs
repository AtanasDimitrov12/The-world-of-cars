
namespace InterfaceLayer
{
    public interface IRentalStrategyFactory
    {
        IRentalStrategy GetRentalStrategy(DateTime startDate, DateTime endDate);
    }
}
