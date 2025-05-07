var orderProcessor = new OrderProcessor();
var order = new Order
{
    DatePlaced = DateTime.Now,
    TotalPrice = 100f
};
orderProcessor.Process(order);
public class ShippingCalculator
{
    public float CalculateShipping(Order order)
    {
        return order.TotalPrice;
    }
}

public class Shipment
{
    public float Cost;
    public DateTime ShippingDate;
}

public class Order
{
    public DateTime DatePlaced {  get; set; }
    public float TotalPrice { get; set; }
    public bool IsShipped {  get; set; }
    public Shipment Shipment { get; set; } = default!;
}
public class OrderProcessor
{
    private readonly ShippingCalculator _shippingCalculator;
    public OrderProcessor()
    {
        _shippingCalculator = new ShippingCalculator();
    }
    public void Process(Order order)
    {
        if (order.IsShipped)
        {
            throw new InvalidOperationException("This order has already been processed, thank you.");
        }
        order.Shipment = new Shipment()
        {
            Cost = _shippingCalculator.CalculateShipping(order),
            ShippingDate = DateTime.Today.AddDays(1)

        };
    }
}