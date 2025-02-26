using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace AzureConfigCompare.Tests
{
    [TestClass]
    public class AzureWebAppComparerTests
    {
        [TestMethod]
        public void CompareWebApps_DifferentNames_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.Name).Returns("WebApp1");
            webApp2.Setup(w => w.Name).Returns("WebApp2");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Name: WebApp1 != WebApp2", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameNames_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.Name).Returns("WebApp");
            webApp2.Setup(w => w.Name).Returns("WebApp");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentRegions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.RegionName).Returns("East US");
            webApp2.Setup(w => w.RegionName).Returns("West US");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Region: East US != West US", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameRegions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.RegionName).Returns("East US");
            webApp2.Setup(w => w.RegionName).Returns("East US");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentResourceGroups_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.ResourceGroupName).Returns("ResourceGroup1");
            webApp2.Setup(w => w.ResourceGroupName).Returns("ResourceGroup2");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Resource Group: ResourceGroup1 != ResourceGroup2", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameResourceGroups_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.ResourceGroupName).Returns("ResourceGroup");
            webApp2.Setup(w => w.ResourceGroupName).Returns("ResourceGroup");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentDefaultHostNames_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.DefaultHostName).Returns("webapp1.azurewebsites.net");
            webApp2.Setup(w => w.DefaultHostName).Returns("webapp2.azurewebsites.net");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Default Host Name: webapp1.azurewebsites.net != webapp2.azurewebsites.net", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameDefaultHostNames_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.DefaultHostName).Returns("webapp.azurewebsites.net");
            webApp2.Setup(w => w.DefaultHostName).Returns("webapp.azurewebsites.net");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentStates_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.State).Returns("Running");
            webApp2.Setup(w => w.State).Returns("Stopped");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("State: Running != Stopped", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameStates_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.State).Returns("Running");
            webApp2.Setup(w => w.State).Returns("Running");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentAppServicePlans_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.AppServicePlanId).Returns("Plan1");
            webApp2.Setup(w => w.AppServicePlanId).Returns("Plan2");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("App Service Plan: Plan1 != Plan2", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameAppServicePlans_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.AppServicePlanId).Returns("Plan");
            webApp2.Setup(w => w.AppServicePlanId).Returns("Plan");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentOperatingSystems_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.OperatingSystem).Returns(OperatingSystem.Windows);
            webApp2.Setup(w => w.OperatingSystem).Returns(OperatingSystem.Linux);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Operating System: Windows != Linux", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameOperatingSystems_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.OperatingSystem).Returns(OperatingSystem.Windows);
            webApp2.Setup(w => w.OperatingSystem).Returns(OperatingSystem.Windows);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentNetFrameworkVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.NetFrameworkVersion).Returns("v4.7");
            webApp2.Setup(w => w.NetFrameworkVersion).Returns("v4.8");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual(".NET Framework Version: v4.7 != v4.8", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameNetFrameworkVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.NetFrameworkVersion).Returns("v4.7");
            webApp2.Setup(w => w.NetFrameworkVersion).Returns("v4.7");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentPhpVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PhpVersion).Returns("7.3");
            webApp2.Setup(w => w.PhpVersion).Returns("7.4");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("PHP Version: 7.3 != 7.4", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SamePhpVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PhpVersion).Returns("7.3");
            webApp2.Setup(w => w.PhpVersion).Returns("7.3");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentJavaVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.JavaVersion).Returns("1.8");
            webApp2.Setup(w => w.JavaVersion).Returns("11");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Java Version: 1.8 != 11", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameJavaVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.JavaVersion).Returns("1.8");
            webApp2.Setup(w => w.JavaVersion).Returns("1.8");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentPythonVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PythonVersion).Returns("3.7");
            webApp2.Setup(w => w.PythonVersion).Returns("3.8");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Python Version: 3.7 != 3.8", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SamePythonVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PythonVersion).Returns("3.7");
            webApp2.Setup(w => w.PythonVersion).Returns("3.7");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentNodeVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.NodeVersion).Returns("12.18");
            webApp2.Setup(w => w.NodeVersion).Returns("14.15");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("Node Version: 12.18 != 14.15", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameNodeVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.NodeVersion).Returns("12.18");
            webApp2.Setup(w => w.NodeVersion).Returns("12.18");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentPowerShellVersions_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PowerShellVersion).Returns("5.1");
            webApp2.Setup(w => w.PowerShellVersion).Returns("7.0");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("PowerShell Version: 5.1 != 7.0", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SamePowerShellVersions_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.PowerShellVersion).Returns("5.1");
            webApp2.Setup(w => w.PowerShellVersion).Returns("5.1");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentScmTypes_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.ScmType).Returns("LocalGit");
            webApp2.Setup(w => w.ScmType).Returns("GitHub");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("SCM Type: LocalGit != GitHub", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameScmTypes_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.ScmType).Returns("LocalGit");
            webApp2.Setup(w => w.ScmType).Returns("LocalGit");

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentHttp20Enabled_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.Http20Enabled).Returns(true);
            webApp2.Setup(w => w.Http20Enabled).Returns(false);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("HTTP/2.0 Enabled: True != False", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameHttp20Enabled_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.Http20Enabled).Returns(true);
            webApp2.Setup(w => w.Http20Enabled).Returns(true);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }

        [TestMethod]
        public void CompareWebApps_DifferentHttpsOnly_ReturnsDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.HttpsOnly).Returns(true);
            webApp2.Setup(w => w.HttpsOnly).Returns(false);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(1, differences.Count);
            Assert.AreEqual("HTTPS Only: True != False", differences[0]);
        }

        [TestMethod]
        public void CompareWebApps_SameHttpsOnly_ReturnsNoDifference()
        {
            var webApp1 = new Mock<IWebApp>();
            var webApp2 = new Mock<IWebApp>();

            webApp1.Setup(w => w.HttpsOnly).Returns(true);
            webApp2.Setup(w => w.HttpsOnly).Returns(true);

            var comparer = new AzureWebAppComparer();
            var differences = comparer.CompareWebApps(webApp1.Object, webApp2.Object);

            Assert.AreEqual(0, differences.Count);
        }
    }
}
