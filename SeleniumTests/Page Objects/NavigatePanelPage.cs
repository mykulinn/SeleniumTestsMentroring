using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Page_Objects
{
    public class NavigatePanelPage : BasePageObject
    {
        public NavigatePanelPage(IWebDriver driver, WebDriverWait driverWait) : base(driver, driverWait)
        {
        }

        protected IWebElement CreateNewTaskButton
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("/html/body/div[1]/nav/section/ul[1]/li"));
            }
        }

        protected IWebElement LogoutButton
        {
            get
            {
                return DriverFindElementWithWait(By.XPath("/html/body/div/div[1]/ul[3]/li[2]/a[contains(text(),'Logout')]"));
            }
        }


        public void ClickOnCreateNewTaskButton()
        {
            CreateNewTaskButton.Click();
        }
        public void ClickOnLogoutButton() => LogoutButton.Click();

    }
}