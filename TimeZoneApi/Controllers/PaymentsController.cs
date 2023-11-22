using Braintree;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Text;
using TimeZone.Business.Services.Interfaces;
using TimeZone.Core.Entities;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{

  private readonly IBraintreeService _braintreeService;

    public PaymentsController(IBraintreeService braintreeService)
    {
        _braintreeService = braintreeService;
    }

    [HttpGet]
    public IActionResult GetToken()
    {
        var gateway =_braintreeService.GetGetaway();
        return Ok(gateway.ClientToken.Generate());
    }

    [HttpPost]
    public IActionResult Create(string amount)
    {
        var gateway = _braintreeService.GetGetaway();
        var request = new TransactionRequest
        {
            Amount = Convert.ToDecimal(amount),
            PaymentMethodNonce = "",
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };
        Result<Transaction> result = gateway.Transaction.Sale(request);
        return Ok(result.IsSuccess());
    }
}

