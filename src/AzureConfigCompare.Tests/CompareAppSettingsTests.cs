namespace AzureConfigCompare.Tests
{

    [TestClass]
    public sealed class CompareAppSettingsTests
    {
        [TestMethod]
        public void TestAppSettingsDifferences()
        {
            //Arrange
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath1 = Path.Combine(baseDirectory, @"SampleResponses/web-appsettings-dev.json");
            string filePath2 = Path.Combine(baseDirectory, @"SampleResponses/web-appsettings-prod.json");

            //Act
            CompareFiles compareFiles = new(filePath1, filePath2); ;

            //Assert
            Assert.IsNotNull(compareFiles);
            Assert.IsTrue(compareFiles.Differences.Count >= 0);
            Assert.AreEqual(2,compareFiles.Differences[0].LineNumber);
            Assert.AreEqual(@"Value mismatch at /id: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/SampleResourceGroupDev/providers/Microsoft.Web/sites/sample-webapp-dev/config/appsettings vs /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/SampleResourceGroupProd/providers/Microsoft.Web/sites/sample-webapp-prod/config/appsettings", compareFiles.Differences[0].Message);

        }
    }
}
