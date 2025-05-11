namespace InventoryService.Domain
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid WarehouseId { get; set; }
        public int Quantity { get; set; }
        public Inventory(Guid productId, Guid warehouse, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            WarehouseId = warehouse;
            Quantity = quantity;
        }
        public void UpdateQuantity(int quantity)
        {
            if (quantity < 0) { throw new InvalidOperationException("Quantity cannot be negative."); }
            Quantity = quantity;
        }
    }
}
