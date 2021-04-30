using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using System.Globalization;

namespace NewBookModelsTests
{


    public class RegistrationTests
    {
        private IWebDriver _webDriver;
        private string Text { get; }

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void FullRegistationTest()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");  

            var searchFieldFirstName = _webDriver.FindElement(By.CssSelector(
                "[name=first_name]"));

            searchFieldFirstName.SendKeys("Vitalik");

            var searchFieldLastName = _webDriver.FindElement(By.CssSelector(
                "[name=last_name]"));

            searchFieldLastName.SendKeys("Pupkin");

            var searchFieldEmail = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            var currentDate = DateTime.Now;
            string stringDate = currentDate.ToString("yyyyMMddHHmm");

            searchFieldEmail.SendKeys($"{stringDate}@gmail.com");

            var searchFieldPassword = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchFieldPassword.SendKeys("QwE147AsD@-");

            var searchFieldPasswordConfirm = _webDriver.FindElement(By.CssSelector(
              "[name=password_confirm]"));

            searchFieldPasswordConfirm.SendKeys("QwE147AsD@-");

            var searchFieldPhoneNumber = _webDriver.FindElement(By.CssSelector(
             "[name=phone_number]"));

            searchFieldPhoneNumber.SendKeys("555.867.5309");

            _webDriver.FindElement(By.CssSelector(
             "[class^=SignupForm__submitButton]")).Click();
                      
            Thread.Sleep(1000);

            var searchFieldCompanyName = _webDriver.FindElement(By.CssSelector(
             "[name=company_name]"));

            searchFieldCompanyName.SendKeys(stringDate);

             var searchFieldCompanyWebsite = _webDriver.FindElement(By.CssSelector(
             "[name=company_website]"));

            searchFieldCompanyWebsite.SendKeys("https://newbookmodels.com/");

             _webDriver.FindElement(By.CssSelector(
             "[name=industry]")).Click();

            _webDriver.FindElement(By.CssSelector(
             "[class^=Select__optionText]")).Click();

            var searchFieldLocation = _webDriver.FindElement(By.CssSelector(
            "[name=location]"));

            searchFieldLocation.SendKeys("2459 Bentley Ave. Los Angeles CA 90025");

            Thread.Sleep(2000);

            _webDriver.FindElement(By.CssSelector(
            "[class=pac-matched]")).Click();

            Thread.Sleep(1000);

            _webDriver.FindElement(By.CssSelector(
                 "[class^=SignupCompanyForm__submitButton]")).Click();
            
            Thread.Sleep(2000);

            var actualResult = _webDriver.Url;     
            
            Assert.AreEqual("https://newbookmodels.com/explore", actualResult);
        }

        [Test]
        public void ValidFirstNameForRegistation()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");

           _webDriver.FindElement(By.CssSelector(
                "[name=first_name]")).Click();
           
            _webDriver.FindElement(By.CssSelector(
                "[class^=FormErrorText__error]")).GetAttribute(Text);
            

            Assert.AreEqual("Required", Text);

           

        }

        [Test]
        public void Half egistration()
        {
            
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");

            var searchFieldFirstName = _webDriver.FindElement(By.CssSelector(
                "[name=first_name]"));

            searchFieldFirstName.SendKeys("Vitalik");

            var searchFieldLastName = _webDriver.FindElement(By.CssSelector(
                "[name=last_name]"));

            searchFieldLastName.SendKeys("Pupkin");

            var searchFieldEmail = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            var currentDate = new DateTime();
            string stringDate = currentDate.ToString("yyyyMMddHHmm");

            searchFieldEmail.SendKeys($"{currentDate}@gmail.com");

            var searchFieldPassword = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchFieldPassword.SendKeys("QwE147AsD@-");

            var searchFieldPasswordConfirm = _webDriver.FindElement(By.CssSelector(
              "[name=password_confirm]"));

            searchFieldPasswordConfirm.SendKeys("QwE147AsD@-");

            var searchFieldPhoneNumber = _webDriver.FindElement(By.CssSelector(
             "[name=phone_number]"));

            searchFieldPhoneNumber.SendKeys("555.867.5309");

            _webDriver.FindElement(By.CssSelector(
             "[class^=SignupForm__submitButton]")).Click();

            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", actualResult);
        }
    }
}