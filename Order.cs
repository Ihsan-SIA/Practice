public class Order
{
    public DateTime DatePlaced {  get; set; }
    public float TotalPrice { get; set; }
    public bool IsShipped
    {  
        get { return Shipment != null; }
    }
    public Shipment Shipment { get; set; } = default!;
}