using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingTransactionToCoupons
{
    public static TransactionToCoupons MapToTransactionToCoupons(
        this TransactionToCouponsDto transactionToCouponsDto)
    {
        return new TransactionToCoupons
        {
            Id = transactionToCouponsDto.Id,
            TransactionId = transactionToCouponsDto.TransactionDtoId,
            CouponId = transactionToCouponsDto.CouponId,
            Code = transactionToCouponsDto.Code,
            AmountOfDiscount = transactionToCouponsDto.AmountOfDiscount,
            TypeOfDiscount = transactionToCouponsDto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    }

    public static TransactionToCouponsDto MapToDto(
        this TransactionToCoupons transactionToCoupons)
    {
        return new TransactionToCouponsDto
        {
            Id = transactionToCoupons.Id,
            TransactionDtoId = transactionToCoupons.TransactionId,
            CouponId = transactionToCoupons.CouponId,
            Code = transactionToCoupons.Code,
            AmountOfDiscount = transactionToCoupons.AmountOfDiscount,
            TypeOfDiscountDto = transactionToCoupons.TypeOfDiscount.MapToTypeOfDiscountDto()
        };
    }

    public static List<TransactionToCoupons> MapToTransactionToCouponsList(this List<TransactionToCouponsDto> list)
    {
        var result = new List<TransactionToCoupons>();
        foreach (var element in list)
        {
            result.Add(element.MapToTransactionToCoupons());
        }

        return result;
    }

    public static List<TransactionToCouponsDto> MapToDtoList(this List<TransactionToCoupons> list)
    {
        var result = new List<TransactionToCouponsDto>();
        foreach (var element in list)
        {
            result.Add(element.MapToDto());
        }

        return result;
    }

    public static TransactionToCoupons MapToTransactionToCoupons(this AddTransactionToCouponsDto dto)
    {
        return new TransactionToCoupons
        {
            CouponId = dto.CouponId,
            Code = dto.Code,
            AmountOfDiscount = dto.AmountOfDiscount,
            TypeOfDiscount = dto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    }

    public static List<TransactionToCoupons> MapToTransactionToCouponsList(this List<AddTransactionToCouponsDto> dtoList)
    {
        var result = new List<TransactionToCoupons>();

        foreach (var element in dtoList)
        {
            result.Add(element.MapToTransactionToCoupons());
        }

        return result;
    }

}
