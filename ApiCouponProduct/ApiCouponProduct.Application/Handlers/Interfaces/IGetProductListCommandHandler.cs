﻿using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetProductListCommandHandler
{
    Task<List<Product>> HandleAsync(CancellationToken cancellationToken);
}