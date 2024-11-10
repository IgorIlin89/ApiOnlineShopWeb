using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Dtos;

public class ErrorDto
{
    public ErrorStatusCode StatusCode { get; set; }
    public string? Message { get; set; }
}
