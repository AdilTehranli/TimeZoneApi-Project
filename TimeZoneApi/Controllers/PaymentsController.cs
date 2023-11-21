using Braintree;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Text;
using TimeZone.Business.Services.Interfaces;

namespace TimeZoneApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{

    public IBraintreeService _config;

    public PaymentsController(IBraintreeService config)
    {
        _config = config;
    }


    public static readonly TransactionStatus[] transactionSuccessStatuses =
        {
            TransactionStatus.AUTHORIZED,
            TransactionStatus.AUTHORIZING,
            TransactionStatus.SETTLED,
            TransactionStatus.SETTLING,
            TransactionStatus.SETTLEMENT_CONFIRMED,
            TransactionStatus.SETTLEMENT_PENDING,
            TransactionStatus.SUBMITTED_FOR_SETTLEMENT
        };

    [HttpGet, Route("GenerateToken")]
    public object GenerateToken()
    {
        var gateway = _config.GetGetaway();
        var clientToken = gateway.ClientToken.Generate();
        return clientToken;
    }

    [HttpPost, Route("Checkout")]
    public object Checkout(vmCheckout model)
    {
        string paymentStatus = string.Empty;
        var gateway = _config.GetGetaway();

        var request = new TransactionRequest
        {
            Amount = model.Price,
            PaymentMethodNonce = model.PaymentMethodNonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };

        Result<Transaction> result = gateway.Transaction.Sale(request);
        if (result.IsSuccess())
        {
            paymentStatus = "Succeded";

        }
        else
        {
            string errorMessages = "";
            foreach (ValidationError error in result.Errors.DeepAll())
            {
                errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
            }

            paymentStatus = errorMessages;
        }

        return paymentStatus;
    }
}
