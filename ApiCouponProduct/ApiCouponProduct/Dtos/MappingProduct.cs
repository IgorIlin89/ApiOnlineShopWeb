using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Dtos;

public static class MappingProduct
{
    public static AddProductDto MapToDto(this Product product) =>
        new AddProductDto
        {
            ProductId = product.Id,
            Name = product.Name,
            Producer = product.Producer,
            Category = product.Category,
            Picture = product.Picture,
            Price = product.Price
        };

    public static Product MapToProduct(this AddProductDto addProductDto) =>
        new Product()
        {
            Name = addProductDto.Name,
            Producer = addProductDto.Producer,
            Category = addProductDto.Category,
            Picture = addProductDto.Picture,
            Price = addProductDto.Price,
        };
    public static Product MapToProduct(this UpdateProductDto updateProductDto) =>
        new Product
        {
            Id = updateProductDto.ProductId,
            Name = updateProductDto.Name,
            Producer = updateProductDto.Producer,
            Category = updateProductDto.Category,
            Picture = updateProductDto.Picture,
            Price = updateProductDto.Price,
        };
    public static List<AddProductDto> MapToDtoList(this List<Product> productList) =>
        productList.Select(o => o.MapToDto()).ToList();
}
