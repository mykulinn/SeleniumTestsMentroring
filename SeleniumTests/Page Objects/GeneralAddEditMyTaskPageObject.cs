using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTests.Page_Objects
{
    public class GeneralAddEditMyTaskPageObject : BasePageObject
    {
        public GeneralAddEditMyTaskPageObject(IWebDriver driver) : base(driver) { }

        protected IWebElement PriorityField
        {
            get
            {
                return Driver.FindElement(By.Id("s2id_task_priority"));
            }
        }



        protected IWebElement DescriptionField
        {
            get
            {
                return Driver.FindElement(By.Id("task_description"));
            }
        }

        protected IWebElement TitleField
        {
            get
            {
                return Driver.FindElement(By.Id("task_name"));
            }
        }

        protected IWebElement SearchPriorityFieldInput
        {
            get
            {
                return Driver.FindElement(By.XPath("//*[@id='select2-drop']/div/input"));
            }
        }

        protected IWebElement CreateTaskButton
        {
            get
            {
                return Driver.FindElement(By.XPath("//input[@class = 'button alert right']"));
            }
        }

        public void SetTitle(string titleValue)
        {
            DriverWait.Until(ExpectedConditions.ElementExists(By.Id("task_name")));
            FillInInput(TitleField, titleValue);
        }

        public void SetDescription(string descriptionValue)
        {
            FillInInput(DescriptionField, descriptionValue);
        }

        public void SetPriority(string priorityInputValue)
        {
            PriorityField.Click();
            SearchPriorityFieldInput.Clear();
            SearchPriorityFieldInput.SendKeys(priorityInputValue);
            SearchPriorityFieldInput.SendKeys(Keys.Return);
        }

        public void ClickCreateTaskButton() => CreateTaskButton.Click();


    }
}