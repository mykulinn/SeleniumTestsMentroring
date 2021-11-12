using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Data;
using SeleniumTests.Page_Objects;

namespace SeleniumTests.Tests
{
    public class VerifyTaskTest
    {
        private IWebDriver browser;
        private WebDriverWait driverWait;
        private LoginPage LoginPage;
        private NavigatePanelPage NavigatePanelPage;
        private GeneralAddEditMyTaskPageObject addMyNewTask;
        private MyTasksViewPage myTasksViewPage;

        [SetUp]
        public void SetUp()
        {
            browser = new ChromeDriver();
            driverWait = new WebDriverWait(browser, new TimeSpan(0, 0, 5));
            NavigatePanelPage = new NavigatePanelPage(browser, driverWait);
            LoginPage = new LoginPage(browser, driverWait);
            addMyNewTask = new GeneralAddEditMyTaskPageObject(browser);
            myTasksViewPage = new MyTasksViewPage(browser);

            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(CommonTestData.UrlForLoginPage);
        }

        [Test]
        public void VerifyTask()
        {
            LoginPage.Login(CommonTestData.AdminEmail, CommonTestData.Password);
            NavigatePanelPage.ClickOnCreateNewTaskButton();
            addMyNewTask.SetTitle("TestAutomationTask_1");
            addMyNewTask.SetDescription("TestAutomationTask_1_Description");
            addMyNewTask.SetPriority("Medium");
            addMyNewTask.ClickCreateTaskButton();
            myTasksViewPage.ClickOnMyTasksTab();
            myTasksViewPage.VerifyMyTaskExist("TestAutomationTask_1", "DevOps");
        }

        [TearDown]
        public void LogOut()
        {
            myTasksViewPage.clickEditTaskButton("TestAutomationTask_1");
            myTasksViewPage.clickTaskSettingsButton();
            myTasksViewPage.clickDeleteTaskButton();
            NavigatePanelPage.ClickOnLogoutButton();
            browser.Quit();
        }
    }
}
