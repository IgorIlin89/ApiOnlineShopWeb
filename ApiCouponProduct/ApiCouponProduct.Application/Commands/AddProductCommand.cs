using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record AddProductCommand(string Name,
    string Producer, ProductCategory Category,
    string Picture, decimal Price)
{
}