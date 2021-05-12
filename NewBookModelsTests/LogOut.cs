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
    public class LogOutTests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            var emailField = _webDriver.FindElement(By.CssSelector(("input[type=email]")));
            emailField.SendKeys("LenOchkaIva195402@gmail.com");
            var passwordlField = _webDriver.FindElement(By.CssSelector(("input[type=password]")));
            passwordlField.SendKeys("QwE147AsD@--");
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();
        }

        [Test]
        public void CheckSuccessfulLogOut()
        {    
            _webDriver.FindElement(By.XPath("//header/div[1]/div[1]/div[2]/div[2]/div[1]")).Click();
            _webDriver.FindElement(By.XPath("//button[contains(text(),'Sign Out')]")).Click();

            var actualResult = _webDriver.FindElement(By.XPath("//div[contains(text(),'Client Sign In')]")).Text;                 

            Assert.AreEqual("Client Sign In", actualResult);
        }

        [Test]
        public void CheckSuccessfulLogOutInAccountSettingsPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
        
            _webDriver.FindElement(By.XPath("//header/div[1]/div[1]/div[2]/div[2]/div[1]")).Click();
            _webDriver.FindElement(By.XPath("//div[contains(text(),' Log out of your account ')]")).Click();

            var actualResult = _webDriver.FindElement(By.XPath("//div[contains(text(),'Client Sign In')]")).Text;                 

            Assert.AreEqual("Client Sign In", actualResult);
        }
    }
}