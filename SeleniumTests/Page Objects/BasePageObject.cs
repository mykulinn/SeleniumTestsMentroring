using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests.Page_Objects
{
    public class BasePageObject
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait DriverWait;

        public BasePageObject(IWebDriver driver, WebDriverWait driverWait)
        {
            Driver = driver;
            DriverWait = driverWait;
        }

        public BasePageObject(IWebDriver driver)
        {
            Driver = driver;
            DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
        }

        protected void FillInInput(IWebElement iWebElement, string inputText)
        {
            iWebElement.Click();
            iWebElement.Clear();
            iWebElement.SendKeys(inputText);
        }

        protected IWebElement DriverFindElementWithWait(By by)
        {
            return DriverWait.Until(SeleniumExtras.WaitHelpers
                                                  .ExpectedConditions
                                                  .ElementToBeClickable(by));
        }
    }
}