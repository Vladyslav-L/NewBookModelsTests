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
    public class LogOutTests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

            var singInPage = new SingInPage(_webDriver);
            singInPage.GoToSingInPage()
                .SetEmail("StepanBizumm188@gmail.com")
                .SetPassword("QwE147AsD@-")
                .ClickSingUp();
            Thread.Sleep(3000);
        }

        [Test]
        public void CheckSuccessfulLogOut()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            accountSettingsInPage.ClickLogout();
            Thread.Sleep(1000);

             var actualResult = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/auth/signin", actualResult);
        }
    }
}