using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record UpdateProductCommand
{
    public Product ProductToUpdate { get; init; }
    public UpdateProductCommand(Product productToUpdate)
    {
        ProductToUpdate = productToUpdate;
    }
}
