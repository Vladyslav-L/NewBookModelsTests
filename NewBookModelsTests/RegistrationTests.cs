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
            var currentDate = DateTime.Now;
            string stringDate = currentDate.ToString("yyyyMMddHHmm");

            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage()
                .SetFirstName("Vitalik")
                .SetLastName("Pupkin")
                .SetEmail($"{stringDate}@gmail.com")
                .SetPassword("QwE147AsD@-")
                .SetPasswordConfirm("QwE147AsD@-")
                .SetPhoneNumber("555.867.5309")
                .ClickNextButton();
            registrationInPage.GoToNextRegistrationInPage()
                .SetCompanyName("fgfdgfd")
                .SetCompanyWebsite("https://newbookmodels.com/")
                .SetLocation("2459 Bentley Ave. Los Angeles CA 90025")
                .ClickIndustry();
            registrationInPage.ClickOptionText();
            registrationInPage.ClickPacMatched();
            registrationInPage.ClickSignupCompanyFormButton();            

            var actualMessage = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualMessage);            
        }

        [Test]
        public void ErrorMessageIfFirstNameIsNullForRegistation()
        {       
           _webDriver.FindElement(By.CssSelector(
                "[name=first_name]")).Click();

            _webDriver.FindElement(By.CssSelector(
                "[name=last_name]")).Click();

            var result = _webDriver.FindElement(By.CssSelector(
                "[class^=FormErrorText__error]")).GetProperty("innerText");            

            Assert.AreEqual("Required", result); 
        }

        [Test]
        public void ErrorMessageIfLastNameIsNullForRegistation()
        {
            _webDriver.FindElement(By.CssSelector(
               "[class^=SignupForm__submitButton]")).Click();                

            var result = _webDriver.FindElement(By.XPath(
                "//*[contains(@name,'last_name')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");            

            Assert.AreEqual("Required", result); 
        }

         [Test]
        public void ErrorMessageIfEmailIsNullForRegistation()
        {
            _webDriver.FindElement(By.CssSelector(
               "[class^=SignupForm__submitButton]")).Click();                

            var result = _webDriver.FindElement(By.XPath(
                "//*[contains(@name,'email')]/../div[contains(@class,'FormErrorText')]")).GetProperty("innerText");            

            Assert.AreEqual("Required", result); 
        }

         [Test]
        public void CheckExceptionMessageInvalidPassword()
        {
            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage();           
            registrationInPage.ClickNextButton();
            var actualMessage = registrationInPage.GetExceptionMessageInvalidPassword();

            Assert.AreEqual("Invalid password format", actualMessage);            
        }

         [Test]
        public void CheckExceptionMessageInvalidPhoneNumber()
        {
            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage();
            registrationInPage.ClickNextButton();
            var actualMessage = registrationInPage.GetExceptionMessageInvalidPhoneFormat();

            Assert.AreEqual("Invalid phone format", actualMessage);
        }

        [Test]
        public void HalfRegistration()
        {
            var currentDate = DateTime.Now;
            string stringDate = currentDate.ToString("yyyyMMddHHmm");

            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage()
                .SetFirstName("Vitalik")
                .SetLastName("Pupkin")
                .SetEmail($"{stringDate}@gmail.com")
                .SetPassword("QwE147AsD@-")
                .SetPasswordConfirm("QwE147AsD@-")
                .SetPhoneNumber("555.867.5309")
                .ClickNextButton();

            Thread.Sleep(5000);

            var actualResult = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company", actualResult);  
        }
    }
}