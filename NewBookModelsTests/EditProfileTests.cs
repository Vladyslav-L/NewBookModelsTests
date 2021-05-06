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

            var singInPage = new SingInPage(_webDriver);
            singInPage.GoToSingInPage()
                .SetEmail("StepanBizumm188@gmail.com")
                .SetPassword("QwE147AsD@-")
                .ClickSingUp();
            Thread.Sleep(3000);
        }

        [Test]
        public void CheckSuccessfulChangeGeneralInformation()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            accountSettingsInPage.ClickEditSwitcher();
            Thread.Sleep(1000);
            accountSettingsInPage
                .SetFirstName("Vitalik")
                .SetLastName("Pupkin")
                .SetIndustry("Bentley")
                .SetCompanyLocation("2459 Bentley Ave. Los Angeles CA 90025");
            Thread.Sleep(1000);
            accountSettingsInPage.ClickCompanyLocation();
            accountSettingsInPage.ClickSaveChanges();
            Thread.Sleep(2000);

            var actualResult = accountSettingsInPage.GetCompanyLocation();

            Assert.AreEqual("2459 Bentley Ave. Los Angeles CA 90025", actualResult);
        }

        [Test]
        public void CheckSuccessfulChangePassword()
        {
            var accountSettingsInPage = new AccountSettingsInPage(_webDriver);
            var singInPage = new SingInPage(_webDriver);
            accountSettingsInPage.GoToSingInPage();
            accountSettingsInPage.ClickEditPassword();
            Thread.Sleep(1000);
            accountSettingsInPage
            .SetPassword("QwE147AsD@-")
            .SetNewPassword("QwE147AsD@--")
            .SetReTypeNewPassword("QwE147AsD@--");
            accountSettingsInPage.ClickSaveChanges();
            Thread.Sleep(1000);
            accountSettingsInPage.ClickLogout();                       
            singInPage.GoToSingInPage()
                .SetEmail("StepanBizumm188@gmail.com")
                .SetPassword("QwE147AsD@--")
                .ClickSingUp();
            Thread.Sleep(3000);

            var actualMessage = _webDriver.Url;

            Assert.AreEqual("https://newbookmodels.com/join/company?goBackUrl=%2Fexplore", actualMessage);
        }
    }
}