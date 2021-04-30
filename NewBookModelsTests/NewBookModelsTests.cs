using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NewBookModelsTests
{
    

    public class RegistrationTests
    {
        private IWebDriver _webDriver;
        private IWebDriver _webDriver1;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);


        }

        [Test]
        public void Test1()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");  

            var searchField1 = _webDriver.FindElement(By.CssSelector(
                "[name=first_name]"));

            searchField1.SendKeys("Vitalik");

            var searchField2 = _webDriver.FindElement(By.CssSelector(
                "[name=last_name]"));

            searchField2.SendKeys("Pupkin");

            var searchField3 = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            searchField3.SendKeys("sagesar204@sejkt.com");

            var searchField4 = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchField4.SendKeys("QwE147AsD@-");

            var searchField5 = _webDriver.FindElement(By.CssSelector(
              "[name=password_confirm]"));

            searchField5.SendKeys("QwE147AsD@-");

            var searchField6 = _webDriver.FindElement(By.CssSelector(
             "[name=phone_number]"));

            searchField6.SendKeys("555.867.5309");

            _webDriver.FindElement(By.CssSelector(
             "[class^=SignupForm__submitButton]")).Click();


            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;     
            
            Assert.AreEqual("https://newbookmodels.com/join/company", actualResult);
        }

        [Test]
        public void Test2()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");

            var searchField1 = _webDriver.FindElement(By.CssSelector(
                "[name=first_name]"));

            searchField1.SendKeys("Vitalik");

            var searchField2 = _webDriver.FindElement(By.CssSelector(
                "[name=last_name]"));

            searchField2.SendKeys("Pupkin");

            var searchField3 = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            searchField3.SendKeys("mhx54105@cuoly.com");

            var searchField4 = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchField4.SendKeys("QwE147AsD@-");

            var searchField5 = _webDriver.FindElement(By.CssSelector(
              "[name=password_confirm]"));

            searchField5.SendKeys("QwE147AsD@-");

            var searchField6 = _webDriver.FindElement(By.CssSelector(
             "[name=phone_number]"));

            searchField6.SendKeys("555.867.5309");

            _webDriver.FindElement(By.CssSelector(
             "[class^=SignupForm__submitButton]")).Click();


            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", actualResult);
        }


    }

    class AuthorizationTests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void Test2()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            var searchField1 = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            searchField1.SendKeys("mhx54105@cuoly.com");

            var searchField2 = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchField2.SendKeys("QwE147AsD@-");

            _webDriver.FindElement(By.CssSelector(
               "[class^=SignInForm__submitButton]")).Click();

            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;           

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualResult);
        }
    }
}