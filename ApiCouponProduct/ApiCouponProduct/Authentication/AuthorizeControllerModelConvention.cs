﻿using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ApiCouponProduct.Authentication;

public class AuthorizeControllerModelConvention : IControllerModelConvention
{
    public static string PolicyName = "AuthorizePolicy";

    public void Apply(ControllerModel controller)
    {
        controller.Filters.Add(new AuthorizeFilter(PolicyName));
    }
}
