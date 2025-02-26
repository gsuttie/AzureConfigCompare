using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AzureConfigCompare.Tests
{
    [TestClass]
    public class AzureWebAppComparerTests
    {
        [TestMethod]
        public void CompareWebApps_DifferentNames_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.Name.Returns("WebApp1");
            webApp2.Name.Returns("WebApp2");

            //Act
            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            //Assert
            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Name: WebApp1 != WebApp2", differences[0]);
        }

        //[TestMethod]
        //public void CompareWebApps_SameNames_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.Name.Returns("WebApp1");
        //    webApp2.Name.Returns("WebApp2");

        //    //Act
        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        [TestMethod]
        public void CompareWebApps_DifferentRegions_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.RegionName.Returns("East US");
            webApp2.RegionName.Returns("West US");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Region: East US != West US", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameRegions_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.RegionName.Returns("East US");
            webApp2.RegionName.Returns("East US");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentResourceGroups_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.ResourceGroupName.Returns("ResourceGroup1");
            webApp2.ResourceGroupName.Returns("ResourceGroup2");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Resource Group: ResourceGroup1 != ResourceGroup2", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameResourceGroups_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.ResourceGroupName.Returns("ResourceGroup");
            webApp2.ResourceGroupName.Returns("ResourceGroup");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentDefaultHostNames_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.DefaultHostName.Returns("webapp1.azurewebsites.net");
            webApp2.DefaultHostName.Returns("webapp2.azurewebsites.net");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Default Host Name: webapp1.azurewebsites.net != webapp2.azurewebsites.net", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameDefaultHostNames_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.DefaultHostName.Returns("webapp.azurewebsites.net");
            webApp2.DefaultHostName.Returns("webapp.azurewebsites.net");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentStates_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.State.Returns("Running");
            webApp2.State.Returns("Stopped");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("State: Running != Stopped", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameStates_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.State.Returns("Running");
            webApp2.State.Returns("Running");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentAppServicePlans_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.AppServicePlanId.Returns("Plan1");
            webApp2.AppServicePlanId.Returns("Plan2");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("App Service Plan: Plan1 != Plan2", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameAppServicePlans_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.AppServicePlanId.Returns("Plan");
            webApp2.AppServicePlanId.Returns("Plan");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentOperatingSystems_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.OperatingSystem.Returns(OperatingSystem.Windows);
            webApp2.OperatingSystem.Returns(OperatingSystem.Linux);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Operating System: Windows != Linux", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameOperatingSystems_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.OperatingSystem.Returns(OperatingSystem.Windows);
            webApp2.OperatingSystem.Returns(OperatingSystem.Windows);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        //[TestMethod]
        //public void CompareWebApps_DifferentNetFrameworkVersions_ReturnsDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.NetFrameworkVersion.Value.Returns("v4.7");
        //    webApp2.NetFrameworkVersion.Value.Returns("v4.8");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(1, differences.Count);
        //    Assert.AreEqual(".NET Framework Version: v4.7 != v4.8", differences[0]);
        //}

        //[TestMethod]
        //public void CompareWebApps_SameNetFrameworkVersions_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.NetFrameworkVersion.Value.Returns("v4.7");
        //    webApp2.NetFrameworkVersion.Value.Returns("v4.7");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        //[TestMethod]
        //public void CompareWebApps_DifferentPhpVersions_ReturnsDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.PhpVersion.Value.Returns("7.3");
        //    webApp2.PhpVersion.Value.Returns("7.4");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(1, differences.Count);
        //    Assert.AreEqual("PHP Version: 7.3 != 7.4", differences[0]);
        //}

        //[TestMethod]
        //public void CompareWebApps_SamePhpVersions_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.PhpVersion.Value.Returns("7.3");
        //    webApp2.PhpVersion.Value.Returns("7.3");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        //[TestMethod]
        //public void CompareWebApps_DifferentJavaVersions_ReturnsDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.JavaVersion.Value.Returns("1.8");
        //    webApp2.JavaVersion.Value.Returns("11");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(1, differences.Count);
        //    Assert.AreEqual("Java Version: 1.8 != 11", differences[0]);
        //}

        //[TestMethod]
        //public void CompareWebApps_SameJavaVersions_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.JavaVersion.Value.Returns("1.8");
        //    webApp2.JavaVersion.Value.Returns("1.8");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        //[TestMethod]
        //public void CompareWebApps_DifferentPythonVersions_ReturnsDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.PythonVersion.Value.Returns("3.7");
        //    webApp2.PythonVersion.Value.Returns("3.8");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(1, differences.Count);
        //    Assert.AreEqual("Python Version: 3.7 != 3.8", differences[0]);
        //}

        //[TestMethod]
        //public void CompareWebApps_SamePythonVersions_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.PythonVersion.Value.Returns("3.7");
        //    webApp2.PythonVersion.Value.Returns("3.7");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        [TestMethod]
        public void CompareWebApps_DifferentNodeVersions_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.NodeVersion.Returns("12.18");
            webApp2.NodeVersion.Returns("14.15");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Node Version: 12.18 != 14.15", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameNodeVersions_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.NodeVersion.Returns("12.18");
            webApp2.NodeVersion.Returns("12.18");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        //[TestMethod]
        //public void CompareWebApps_DifferentScmTypes_ReturnsDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.ScmType.Value.Returns("LocalGit");
        //    webApp2.ScmType.Value.Returns("GitHub");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(1, differences.Count);
        //    Assert.AreEqual("SCM Type: LocalGit != GitHub", differences[0]);
        //}

        //[TestMethod]
        //public void CompareWebApps_SameScmTypes_ReturnsNoDifference()
        //{
        //    //Arrange
        //    var webApp1 = Substitute.For<IWebApp>();
        //    var webApp2 = Substitute.For<IWebApp>();
        //    webApp1.ScmType.Value.Returns("LocalGit");
        //    webApp2.ScmType.Value.Returns("LocalGit");

        //    var comparer = new AzureWebAppComparer();
        //    var differences = comparer.CompareWebApps(webApp1, webApp2);

        //    Assert.AreEqual(0, differences.Count);
        //}

        [TestMethod]
        public void CompareWebApps_DifferentHttp20Enabled_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.Http20Enabled.Returns(true);
            webApp2.Http20Enabled.Returns(false);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("HTTP/2.0 Enabled: True != False", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameHttp20Enabled_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.Http20Enabled.Returns(true);
            webApp2.Http20Enabled.Returns(true);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentHttpsOnly_ReturnsDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.HttpsOnly.Returns(true);
            webApp2.HttpsOnly.Returns(false);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("HTTPS Only: True != False", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameHttpsOnly_ReturnsNoDifference()
        {
            //Arrange
            var webApp1 = Substitute.For<IWebApp>();
            var webApp2 = Substitute.For<IWebApp>();
            webApp1.HttpsOnly.Returns(true);
            webApp2.HttpsOnly.Returns(true);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1, webApp2);

            Assert.AreEqual(0, differences.Count);
        }
    }
}
