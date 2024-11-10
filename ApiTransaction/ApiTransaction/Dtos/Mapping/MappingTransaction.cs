namespace Transaction.Service.Dtos.Mapping;

public static class MappingTransaction
{
    public static TransactionDto MapToDto(this Domain.Transaction transaction) =>
        new TransactionDto
        {
            Id = transaction.Id,
            UserId = transaction.UserId,
            PaymentDate = transaction.PaymentDate,
            FinalPrice = transaction.FinalPrice,
            ProductsInCartDto = transaction.ProductsInCart.MapToDtoList(),
            CouponsDto = transaction.Coupons.MapToDtoList()
        };


    public static List<TransactionDto> MapToDtoList(
        this ICollection<Domain.Transaction> transactionHistories) =>
        transactionHistories.Select(o => o.MapToDto()).ToList();
}
