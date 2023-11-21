using Braintree;
using TimeZone.Business.Services.Interfaces;

namespace TimeZone.Business.Services.Implements;

public class BrantreeService : IBraintreeService
{
    public string Environment { get; set; }
    public string MerchantId { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
    private IBraintreeGateway BraintreeGateway { get; set; }
    public IBraintreeGateway CreateGetaway()
    {
        Environment = System.Environment.GetEnvironmentVariable("BraintreeEnvironment");
        MerchantId = System.Environment.GetEnvironmentVariable("BraintreeMerchantId");
        PublicKey = System.Environment.GetEnvironmentVariable("BraintreePublicKey");
        PrivateKey = System.Environment.GetEnvironmentVariable("BraintreePrivateKey");

        if (MerchantId == null || PublicKey == null || PrivateKey == null)
        {
            Environment = "sandbox";
            MerchantId = "6wzm3wrfhnp8yzs5";
            PublicKey = "cpk4bvny5qfvhw9d";
            PrivateKey = "afff6508a0b05f86b2b09ff8c225881c";
        }

        return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey);
    }

    public IBraintreeGateway GetGetaway()
    {
        if (BraintreeGateway == null)
        {
            BraintreeGateway = CreateGetaway();
        }

        return BraintreeGateway;
    }
}
