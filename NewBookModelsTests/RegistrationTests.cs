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
            registrationInPage.SetCompanyName("fgfdgfd");
            registrationInPage.SetCompanyWebsite("https://newbookmodels.com/");
            registrationInPage.SetLocation("2459 Bentley Ave. Los Angeles CA 90025");
            registrationInPage.ClickLocation();
            Thread.Sleep(1000);
            registrationInPage.ClickPacMatched();
            registrationInPage.ClickIndustry();
            Thread.Sleep(1000);
            registrationInPage.ClickOptionText();            
            registrationInPage.ClickSignupCompanyFormButton();
            Thread.Sleep(1000);

            var actualMessage = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/explore", actualMessage);            
        }

        [Test]
        public void CheckExceptionMessageRequiredFirstName()
        {
            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage();
            registrationInPage.ClickNextButton();

            var actualMessage = registrationInPage.GetExceptionMessageRequiredFirstName();           

            Assert.AreEqual("Required", actualMessage);           
        }

        [Test]
        public void CheckExceptionMessageRequiredLastName()
        {
            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage();
            registrationInPage.ClickNextButton();

            var actualMessage = registrationInPage.GetExceptionMessageRequiredLastName();
                         
            Assert.AreEqual("Required", actualMessage); 
        }

         [Test]
        public void CheckExceptionMessageRequiredEmail()
        {
            var registrationInPage = new RegistrationInPage(_webDriver);
            registrationInPage.GoToRegistrationInPage();
            registrationInPage.ClickNextButton();

            var actualMessage = registrationInPage.GetExceptionMessageRequiredEmail();

            Assert.AreEqual("Required", actualMessage);           
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