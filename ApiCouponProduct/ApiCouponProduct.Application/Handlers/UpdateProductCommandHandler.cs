using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class UpdateProductCommandHandler(IUnitOfWork UnitOfWork, IProductRepository Repository) : IUpdateProductCommandHandler
{
    public Product Handle(UpdateProductCommand command)
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

        var product = Repository.Update(productToUpdate);
        UnitOfWork.SaveChanges();
        return product;
    }
}
