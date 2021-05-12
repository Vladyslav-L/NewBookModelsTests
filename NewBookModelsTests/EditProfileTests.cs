﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace NewBookModelsTests
{
    public class EditProfileTests
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
            var emailField = _webDriver.FindElement(By.CssSelector(("input[type=email]")));
            emailField.SendKeys("ValeraSergienko197804@gmail.com");
            var passwordlField = _webDriver.FindElement(By.CssSelector(("input[type=password]")));
            passwordlField.SendKeys("QwE147AsD@--");
            _webDriver.FindElement(By.CssSelector("[class^=SignInForm__submitButton]")).Click();
        }

        [Test]
        public void CheckSuccessfulChangeGeneralInformation()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");            
            _webDriver.FindElement(By.XPath("//nb-account-info-general-information[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]")).Click();
            var firstNameField = _webDriver.FindElement(By.CssSelector(("input[placeholder='Enter First Name']")));
            firstNameField.SendKeys("Vitalik");
            var lastNameField = _webDriver.FindElement(By.CssSelector(("input[placeholder='Enter Last Name']")));
            lastNameField.SendKeys("Pupkin");
            var industryField = _webDriver.FindElement(By.CssSelector(("input[placeholder='Enter Industry']")));
            industryField.SendKeys("Bentley");
            var companyLocationField = _webDriver.FindElement(By.CssSelector("input[placeholder='Enter Company Location']"));
            companyLocationField.SendKeys("2459 Bentley Ave. Los Angeles CA 90025");
            _webDriver.FindElement(By.XPath("//span[@class='pac-item-query']/span[@class='pac-matched']")).Click();
            _webDriver.FindElement(By.XPath("//button[contains(text(),'Save Changes')]")).Click();
            var actualResult = _webDriver.FindElement(By.XPath("//form[1]/div[2]/div[1]/nb-paragraph[3]/div[1]")).GetAttribute("class");             

            Assert.AreEqual("2459 Bentley Ave. Los Angeles CA 90025", actualResult);             
        }

        [Test]
        public void CheckSuccessfulChangePassword()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            //var singInPage = new SingInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            accountSettingsInPage.ClickEditPassword();
            Thread.Sleep(1000);
            accountSettingsInPage
            .SetPassword("QwE147AsD@--")
            .SetNewPassword("QwE147AsD@-")
            .SetReTypeNewPassword("QwE147AsD@-");
            accountSettingsInPage.ClickSaveChanges();
            Thread.Sleep(1000);
            accountSettingsInPage.ClickLogout();
            singInPage.GoToSingInPage()
                .SetEmail("LenOchkaIva195402@gmail.com")
                .SetPassword("QwE147AsD@-")
                .ClickSingUp();
            Thread.Sleep(3000);

            var actualMessage = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualMessage);
        }

        [Test]
        public void CheckSuccessfulAddCard()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            Thread.Sleep(1000);
            accountSettingsInPage
                .SetCardNumber("4627100101654724")
                .SetMmYy("1225")
                .SetCvc("123")
                .SetFullName("TEST");
            accountSettingsInPage.ClickSaveCard();

            var actualResult = accountSettingsInPage.GetCardNumber();

            Assert.AreEqual("4627100101654724", actualResult);
        }

        [Test]
        public void CheckUpdateCardErrorMessage()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            Thread.Sleep(1000);
            accountSettingsInPage
                .SetCardNumber("4544444444444444")
                .SetMmYy("1225")
                .SetCvc("123")
                .SetFullName("TEST");
            accountSettingsInPage.ClickSaveCard();
            Thread.Sleep(500);

            var actualMessage = accountSettingsInPage.GetUpdateErrorMessage();

            Assert.AreEqual("Update card info unexpected error", actualMessage);
        }
    }
}