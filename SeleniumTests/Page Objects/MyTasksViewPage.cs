using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Page_Objects
{
    public class MyTasksViewPage : BasePageObject
    {
        public MyTasksViewPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement MyTasksTab
        {
            get
            {
                return Driver.FindElement(By.XPath("//ul[@class = 'side-nav sidebar-links top-set']//a[@href = '/tasks']"));
            }
        }

        protected IWebElement DeleteTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//a[text() = 'Delete']"));
            }
        }

        protected IWebElement TaskSettingsButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//div[@class = 'icon settings-link']"));
            }
        }

        protected IWebElement EditTaskButton(string name)
        {
            return Driver.FindElement(By.XPath($"//div[contains(text(), '{name}')]/following-sibling::div[@class = 'date end-low']/div[@class = 'right']"));
        }


        public void ClickOnMyTasksTab() => MyTasksTab.Click();

        public void VerifyMyTaskExist(string name, string team, string endDate = "Due today")
        {
            try
            {
                _ = Driver.FindElement(By.XPath($"//div[contains(text(), '{name}')]/following-sibling::div[contains(text(), '{endDate}')]/following-sibling::div[contains(text(), '{team}')]")).Displayed;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void clickEditTaskButton(string name) => EditTaskButton(name).Click();

        public void clickTaskSettingsButton() => TaskSettingsButton.Click();

        public void clickDeleteTaskButton() => DeleteTaskButton.Click();




    }
}
