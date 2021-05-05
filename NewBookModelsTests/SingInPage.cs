using OpenQA.Selenium;

namespace NewBookModelsTests
{
    public class SingInPage
    {
        private readonly IWebDriver _webDriver;

        private static By _emailField = By.CssSelector("input[type=email]");
        private static By _passwordlField = By.CssSelector("input[type=password]");
        private static By _loginField = By.CssSelector("[class^=SignInForm__submitButton]");
        private static By _exceptionMessageAccountBlocked = By.XPath("//*[contains(@class, 'SignInForm__submitButton')]/../../div[contains(@class,'PageForm')][last()]");

        public SingInPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public SingInPage GoToSingInPage()
        {
            _webDriver.Navigate().GoToUrl("https://newbookmodels.com/auth/signin");
            return this;
        }

        public SingInPage SetEmail(string email)
        {
            _webDriver.FindElement(_emailField).SendKeys(email);
            return this;
        }

        public SingInPage SetPassword(string password)
        {
            _webDriver.FindElement(_passwordlField).SendKeys(password);
            return this;
        }

        public void ClickSingUp() =>
           _webDriver.FindElement(_loginField).Click();

        public string GetExceptionMessageAccountBlocked() =>
            _webDriver.FindElement(_exceptionMessageAccountBlocked).Text;
    }
}