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
        public void SuccessfulAuthorization()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");

            var searchFieldEmail = _webDriver.FindElement(By.CssSelector(
               "[name=email]"));

            searchFieldEmail.SendKeys("currentDate@gmail.com");

            var searchFieldPassword = _webDriver.FindElement(By.CssSelector(
               "[name=password]"));

            searchFieldPassword.SendKeys("QwE147AsD@-");

            _webDriver.FindElement(By.CssSelector(
               "[class^=SignInForm__submitButton]")).Click();

            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;           

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualResult);
        }
    }
}