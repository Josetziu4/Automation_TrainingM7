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
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTraining_M7.Test_Cases
{
    class Test_PHPTravels : BaseTest
    {
        clsPHPTravels_LoginPage objPHP;
        

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
            clsPHPTravels_LoginPage.fnWaitHamburgerMenu();
            clsPHPTravels_LoginPage.fnGetTotalsValuesTxt();
            clsPHPTravels_LoginPage.fnClickAccountsMenu();
            clsPHPTravels_LoginPage.fnGetAccountsSubMenu();






            //Open LiveChat

            //clsPHPTravels_LoginPage.fnClickOpenLiveChat();



            //Close LiveChat            
            //clsPHPTravels_LoginPage.fnClickCloseLiveChat();

            //Click HamburguerMenu
            //clsPHPTravels_LoginPage.fnWaitHamburgerMenu();
            //clsPHPTravels_LoginPage.fnClickHamburgerMenu();
            //Thread.Sleep(5000);
            //clsPHPTravels_LoginPage.fnClickHamburgerMenu();
            //clsPHPTravels_LoginPage.fnClickHamburgerMenu();
            //clsPHPTravels_LoginPage.fnClickHamburgerMenu();
            //Assert.AreEqual(true, driver.Title.Contains("Dashboard"), "The Dashboard was not loaded correctly.");

            //Close Accounts Menu


        }

    }
}
