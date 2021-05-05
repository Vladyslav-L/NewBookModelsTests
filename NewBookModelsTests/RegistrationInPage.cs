using OpenQA.Selenium;

namespace NewBookModelsTests
{
    public class RegistrationInPage
    {
        private readonly IWebDriver _webDriver;

        private static By _firstNameField = By.CssSelector("input[type=first_name]");
        private static By _lastNameField = By.CssSelector("input[type=last_name]");
        private static By _emailField = By.CssSelector("input[type=email]");
        private static By _passwordField = By.CssSelector("input[type=password]");
        private static By _passwordConfirmField = By.CssSelector("input[type=password_confirm]");
        private static By _phoneNumberlField = By.CssSelector("input[type=phone_number]");
        private static By _nextButton = By.CssSelector("class^=SignupForm__submitButton]");
        private static By _companyNameField = By.CssSelector("input[type=company_name]");
        private static By _companyWebsiteField = By.CssSelector("input[type=company_website]");
        private static By _industryField = By.CssSelector("input[type=industry]");
        private static By _optionTextField = By.CssSelector("[class^=Select__optionText]");
        private static By _locationField = By.CssSelector("input[type=location]");
        private static By _pacMatchedField = By.CssSelector("[class=pac-matched]");
        private static By _signupCompanyFormButton = By.CssSelector("[class^=SignupCompanyForm__submitButton]");
        //private static By _ExceptionMessageAccountBlocked = By.XPath(

        public RegistrationInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public RegistrationInPage GoToRegistrationInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join");
            return this;
        }

         public RegistrationInPage GoToNextRegistrationInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/join/company");
            return this;
        }

        public RegistrationInPage SetFirstName(string firstName)
        {
            _webDriver.FindElement(_firstNameField).SendKeys(firstName);
            return this;
        }

        public RegistrationInPage SetLastName(string lastName)
        {
            _webDriver.FindElement(_lastNameField).SendKeys(lastName);
            return this;
        }

        public RegistrationInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public RegistrationInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordField).SendKeys(password);
            return this;
        }

        public RegistrationInPage SetPasswordConfirm(string passwordConfirm)
        {
            _webDriver.FindElement(_passwordConfirmField).SendKeys(passwordConfirm);
            return this;
        }

        public RegistrationInPage SetPhoneNumber(string phoneNumber)
        {
            _webDriver.FindElement(_phoneNumberlField).SendKeys(phoneNumber);
            return this;
        }

        public void ClickNextButton() =>
            _webDriver.FindElement(_nextButton).Click();

        public RegistrationInPage SetCompanyName(string companyName)
        {
            _webDriver.FindElement(_companyNameField).SendKeys(companyName);
            return this;
        }

        public RegistrationInPage SetCompanyWebsite(string companyWebsite)
        {
            _webDriver.FindElement(_companyWebsiteField).SendKeys(companyWebsite);
            return this;
        }

        public RegistrationInPage SetLocation(string location)
        {
            _webDriver.FindElement(_locationField).SendKeys(location);
            return this;
        }

        public void ClickIndustry() =>
            _webDriver.FindElement(_companyWebsiteField).Click();

        public void ClickOptionText() =>
            _webDriver.FindElement(_optionTextField).Click();

        public void ClickPacMatched() =>
            _webDriver.FindElement(_pacMatchedField).Click();

        public void ClickSignupCompanyFormButton() =>
           _webDriver.FindElement(_signupCompanyFormButton).Click();
    }
}