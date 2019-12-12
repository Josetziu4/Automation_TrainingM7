﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTraining_M7.Reporting
{
    class clsReportManager
    {
        private DateTime time = DateTime.Now;

        public string fnReportPath()
        {
            var strPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var strActualPath = strPath.Substring(0, strPath.LastIndexOf("bin"));
            var strProjectPath = new Uri(strActualPath).LocalPath;
            Directory.CreateDirectory(strProjectPath.ToString() + "ExtentReports");
            var strReportPath = strProjectPath + "ExtentReports\\ExtentReports_" + time.ToString("MMddyyyy_HHmmss") + ".html"; //+ "_" +time.ToString("HHmmss") +".html";
            return strReportPath;
        }

        //public void fnReportSetUp(ExtentHtmlReporter phtmlReporter, ExtentReports pExtent)
        public void fnReportSetUp(ExtentV3HtmlReporter phtmlReporter, ExtentReports pExtent)
        {
            //DateTime time = DateTime.Now;
            phtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            phtmlReporter.Config.DocumentTitle = "Automation Framework Report";
            pExtent.AttachReporter(phtmlReporter);
            pExtent.AddSystemInfo("Project Name:", "Automation Framework");
            pExtent.AddSystemInfo("Application:", "LinkedIn");
            pExtent.AddSystemInfo("Environment:", "QAA");
            pExtent.AddSystemInfo("Browser:", ConfigurationManager.AppSettings.Get("browser"));
            pExtent.AddSystemInfo("Date:", time.ToShortDateString());
            pExtent.AddSystemInfo("Version:", "v1.0");
        }

        public string fnCaptureImage(IWebDriver pobjDriver, string pstrScreenName)
        {
            /*Create SS directory*/
            ITakesScreenshot objITake = (ITakesScreenshot)pobjDriver;
            Screenshot objSS = objITake.GetScreenshot();
            var strSSPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var strActualPath = strSSPath.Substring(0, strSSPath.LastIndexOf("bin"));
            var strReportPath = new Uri(strActualPath).LocalPath;
            Directory.CreateDirectory(strReportPath.ToString() + "ExtentReports\\Screenshots");
            /*Save Image*/
            var strFullPath = strSSPath.Substring(0, strSSPath.LastIndexOf("bin")) + "ExtentReports\\Screenshots\\" + pstrScreenName;
            var strLocalPath = new Uri(strFullPath).LocalPath;
            objSS.SaveAsFile(strLocalPath, ScreenshotImageFormat.Png);
            return strReportPath;
        }

        public void fnTestCaseResult(ExtentTest pobjTest, ExtentReports pobjExtent, IWebDriver pobjDriver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
           ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    //DateTime time = DateTime.Now;
                    //string strFileName = "Screenshot_" + time.ToShortDateString() + ".png";
                    string strFileName = "Screenshot_" + time.ToString("hh_mm_ss") + ".png";
                    fnCaptureImage(pobjDriver, strFileName);
                    pobjTest.Log(Status.Fail, "Fail");
                    pobjTest.Log(Status.Fail, "Snapshot below: " + pobjTest.AddScreenCaptureFromPath("Screenshots\\" + strFileName));
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                case TestStatus.Passed:
                    logstatus = Status.Pass;
                    break;
                default:
                    logstatus = Status.Warning;
                    Console.WriteLine("The status: " + status + " is not supported.");
                    break;
            }
            pobjTest.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            pobjExtent.Flush();
        }

    }
}
