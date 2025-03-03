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
            Assert.IsNotNull(compareFiles.TextDifferences);
            Assert.IsTrue(compareFiles.TextDifferences.Count >= 0);
            Assert.AreEqual(2,compareFiles.TextDifferences[0].LineNumber);
            Assert.AreEqual(@"Value mismatch at /id: /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/SampleResourceGroupDev/providers/Microsoft.Web/sites/sample-webapp-dev/config/appsettings vs /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/SampleResourceGroupProd/providers/Microsoft.Web/sites/sample-webapp-prod/config/appsettings", compareFiles.TextDifferences[0].Message);
            Assert.IsNotNull(compareFiles.CharacterDifferences);
            Assert.IsTrue(compareFiles.CharacterDifferences.Count >= 0);
            Assert.AreEqual("{", compareFiles.CharacterDifferences[0].Text);
            Assert.AreEqual(false, compareFiles.CharacterDifferences[0].IsDifferent);
            bool foundDifferentCharacter = false;
            for (int i = 0; i < compareFiles.CharacterDifferences.Count; i++)
            {
                if (compareFiles.CharacterDifferences[i].IsDifferent)
                {
                    foundDifferentCharacter = true;
                    break;
                }
            }
            Assert.IsTrue(foundDifferentCharacter);
        }
    }
}
