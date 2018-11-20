using Braintree;

namespace BrainTreeWebAPI
{
    public class Program
    {
        public string GetToken(string custID)
        {
            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "z72ck693pwd7f8sf",
                PublicKey = "rqgz9jmsk696563s",
                PrivateKey = "d58d9d243005e1cab780f4d3c4dcc86a"
            };

            var clientToken = gateway.ClientToken.Generate(
            new ClientTokenRequest
            {
                CustomerId = custID
            });

            return clientToken;

        }

    }
}
