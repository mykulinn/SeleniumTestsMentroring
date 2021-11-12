using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Page_Objects
{
    public class LoginPage : BasePageObject
    {
        public LoginPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }
        protected IWebElement EmailInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#user_email"));
            }
        }

        protected IWebElement PasswordInput
        {
            get
            {
                return Driver.FindElement(By.CssSelector("#user_password"));
            }
        }

        protected IWebElement LoginButton
        {
            get
            {
                return Driver.FindElement(By.CssSelector(".btn-login"));
            }
        }

        public void SetLogin(string login)
        {
            FillInInput(EmailInput, login);
        }

        public void SetPassword(string password)
        {
            FillInInput(PasswordInput, password);
        }

        public void ClickOnLoginButton()
        {
            LoginButton.Click();
        }

        public NavigatePanelPage Login(string login, string password)
        {
            SetLogin(login);
            SetPassword(password);
            ClickOnLoginButton();
            return new NavigatePanelPage(Driver, DriverWait);
        }
    }
}