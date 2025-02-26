using Microsoft.Azure.Management.AppService.Fluent;
using System.Collections.Generic;

namespace AzureConfigCompare
{
    public class AzureWebAppComparer
    {
        public List<string> CompareWebApps(IWebApp webApp1, IWebApp webApp2)
        {
            var differences = new List<string>();

            if (webApp1.Name != webApp2.Name)
            {
                differences.Add($"Name: {webApp1.Name} != {webApp2.Name}");
            }

            if (webApp1.RegionName != webApp2.RegionName)
            {
                differences.Add($"Region: {webApp1.RegionName} != {webApp2.RegionName}");
            }

            if (webApp1.ResourceGroupName != webApp2.ResourceGroupName)
            {
                differences.Add($"Resource Group: {webApp1.ResourceGroupName} != {webApp2.ResourceGroupName}");
            }

            if (webApp1.DefaultHostName != webApp2.DefaultHostName)
            {
                differences.Add($"Default Host Name: {webApp1.DefaultHostName} != {webApp2.DefaultHostName}");
            }

            if (webApp1.State != webApp2.State)
            {
                differences.Add($"State: {webApp1.State} != {webApp2.State}");
            }

            if (webApp1.AppServicePlanId != webApp2.AppServicePlanId)
            {
                differences.Add($"App Service Plan: {webApp1.AppServicePlanId} != {webApp2.AppServicePlanId}");
            }

            if (webApp1.OperatingSystem != webApp2.OperatingSystem)
            {
                differences.Add($"Operating System: {webApp1.OperatingSystem} != {webApp2.OperatingSystem}");
            }

            if (webApp1.NetFrameworkVersion != webApp2.NetFrameworkVersion)
            {
                differences.Add($".NET Framework Version: {webApp1.NetFrameworkVersion} != {webApp2.NetFrameworkVersion}");
            }

            if (webApp1.PhpVersion != webApp2.PhpVersion)
            {
                differences.Add($"PHP Version: {webApp1.PhpVersion} != {webApp2.PhpVersion}");
            }

            if (webApp1.JavaVersion != webApp2.JavaVersion)
            {
                differences.Add($"Java Version: {webApp1.JavaVersion} != {webApp2.JavaVersion}");
            }

            if (webApp1.PythonVersion != webApp2.PythonVersion)
            {
                differences.Add($"Python Version: {webApp1.PythonVersion} != {webApp2.PythonVersion}");
            }

            if (webApp1.NodeVersion != webApp2.NodeVersion)
            {
                differences.Add($"Node Version: {webApp1.NodeVersion} != {webApp2.NodeVersion}");
            }

            if (webApp1.PowerShellVersion != webApp2.PowerShellVersion)
            {
                differences.Add($"PowerShell Version: {webApp1.PowerShellVersion} != {webApp2.PowerShellVersion}");
            }

            if (webApp1.ScmType != webApp2.ScmType)
            {
                differences.Add($"SCM Type: {webApp1.ScmType} != {webApp2.ScmType}");
            }

            if (webApp1.Http20Enabled != webApp2.Http20Enabled)
            {
                differences.Add($"HTTP/2.0 Enabled: {webApp1.Http20Enabled} != {webApp2.Http20Enabled}");
            }

            if (webApp1.HttpsOnly != webApp2.HttpsOnly)
            {
                differences.Add($"HTTPS Only: {webApp1.HttpsOnly} != {webApp2.HttpsOnly}");
            }

            return differences;
        }
    }
}
