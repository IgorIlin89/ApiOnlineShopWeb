﻿namespace Transaction.Service.Dtos;

public class ProductInCartDto
{
    public int ProductId { get; set; }
    public int Count { get; set; }
    public decimal PricePerProduct { get; set; }
}
