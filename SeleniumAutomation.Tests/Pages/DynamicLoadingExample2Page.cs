using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class DynamicLoadingExample2Page : DynamicLoadingPage
    {
        public DynamicLoadingExample2Page(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
        }

        public string LoadElement()
        {
            ClickStartButton();
            WaitForLoadingIndicatorToDisappear();
            return GetFinishText();
        }

        public bool IsElementRendered()
        {
            return IsFinishTextDisplayed();
        }
    }
} 