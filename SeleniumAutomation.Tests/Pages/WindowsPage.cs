using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class WindowsPage : BasePage
    {
        private readonly By _clickHereLink = By.LinkText("Click Here");
        private readonly By _newWindowHeading = By.TagName("h3");

        public WindowsPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
        }

        public void ClickHere()
        {
            FindElement(_clickHereLink).Click();
        }

        public void SwitchToNewWindow()
        {
            var windows = _driver.WindowHandles;
            _driver.SwitchTo().Window(windows[windows.Count - 1]);
        }

        public void SwitchToOriginalWindow()
        {
            var windows = _driver.WindowHandles;
            _driver.SwitchTo().Window(windows[0]);
        }

        public string GetNewWindowHeading()
        {
            return FindElement(_newWindowHeading).Text;
        }

        public void CloseNewWindow()
        {
            _driver.Close();
            SwitchToOriginalWindow();
        }
    }
} 