namespace Transaction.NServiceBus.Input.V1.Mapping;

public static class MappingProductInCart
{
    public static Transaction.Domain.ProductInCart MapToProductInCart(this OnlineShopWeb.Messages.V1.AddProductInCartDto productInCartDto)
    {
        var result = new Transaction.Domain.ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
        };

        return result;
    }

    public static List<Transaction.Domain.ProductInCart> MapToProductInCartList(
        this ICollection<OnlineShopWeb.Messages.V1.AddProductInCartDto> productsInCart)
    {
        var listProductsInCart = new List<Transaction.Domain.ProductInCart>();

        foreach (var element in productsInCart)
        {
            listProductsInCart.Add(element.MapToProductInCart());
        }

        return listProductsInCart;
    }
}
