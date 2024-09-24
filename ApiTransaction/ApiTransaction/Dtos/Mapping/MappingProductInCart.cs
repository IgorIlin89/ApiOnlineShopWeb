using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingProductInCart
{
    public static ProductInCart MapToProductInCart(this ProductInCartDto productInCartDto)
    {
        ProductInCart result = new ProductInCart
        {
            ProductId = productInCartDto.ProductId,
            Count = productInCartDto.Count,
            PricePerProduct = productInCartDto.PricePerProduct,
            TransactionId = productInCartDto.TransactionId
        };

        if (productInCartDto.Id is not null)
        {
            productInCartDto.Id = productInCartDto.Id.Value;
        }

        return result;
    }

    public static List<ProductInCart> MapToProductInCartList(this ICollection<ProductInCartDto> productsInCart)
    {
        var listProductsInCart = new List<ProductInCart>();

        foreach (var element in productsInCart)
        {
            listProductsInCart.Add(element.MapToProductInCart());
        }

        return listProductsInCart;
    }

    public static ProductInCartDto MapToDto(this ProductInCart productInCart)
    {
        return new ProductInCartDto
        {
            Id = productInCart.Id,
            ProductId = productInCart.ProductId,
            Count = productInCart.Count,
            PricePerProduct = productInCart.PricePerProduct,
            TransactionId = productInCart.TransactionId
        };
    }

    public static List<ProductInCartDto> MapToDtoList(
        this ICollection<ProductInCart> productsInCartDto)
    {
        var result = new List<ProductInCartDto>();

        foreach (var element in productsInCartDto)
        {
            result.Add(element.MapToDto());
        }

        return result;
    }
}
