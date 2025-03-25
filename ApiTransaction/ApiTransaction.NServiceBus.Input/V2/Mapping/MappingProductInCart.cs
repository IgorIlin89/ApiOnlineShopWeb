namespace Transaction.NServiceBus.Input.V2.Mapping;

public static class MappingProductInCart
{
    public static Domain.ProductInCart MapToDomain(this OnlineShopWeb.Messages.V2.AddProductInCartDto productInCartDto)
        => new Domain.ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
        };

    public static IReadOnlyCollection<Domain.ProductInCart> MapToDomain(
        this IReadOnlyCollection<OnlineShopWeb.Messages.V2.AddProductInCartDto> productsInCart)
        => productsInCart.Select(o => o.MapToDomain()).ToList();
}
