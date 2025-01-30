using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class UpdateProductCommandHandler(IUnitOfWork UnitOfWork, IProductRepository Repository)
    : IUpdateProductCommandHandler
{
    public async Task<Product> Handle(UpdateProductCommand command,
        CancellationToken cancellationToken)
    {
        var productToUpdate = new Product
        {
            Id = command.Id,
            Name = command.Name,
            Producer = command.Producer,
            Category = command.Category,
            Picture = command.Picture,
            Price = command.Price
        };

        var product = await Repository.Update(productToUpdate, cancellationToken);
        await UnitOfWork.SaveChanges(cancellationToken);
        return product;
    }
}
