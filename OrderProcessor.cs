public class OrderProcessor
{
    private readonly IProcessor _shippingCalculator;
    public OrderProcessor(IProcessor shippingCalculator)
    {
        _shippingCalculator = shippingCalculator;
    }
    public void Process(Order order)
    {
        if (order.IsShipped)
        {
            throw new InvalidOperationException("This order has already been processed, thank you.");
        }
        
        order.Shipment = new Shipment()
        {
            Cost = _shippingCalculator.CalculateShippingCost(order),
            ShippingDate = DateTime.Today.AddDays(1)
        };
    }
}
