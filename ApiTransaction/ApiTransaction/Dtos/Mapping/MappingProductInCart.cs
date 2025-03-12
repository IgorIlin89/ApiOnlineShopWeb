using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingProductInCart
{
    public static ProductInCart MapToProductInCart(this ProductInCartDto productInCartDto) =>
        new ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
        };

    public static IReadOnlyCollection<ProductInCart> MapToProductInCartList(this IReadOnlyCollection<ProductInCartDto> productsInCart) =>
        productsInCart.Select(o => o.MapToProductInCart()).ToList();

    public static ProductInCart MapToProductInCart(this AddProductInCartDto productInCartDto) =>
        new ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
        };

    public static IReadOnlyCollection<ProductInCart> MapToDomain(this IReadOnlyCollection<AddProductInCartDto> productsInCart) =>
        productsInCart.Select(o => o.MapToProductInCart()).ToList();

    public static ProductInCartDto MapToDto(this ProductInCart productInCart) =>
        new ProductInCartDto
        {
            ProductId = productInCart.ProductId,
            Count = productInCart.Count,
            PricePerProduct = productInCart.PricePerProduct,
        };
    public static IReadOnlyCollection<ProductInCartDto> MapToDtoList(
        this IReadOnlyCollection<ProductInCart> productsInCartDto) =>
        productsInCartDto.Select(o => o.MapToDto()).ToList();
}
