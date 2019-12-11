﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTraining_M7.Reporting
{
    class clsReportManager
    {
        public string fnReportPath()
        {
            var strPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var strActualPath = strPath.Substring(0, strPath.LastIndexOf("bin"));
            var strProjectPath = new Uri(strActualPath).LocalPath;
            Directory.CreateDirectory(strProjectPath.ToString() + "ExtentReports");            
            var strReportPath = strProjectPath + "ExtentReports\\ExtentReports.html";
            return strReportPath;

        }

        public void fnReportSetup(ExtentHtmlReporter phtmlReporter, ExtentReports pExtent)
        {
            phtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            phtmlReporter.Config.DocumentTitle = "Automation Framework Report";
            pExtent.AttachReporter(phtmlReporter);
            pExtent.AddSystemInfo("Project  Name:", "LinkedIn");
            pExtent.AddSystemInfo("Environment:", "QAA");
            pExtent.AddSystemInfo("Browser:", "Chrome");
            pExtent.AddSystemInfo("Date:", "00/00/2019");
            pExtent.AddSystemInfo("Version", "v1.0");
        }

        public string fnCaaptureImage(IWebDriver pobjDriver, string pstrSreenName)
        {
            /*Create SS directory */
            ITakesScreenshot objITake = (ITakesScreenshot)pobjDriver;
            Screenshot objSS = objITake.GetScreenshot();
            var strSSPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var strActualPath = strSSPath.Substring(0, strSSPath.LastIndexOf("bin"));
            var strReportPath = new Uri(strActualPath).LocalPath;
            Directory.CreateDirectory(strReportPath.ToString() + "ExtentReports\\Screenshots");
            /*Save Image(sreenshoot)*/
            var strFullPath = strSSPath.Substring(0, strSSPath.LastIndexOf("bin")) + "ExtentReports\\Screenshots";
            var strLocalPath = new Uri(strFullPath).LocalPath;
            objSS.SaveAsFile(strLocalPath, ScreenshotImageFormat.Png);
            return strReportPath;
        }

        public void fnTestCaseResult(ExtentTest pobjTest, ExtentReports pobjExtent, IWebDriver pobjDriver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stactrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    string strFileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    fnCaaptureImage(pobjDriver, strFileName);
                    pobjTest.Log(Status.Fail, "Fail");
                    pobjTest.Log(Status.Fail, "Snapshot below:" + pobjTest.AddScreenCaptureFromPath("Screenshots\\" + strFileName));
                    break;
            }

        }
    }
}
