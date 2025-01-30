using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;
using ApiCouponProduct.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace ApiCouponProduct.Database;

internal class ProductRepository : IProductRepository
{
    private readonly ApiCouponProductContext _context;

    public ProductRepository(ApiCouponProductContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProduct(Product product, CancellationToken cancellationToken)
    {
        var existingProduct = await _context.Product.FirstOrDefaultAsync(o => o.Name == product.Name &&
        o.Producer == product.Producer,
        cancellationToken);

        if (existingProduct is not null)
        {
            throw new ProductExistsException($"A product with the name '{product.Name}' and the producer " +
                $"{product.Producer}' allready exists");
        }

        var response = await _context.Product.AddAsync(product, cancellationToken);

        return response.Entity;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var user = await _context.Product.FirstOrDefaultAsync(o => o.Id == id,
            cancellationToken);

        if (user is not null)
        {
            _context.Remove(user);
        }
    }

    public async Task<Product> GetProductById(int id, CancellationToken cancellationToken)
    {
        var product = await _context.Product.FirstOrDefaultAsync(o => o.Id == id,
            cancellationToken);

        if (product is null)
        {
            throw new NotFoundException($"Product with the id '{id}' does not exist");
        }

        return product;
    }

    public async Task<List<Product>> GetProductList(CancellationToken cancellationToken)
    {
        return await _context.Product.ToListAsync(cancellationToken);
    }

    public async Task<Product> Update(Product product, CancellationToken cancellationToken)
    {
        var productToEdit = await _context.Product.FirstOrDefaultAsync(o => o.Id == product.Id,
            cancellationToken);

        if (productToEdit is null)
        {
            throw new NotFoundException($"Product with the Id '{product.Id}' does not exist and could not be updated");
        }

        productToEdit.Name = product.Name;
        productToEdit.Producer = product.Producer;
        productToEdit.Category = product.Category;
        productToEdit.Picture = product.Picture;
        productToEdit.Price = product.Price;

        return productToEdit;
    }
}
