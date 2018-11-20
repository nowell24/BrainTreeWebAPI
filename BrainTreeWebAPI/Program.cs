using System;
using System.IO;
using Braintree;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BrainTreeWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseStartup<IStartup>()
                .Build();



            host.Run();
        }
        private string GetToken(string custID)
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

        internal string GetToken(Func<string> toString)
        {
            throw new NotImplementedException();
        }
    }
}
