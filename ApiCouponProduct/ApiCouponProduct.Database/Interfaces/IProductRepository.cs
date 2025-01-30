using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Database.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Product>> GetProductListAsync(CancellationToken cancellationToken);
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);
}