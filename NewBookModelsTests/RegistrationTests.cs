using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace NewBookModelsTests
{

    public class RegistrationTests
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
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

        [Test]
        public void CheckSuccessfulFullRegistation()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            var firstNameField = _webDriver.FindElement(By.CssSelector(("input[name=first_name]")));
            firstNameField.SendKeys("Vitalik");
            var lastNameField = _webDriver.FindElement(By.CssSelector(("input[name=last_name]")));
            lastNameField.SendKeys("Pupkin");
            var emailField = _webDriver.FindElement(By.CssSelector(("input[name=email]")));
            var currentDate = DateTime.Now;
            string stringDate = currentDate.ToString("yyyyMMddHHmm");
            emailField.SendKeys($"{stringDate}12@gmail.com");
            var passwordField = _webDriver.FindElement(By.CssSelector(("input[name=password]")));
            passwordField.SendKeys("QwE147AsD@-");
            var passwordConfirmField = _webDriver.FindElement(By.CssSelector(("input[name=password_confirm]")));
            passwordConfirmField.SendKeys("QwE147AsD@-");
            var phoneNumberlField = _webDriver.FindElement(By.CssSelector(("input[name=phone_number]")));
            phoneNumberlField.SendKeys("555.867.5309");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();
            var companyNameField = _webDriver.FindElement(By.CssSelector(("input[name=company_name]")));
            companyNameField.SendKeys("MyFirstCompany");
            var companyWebsiteField = _webDriver.FindElement(By.CssSelector(("input[name=company_website]")));
            companyWebsiteField.SendKeys("https://newbookmodels.com/");
            var locationField = _webDriver.FindElement(By.CssSelector(("input[name=location]")));
            locationField.SendKeys("2459 Bentley Ave. Los Angeles CA 90025");
            _webDriver.FindElement(By.CssSelector("input[name=location]")).Click();
            Thread.Sleep(1000);
            _webDriver.FindElement(By.CssSelector("[class=pac-matched]")).Click();
            _webDriver.FindElement(By.CssSelector("input[name=industry]")).Click();
            Thread.Sleep(1000);
            _webDriver.FindElement(By.CssSelector("[class^=Select__optionText]")).Click();
            _webDriver.FindElement(By.CssSelector("button[class^=SignupCompanyForm__submitButton]")).Click();

            var actualResult = _webDriver.FindElement(By.XPath("//div[contains(text(),'Welcome Vitalik!')]")).Text;

            Assert.AreEqual("Welcome Vitalik! How can we help?", actualResult);
        }

        [Test]
        public void CheckExceptionMessageRequiredFirstName()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'first_name')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Required", actualMessage);
        }

        [Test]
        public void CheckExceptionMessageRequiredLastName()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'last_name')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Required", actualMessage);
        }

        [Test]
        public void CheckExceptionMessageRequiredEmail()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'email')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Required", actualMessage);
        }

        [Test]
        public void CheckExceptionMessageInvalidPassword()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'password')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Invalid password format", actualMessage);
        }

        [Test]
        public void CheckExceptionMessageInvalidPhoneNumber()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualMessage = _webDriver.FindElement(By.XPath("//*[contains(@name,'phone_number')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");

            Assert.AreEqual("Invalid phone format", actualMessage);
        }

        [Test]
        public void CheckSuccessfulHalfRegistration()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            var firstNameField = _webDriver.FindElement(By.CssSelector(("input[name=first_name]")));
            firstNameField.SendKeys("Vitalik");
            var lastNameField = _webDriver.FindElement(By.CssSelector(("input[name=last_name]")));
            lastNameField.SendKeys("Pupkin");
            var emailField = _webDriver.FindElement(By.CssSelector(("input[name=email]")));
            var currentDate = DateTime.Now;
            string stringDate = currentDate.ToString("yyyyMMddHHmm");
            emailField.SendKeys($"{stringDate}@gmail.com");
            var passwordField = _webDriver.FindElement(By.CssSelector(("input[name=password]")));
            passwordField.SendKeys("QwE147AsD@-");
            var passwordConfirmField = _webDriver.FindElement(By.CssSelector(("input[name=password_confirm]")));
            passwordConfirmField.SendKeys("QwE147AsD@-");
            var phoneNumberlField = _webDriver.FindElement(By.CssSelector(("input[name=phone_number]")));
            phoneNumberlField.SendKeys("555.867.5309");
            _webDriver.FindElement(By.CssSelector("[class^=SignupForm__submitButton]")).Click();

            var actualResult = _webDriver.FindElement(By.XPath("//h2[contains(text(),'Final step!')]")).Text;

            Assert.AreEqual("Final step!", actualResult);
        }
    }
}