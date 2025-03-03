using AzureConfigCompare.Models;
using System.Drawing;
using Console = Colorful.Console;

namespace AzureConfigCompare
{
    internal class Program
    {
        static void Main()
        {
            string originalText = @"SampleFiles/File1.json";
            string modifiedText = @"SampleFiles/File2.json";
            CompareFiles compareFiles = new(originalText, modifiedText);
            HighlightDifferences(compareFiles.TextDifferences, compareFiles.CharacterDifferences);
        }

        private static void HighlightDifferences(List<TextDifference> textDifferences, List<CharacterDifference> characterDifferences)
        {
            foreach (TextDifference difference in textDifferences)
            {
                Console.WriteLine($"Line {difference.LineNumber}: {difference.Message}");
            }
            foreach (CharacterDifference diff in characterDifferences)
            {
                if (diff.IsDifferent)
                {
                    Console.Write(diff.Text, Color.Red);
                }
                else
                {
                    Console.Write(diff.Text, Color.White);
                }
            }

            Console.WriteLine();
        }



        //static async Task Main(string[] args)
        //{
        //    IConfigurationBuilder builder = new ConfigurationBuilder()
        //                   .AddUserSecrets<Program>();
        //    IConfiguration configuration = builder.Build();

        //    string subscriptionId = configuration["SubscriptionId"];
        //    string resourceGroupName = configuration["ResourceGroupName"];
        //    string webAppName = configuration["WebAppName"];
        //    //To create a token, follow these steps: https://learn.microsoft.com/en-us/community/content/azure-rest-api-how-to-create-a-bearer-token
        //    //Make sure you assign the Service Principal as a reader to the resources/resource group/subscription you want to access
        //    string accessToken = configuration["AccessToken"];
        //    string apiVersion = "2024-04-01";
        //    string url = $"https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{webAppName}/config/appsettings/list?api-version={apiVersion}";

        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        //        HttpResponseMessage response = await client.PostAsync(url, null);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseData = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(responseData);
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Error: {response.StatusCode}");
        //        }
        //    }
        //}
    }

}


// get app config (GET)
// https://management.azure.com/subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Web/sites/{{webAppName}}?api-version=2024-04-01
// get connection strings (POST)
// https://management.azure.com/subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Web/sites/{{webAppName}}/config/connectionstrings/list?api-version=2024-04-01
// app settings (POST)
// https://management.azure.com/subscriptions/{{subscriptionId}}/resourceGroups/{{resourceGroupName}}/providers/Microsoft.Web/sites/{{webAppName}}/config/appsettings/list?api-version=2024-04-01



