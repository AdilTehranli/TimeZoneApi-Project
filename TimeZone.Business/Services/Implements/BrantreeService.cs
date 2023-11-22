using Braintree;
using Microsoft.Extensions.Configuration;
using TimeZone.Business.Services.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class BrantreeService : IBraintreeService
{
    private readonly IConfiguration _config;

    public BrantreeService(IConfiguration config)
    {
        _config = config;
    }

    public IBraintreeGateway CreateGetaway()
    {


        var newGetaway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = _config.GetValue<string>("BraintreeGateway:MerchantId"),
            PublicKey = _config.GetValue<string>("BraintreeGateway:PublicKey"),
            PrivateKey = _config.GetValue<string>("BraintreeGateway:PrivateKey")

        };
        return newGetaway;
    }

    public IBraintreeGateway GetGetaway()
    {
        return CreateGetaway();
    }
}
