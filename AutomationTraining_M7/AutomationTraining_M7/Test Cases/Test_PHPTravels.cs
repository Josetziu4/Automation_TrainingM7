﻿using AutomationTraining_M7.Base_Files;
using AutomationTraining_M7.Page_Objects;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTraining_M7.Test_Cases
{
    class Test_PHPTravels : BaseTest
    {
        clsPHPTravels_LoginPage objPHP;
        public WebDriverWait wait;

        [Test]
        public void Test_M9Exercise()
        {
            //Init objects
            objTest = objExtent.CreateTest(TestContext.CurrentContext.Test.Name);
            objPHP = new clsPHPTravels_LoginPage(driver);
            //Assert.AreEqual(true, driver.FindElement(By.Name("email")), "The Login Page was not loaded correctly.");
            //Login Action
            //Assert.AreEqual("Administrador Login.", driver.Title);
            
            Assert.AreEqual(true, driver.Title.Contains("Administator Login"), "The Login Page was not loaded correctly.");
            clsPHPTravels_LoginPage.fnEnterEmail(ConfigurationManager.AppSettings.Get("email"));
            clsPHPTravels_LoginPage.fnEnterPassword(ConfigurationManager.AppSettings.Get("password"));
            clsPHPTravels_LoginPage.fnClickLoginButton();
            //Open LiveChat

            clsPHPTravels_LoginPage.fnClickOpenLiveChat();
            //Close LiveChat
            clsPHPTravels_LoginPage.fnClickCloseLiveChat();
            
            //Click HamburguerMenu
            clsPHPTravels_LoginPage.fnWaitHamburgerMenu();
            clsPHPTravels_LoginPage.fnClickHamburgerMenu();
            
            //Assert.AreEqual(true, driver.Title.Contains("Dashboard"), "The Dashboard was not loaded correctly.");
            
            //Close Accounts Menu
            clsPHPTravels_LoginPage.fnClickAccountsMenu();
            List<string> strTotVal = clsPHPTravels_LoginPage.fnGetTotalsValuesTxt();
            foreach (var item in strTotVal)
            {
                objRM.fnAddStepLog(objTest, item, "Pass");
            }

        }

    }
}
