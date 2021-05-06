using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NewBookModelsTests
{
    public class AuthorizationTests
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
            var singInPage = new SingInPage(_webDriver);
            singInPage.GoToSingInPage()
                .SetEmail("StepanBizumm188@gmail.com")
                .SetPassword("QwE147AsD@-")
                .ClickSingUp();
            Thread.Sleep(1000);

            var actualMessage = _webDriver.Url;          

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualMessage);           
        }

        [Test]
        public void CheckAuthorizationExceptionMessage()
        {
            var singInPage = new SingInPage(_webDriver);
            singInPage.GoToSingInPage()
                .SetEmail("currentDate@gmail.com")
                .SetPassword("QwE147AsD@-")
                .ClickSingUp();
            Thread.Sleep(1000);
            
            var actualMessage = singInPage.GetExceptionMessageAccountBlocked();

            Assert.AreEqual("User account is blocked.", actualMessage);           
        }
    }
}