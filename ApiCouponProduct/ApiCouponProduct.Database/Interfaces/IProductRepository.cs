using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Database.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProduct(Product product, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    Task<Product> GetProductById(int id, CancellationToken cancellationToken);
    Task<List<Product>> GetProductList(CancellationToken cancellationToken);
    Task<Product> Update(Product product, CancellationToken cancellationToken);
}