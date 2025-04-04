﻿using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Dtos;

public class UpdateProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Producer { get; set; }
    public ProductCategory Category { get; set; }
    public string Picture { get; set; }
    public decimal Price { get; set; }
}
