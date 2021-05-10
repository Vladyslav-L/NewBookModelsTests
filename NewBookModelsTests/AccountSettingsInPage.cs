using OpenQA.Selenium;

namespace NewBookModelsTests
{
    public class AccountSettingsInPage
    {
        private readonly IWebDriver _webDriver;

        private static By _editSwitcherField = By.XPath("//body/nb-app[1]/ng-component[1]/nb-internal-layout[1]/common-layout[1]/section[1]/div[1]/ng-component[1]/nb-account-info-edit[1]/common-border[1]/div[1]/div[1]/nb-account-info-general-information[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static By _cancelField = By.XPath("//div[contains(text(),'CANCEL')]");
        private static By _firstNameField = By.CssSelector("input[placeholder='Enter First Name']");
        private static By _lastNameField = By.CssSelector("input[placeholder='Enter Last Name']");
        private static By _companyLocationField = By.CssSelector("input[placeholder='Enter Company Location']");
        private static By _companyLocation = By.XPath("//span[@class='pac-item-query']/span[@class='pac-matched']");
        private static By _companyLocationForm = By.XPath("//form[1]/div[2]/div[1]/nb-paragraph[3]/div[1]");
        private static By _industryField = By.CssSelector("input[placeholder='Enter Industry']");
        private static By _saveChangesButton = By.XPath("//button[contains(text(),'Save Changes')]");
        private static By _passwordField = By.CssSelector("input[placeholder='Enter Password']");
        private static By _newPasswordField = By.CssSelector("input[placeholder = 'Enter New Password']");
        private static By _reTypeNewPasswordField = By.XPath("//form[1]/div[2]/div[1]/common-input[3]/label[1]/input[1]");
        private static By _editPasswordField = By.CssSelector("//div[3]/div[1]/nb-account-info-password[1]/form[1]/div[1]/div[1]/nb-edit-switcher[1]/div[1]/div[1]");
        private static By _emailField = By.CssSelector("input[placeholder='Enter E-mail']");
        private static By _logoutField = By.CssSelector("[class='link link_type_logout link_active']");
        private static By _fullNameField = By.CssSelector("input[placeholder='Full name']");
        private static By _cardNumberField = By.CssSelector("input[placeholder='Card number']");
        private static By _cvcField = By.CssSelector("input[placeholder='CVC']");
        private static By _mmYyField = By.CssSelector("input[placeholder='MM / YY']");
        private static By _saveButton = By.XPath("//button[contains(text(),'Save')]");
        private static By _stripeField = By.CssSelector("input[class='StripeField--fake']");
        private static By _updateErrorMessage = By.XPath("//span[contains(text(),'Update card info unexpected error')]");

        public AccountSettingsInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AccountSettingsInPage GoToSingInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/account-settings/account-info/edit");
            return this;
        }

        public AccountSettingsInPage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }

        public AccountSettingsInPage SetLastName(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public AccountSettingsInPage SetCompanyLocation(string companyLocation)
        {
            _webDriver.FindElement(_companyLocationField).SendKeys(companyLocation);
            return this;
        }

        public AccountSettingsInPage SetIndustry(string industry)
        {
            _webDriver.FindElement(_industryField).SendKeys(industry);
            return this;
        }

        public AccountSettingsInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public AccountSettingsInPage SetNewPassword(string password)
        {
            _webDriver.FindElement(_newPasswordField).SendKeys(password);
            return this;
        }

        public AccountSettingsInPage SetReTypeNewPassword(string password)
        {
            _webDriver.FindElement(_reTypeNewPasswordField).SendKeys(password);
            return this;
        }

        public AccountSettingsInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public AccountSettingsInPage SetFullName(string fullName)
        {
            _webDriver.FindElement(_fullNameField).SendKeys(fullName);
            return this;
        }

        public AccountSettingsInPage SetCardNumber(string cardNumber)
        {
            _webDriver.FindElement(_cardNumberField).SendKeys(cardNumber);
            return this;
        }

        public AccountSettingsInPage SetMmYy(string mmYy)
        {
            _webDriver.FindElement(_mmYyField).SendKeys(mmYy);
            return this;
        }

        public AccountSettingsInPage SetCvc(string cvc)
        {
            _webDriver.FindElement(_cvcField).SendKeys(cvc);
            return this;
        }

        public void ClickEditSwitcher() =>
            _webDriver.FindElement(_editSwitcherField).Click();

        public void ClickCompanyLocation() =>
            _webDriver.FindElement(_companyLocation).Click();

        public void ClickSaveChanges() =>
            _webDriver.FindElement(_saveChangesButton).Click();

        public void ClickLogout() =>
           _webDriver.FindElement(_logoutField).Click();

        public void ClickEditPassword() =>
           _webDriver.FindElement(_editPasswordField).Click();

        public string GetCompanyLocation() =>
            _webDriver.FindElement(_companyLocationForm).Text;

        public string GetUpdateErrorMessage() =>
           _webDriver.FindElement(_updateErrorMessage).GetAttribute("class");

        public void ClickSaveCard() =>
            _webDriver.FindElement(_saveButton).Click();

        public string GetCardNumber() =>
            _webDriver.FindElement(_cardNumberField).Text;

        public void ClickStripeField() =>
           _webDriver.FindElement(_stripeField).Click();

    }
}