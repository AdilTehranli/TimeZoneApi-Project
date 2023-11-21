using Braintree;

namespace TimeZone.Business.Services.Interfaces;

public interface IBraintreeService
{
    IBraintreeGateway CreateGetaway();
    IBraintreeGateway GetGetaway();
}
