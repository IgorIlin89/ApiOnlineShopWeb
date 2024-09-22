//namespace Transaction.Domain.Dtos;

//public static class MappingTransaction
//{
//    //public class MappingTransactionAccessToken
//    //{
//    //}

//    //public static bool AccessAuthorization(Object token)
//    //{
//    //    //if(typeof(Transaction) token)
//    //    //return true;
//    //}

//    private static void CallSetFinalPrice(Transaction transaction)
//    {
//        //transaction.CalculateFinalPrice();
//    }

//    public static Transaction MapToTransaction(this AddTransactionDto addTransactionDto)
//    {
//        //var transaction = new Transaction();

//        if (addTransactionDto.Id is not null)
//        {
//            transaction.Id = addTransactionDto.Id.Value;
//        }

//        if (addTransactionDto.TransactionToCouponsId is not null)
//        {
//            //transaction.TransactionToCouponsId = addTransactionDto.TransactionToCouponsId;
//        }

//        transaction.UserId = addTransactionDto.UserId;
//        transaction.PaymentDate = addTransactionDto.PaymentDate;
//        //transaction.FinalPrice = addTransactionDto.FinalPrice;

//        if (addTransactionDto.CouponsDto is not null)
//        {
//            //transaction.Coupons = addTransactionDto.CouponsDto.MapToTransactionToCoupons();
//        }

//        transaction.ProductsInCart = addTransactionDto.ProductsInCartDto.MapToProductInCartList();

//        CallSetFinalPrice(transaction);

//        return transaction;
//    }

//    public static Transaction MapToTransaction(this TransactionDto addTransactionDto)
//    {
//        var transaction = new Transaction();

//        transaction.Id = addTransactionDto.Id;
//        //transaction.TransactionToCouponsId = addTransactionDto.TransactionToCouponsId;
//        transaction.UserId = addTransactionDto.UserId;
//        transaction.PaymentDate = addTransactionDto.PaymentDate;
//        //transaction.FinalPrice = addTransactionDto.FinalPrice;
//        if (addTransactionDto.CouponsDto is not null)
//        {
//            //transaction.Coupons = addTransactionDto.CouponsDto.MapToTransactionToCoupons();
//        }
//        transaction.ProductsInCart = addTransactionDto.ProductsInCartDto.MapToProductInCartList();

//        CallSetFinalPrice(transaction);

//        return transaction;
//    }

//    //public static List<TransactionDto> MapToDtoList(
//    //    this ICollection<Transaction> transactionHistories)
//    //{

//    //}

//    public static TransactionDto MapToDto(this Transaction transaction)
//    {
//        var result = new TransactionDto();

//        result.Id = transaction.Id;
//        //result.TransactionToCouponsId = transaction.TransactionToCouponsId;
//        result.UserId = transaction.UserId;
//        result.PaymentDate = transaction.PaymentDate;
//        result.FinalPrice = transaction.FinalPrice;
//        if (transaction.Coupons is not null)
//        {
//            //result.CouponsDto = transaction.Coupons.MapToDto();
//        }

//        if (transaction.ProductsInCart is not null)
//        {
//            result.ProductsInCartDto = transaction.ProductsInCart.MapToDtoList();
//        }

//        return result;

//        //return new TransactionDto
//        //{
//        //    Id = transaction.Id,
//        //    TransactionToCouponsId = transaction.TransactionToCouponsId,
//        //    UserId = transaction.UserId,
//        //    PaymentDate = transaction.PaymentDate,
//        //    FinalPrice = transaction.FinalPrice,
//        //    CouponsDto => transaction.Coupons == null ? null : transaction.Coupons.MapToDto(),
//        //    ProductsInCartDto = transaction.ProductsInCart.MapToDtoList()
//        //};
//    }

//    public static List<TransactionDto> MapToDtoList(
//        this ICollection<Transaction> transactionHistories)
//    {
//        var result = new List<TransactionDto>();

//        foreach (var element in transactionHistories)
//        {
//            result.Add(element.MapToDto());
//        }

//        return result;
//    }
//}
