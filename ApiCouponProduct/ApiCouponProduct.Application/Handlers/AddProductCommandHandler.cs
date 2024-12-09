using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;


namespace ApiCouponProduct.Application.Handlers;

public class AddProductCommandHandler(IUnitOfWork UnitOfWork, IProductRepository Repository) : IAddProductCommandHandler
{
    public Product Handle(AddProductCommand command)
    {
        var productToAdd = new Product
        {
            Name = command.Name,
            Producer = command.Producer,
            Category = command.Category,
            Picture = command.Picture,
            Price = command.Price
        };

        var product = Repository.AddProduct(productToAdd);
        UnitOfWork.SaveChanges();
        return product;
    }
}
