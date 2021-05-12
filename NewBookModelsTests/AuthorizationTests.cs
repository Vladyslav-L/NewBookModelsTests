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
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CheckSuccessfulAuthorization()
        {            
            var emailField = _webDriver.FindElement(By.CssSelector(("input[type=email]")));
            emailField.SendKeys("LenOchkaIva195402@gmail.com");
            var passwordlField = _webDriver.FindElement(By.CssSelector(("input[type=password]")));
            passwordlField.SendKeys("QwE147AsD@--");
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();

            var actualResult = _webDriver.FindElement(By.XPath("//h2[contains(text(),'Final step!')]")).Text;

            Assert.AreEqual("Final step!", actualResult);
        }

        [Test]
        public void CheckAuthorizationExceptionMessage()
        {            
            var emailField = _webDriver.FindElement(By.CssSelector(("input[type=email]")));
            emailField.SendKeys("currentDate@gmail.com");
            var passwordlField = _webDriver.FindElement(By.CssSelector(("input[type=password]")));
            passwordlField.SendKeys("QwE147AsD@-");
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//div[contains(text(),'User account is blocked.')]")).Text;

            Assert.AreEqual("User account is blocked.", actualMessage);
        }

        [Test]
        public void CheckExceptionMessageRequiredEmail()
        {
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'email')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Required", actualMessage);
        }

         [Test]
        public void CheckExceptionMessageInvalidPassword()
        {
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'password')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Required", actualMessage);
        }
    }
}