using InventoryService.Domain;
using InventoryService.Infrastructure;
using MediatR;

namespace InventoryService.Application
{
    public class UpdateInventoryCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public Guid WarehouseId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, bool>
    {
        private readonly InventoryDbContext _dbContext;

        public UpdateInventoryCommandHandler(InventoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _dbContext.Inventories.FirstOrDefaultAsync(i => i.ProductId == request.ProductId && i.WarehouseId == request.WarehouseId, cancellationToken);

            if (inventory == null)
            {
                inventory = new Inventory(request.ProductId, request.WarehouseId, request.Quantity);
                _dbContext.Inventories.Add(inventory);
            }
            else
            {
                inventory.UpdateQuantity(request.Quantity);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }