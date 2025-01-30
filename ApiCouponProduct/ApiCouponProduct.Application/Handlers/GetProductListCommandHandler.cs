using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class GetProductListCommandHandler(IProductRepository Repository) : IGetProductListCommandHandler
{
    public async Task<List<Product>> Handle(CancellationToken cancellationToken)
    {
        return await Repository.GetProductList(cancellationToken);
    }
}
