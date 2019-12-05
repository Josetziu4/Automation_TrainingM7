using AutomationTraining_M7.Base_Files;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTraining_M7.Page_Objects
{
    class LinkedIn_SearchPage
    {

        //LOCATORS FOR EACH ELEMENT
        private static IWebDriver _objDriver;
        readonly static string STR_CAPTCHA_CLK = "//div[@class='recaptcha-checkbox-checkmark']";
        readonly static string STR_APPLY_BTN = "//button[@data-control-name='all_filters_apply']";
        readonly static string STR_SEARCH_BTN = "//div[@class='search-global-typeahead__controls']";
        readonly static string STR_SEARCH_TEXT = "//input[@placeholder='Search']";
        readonly static string STR_PEOPLE_BTN = "//button[span[text()='People']]";
        readonly static string STR_ALLFILTERS_BTN = "//button[span[text()='All Filters']]";
        readonly static string STR_LANG_ENG_CB = "//label[text()='English' or text()='Ingles']";
        readonly static string STR_LANG_ESP_CB = "//label[text()='Spanish' or text()='Español']";
        readonly static string STR_MXREGION_CB = "//label[text()='Mexico' or text()='México']";


        //CONSTRUCTOR
        public LinkedIn_SearchPage(IWebDriver pSrcDriver)
        {
            _objDriver = pSrcDriver;
        }

        /*IWEBELEMEMT OBJECTS*/
        private static IWebElement ObjCaptcha => _objDriver.FindElement(By.XPath(STR_CAPTCHA_CLK));
        private static IWebElement ObjSearchTxt => _objDriver.FindElement(By.XPath(STR_SEARCH_TEXT));
        private static IWebElement ObjSearchBtn => _objDriver.FindElement(By.XPath(STR_SEARCH_BTN));
        private static IWebElement ObjPeopleBtn => _objDriver.FindElement(By.XPath(STR_PEOPLE_BTN));
        private static IWebElement ObjAllFiltersBtn => _objDriver.FindElement(By.XPath(STR_ALLFILTERS_BTN));
        private static IWebElement ObjRegionMx => _objDriver.FindElement(By.XPath(STR_MXREGION_CB));
        private static IWebElement ObjLangEng => _objDriver.FindElement(By.XPath(STR_LANG_ENG_CB));
        private static IWebElement ObjLangEsp => _objDriver.FindElement(By.XPath(STR_LANG_ESP_CB));
        private static IWebElement ObjApplyBtn => _objDriver.FindElement(By.XPath(STR_APPLY_BTN));

        //METHODS
        //CAPTCHA
        private IWebElement GetCaptcha()
        {
            return ObjCaptcha;
        }
        public static void FnClickCaptcha()
        {
            ObjCaptcha.Click();
        }

        //SEARCH TEXT
        private IWebElement GetSearchField()
        {
            return ObjSearchTxt;
        }

        public static void FnEnterSearchText(string pstrSearchTxt)
        {
            ObjSearchTxt.Click();
            ObjSearchTxt.Clear();
            ObjSearchTxt.SendKeys(pstrSearchTxt);
        }

        //SEARCH BUTTON
        private IWebElement GetSearchButton()
        {
            return ObjSearchBtn;
        }

        public static void FnClickSearchBtn()
        {
            ObjSearchBtn.Click();
        }

        //People CheckBox
        private IWebElement GetPeopleBtn()
        {
            return ObjPeopleBtn;
        }

        public static void FnSelectPeople()
        {
            ObjPeopleBtn.Click();
        }

        //ALL FILTER
        private IWebElement GetAllFilters()
        {
            return ObjAllFiltersBtn;
        }

        public static void FnSelectAllFilters()
        {
            ObjAllFiltersBtn.Click();
        }

        //Location Mexico
        private IWebElement GetRegionMx()
        {
            return ObjRegionMx;
        }

        public static void FnGetRegionMx()
        {
            ObjRegionMx.Click();
        }

        //Language English
        private IWebElement GetLanguageEng()
        {
            return ObjLangEng;
        }

        public static void FnLanguageEng()
        {
            ObjLangEng.Click();
        }

        //Language Espanish
        private IWebElement GetLanguageEsp()
        {
            return ObjLangEsp;
        }

        public static void FnLanguageEsp()
        {
            ObjLangEsp.Click();
        }

        //Apply the Filters
        private IWebElement GetApplybutton()
        {
            return ObjApplyBtn;
        }

        public static void FnClickApplyBtn()
        {
            ObjApplyBtn.Click();
        }


    }

}
