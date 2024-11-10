using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record AddProductCommand
{
    public Product ProductToAdd { get; init; }

    public AddProductCommand(Product productToAdd)
    {
        ProductToAdd = productToAdd;
    }
}
