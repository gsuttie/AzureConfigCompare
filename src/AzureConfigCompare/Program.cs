using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Extensions.Configuration;
using System;

namespace AzureConfigCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: AzureConfigCompare <webAppName1> <webAppName2>");
                return;
            }

            var webAppName1 = args[0];
            var webAppName2 = args[1];

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var azureCredentials = SdkContext.AzureCredentialsFactory
                .FromServicePrincipal(
                    config["Azure:ClientId"],
                    config["Azure:ClientSecret"],
                    config["Azure:TenantId"],
                    AzureEnvironment.AzureGlobalCloud);

            var azure = Azure
                .Configure()
                .Authenticate(azureCredentials)
                .WithDefaultSubscription();

            var webApp1 = azure.WebApps.GetByResourceGroup(config["Azure:ResourceGroupName"], webAppName1);
            var webApp2 = azure.WebApps.GetByResourceGroup(config["Azure:ResourceGroupName"], webAppName2);

            if (webApp1 == null || webApp2 == null)
            {
                Console.WriteLine("One or both web apps not found.");
                return;
            }

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            foreach (var difference in differences)
            {
                Console.WriteLine(difference);
            }
        }
    }
}
