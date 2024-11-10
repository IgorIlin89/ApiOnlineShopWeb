using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingProductInCart
{
    public static ProductInCart MapToProductInCart(this ProductInCartDto productInCartDto) =>
        new ProductInCart
        {
            Id = productInCartDto.Id,
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
            TransactionId = productInCartDto.TransactionId
        };

    public static List<ProductInCart> MapToProductInCartList(this ICollection<ProductInCartDto> productsInCart) =>
        productsInCart.Select(o => o.MapToProductInCart()).ToList();

    public static ProductInCart MapToProductInCart(this AddProductInCartDto productInCartDto) =>
        new ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
            TransactionId = productInCartDto.TransactionId
        };

    public static List<ProductInCart> MapToProductInCartList(this ICollection<AddProductInCartDto> productsInCart) =>
        productsInCart.Select(o => o.MapToProductInCart()).ToList();

    public static ProductInCartDto MapToDto(this ProductInCart productInCart) =>
        new ProductInCartDto
        {
            Id = productInCart.Id,
            ProductId = productInCart.ProductId,
            Count = productInCart.Count,
            PricePerProduct = productInCart.PricePerProduct,
            TransactionId = productInCart.TransactionId
        };
    public static List<ProductInCartDto> MapToDtoList(
        this IReadOnlyCollection<ProductInCart> productsInCartDto) =>
        productsInCartDto.Select(o => o.MapToDto()).ToList();
}
