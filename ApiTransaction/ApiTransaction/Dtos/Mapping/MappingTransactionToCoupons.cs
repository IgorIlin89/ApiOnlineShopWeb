using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingTransactionToCoupons
{
    public static TransactionToCoupons MapToTransactionToCoupons(
        this TransactionToCouponsDto transactionToCouponsDto) =>
        new TransactionToCoupons
        {
            Id = transactionToCouponsDto.Id,
            TransactionId = transactionToCouponsDto.TransactionDtoId,
            CouponId = transactionToCouponsDto.CouponId,
            Code = transactionToCouponsDto.Code,
            AmountOfDiscount = transactionToCouponsDto.AmountOfDiscount,
            TypeOfDiscount = transactionToCouponsDto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    public static TransactionToCouponsDto MapToDto(
        this TransactionToCoupons transactionToCoupons) =>
         new TransactionToCouponsDto
         {
             Id = transactionToCoupons.Id,
             TransactionDtoId = transactionToCoupons.TransactionId,
             CouponId = transactionToCoupons.CouponId,
             Code = transactionToCoupons.Code,
             AmountOfDiscount = transactionToCoupons.AmountOfDiscount,
             TypeOfDiscountDto = transactionToCoupons.TypeOfDiscount.MapToTypeOfDiscountDto()
         };

    public static List<TransactionToCoupons> MapToTransactionToCouponsList(this List<TransactionToCouponsDto> list) =>
        list.Select(o => o.MapToTransactionToCoupons()).ToList();
    public static List<TransactionToCouponsDto> MapToDtoList(this IReadOnlyCollection<TransactionToCoupons> list) =>
        list.Select(o => o.MapToDto()).ToList();
    public static TransactionToCoupons MapToTransactionToCoupons(this AddTransactionToCouponsDto dto) =>
        new TransactionToCoupons
        {
            CouponId = dto.CouponId,
            Code = dto.Code,
            AmountOfDiscount = dto.AmountOfDiscount,
            TypeOfDiscount = dto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };

    public static List<TransactionToCoupons> MapToTransactionToCouponsList(this List<AddTransactionToCouponsDto> dtoList) =>
        dtoList.Select(o => o.MapToTransactionToCoupons()).ToList();
}
