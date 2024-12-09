using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record UpdateProductCommand(int Id,
    string Name, string Producer,
    ProductCategory Category, string Picture,
    decimal Price)
{

}