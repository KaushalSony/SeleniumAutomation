using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class DynamicLoadingPage
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;

        // Constructor to initialize driver and wait
        public DynamicLoadingPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Clicks on the Start button
        protected void ClickStartButton()
        {
            var startButton = _driver.FindElement(By.CssSelector("#start button"));
            startButton.Click();
        }

        // Waits for the loading spinner to disappear
        protected void WaitForLoadingIndicatorToDisappear()
        {
            _wait.Until(d => 
            {
                var loading = d.FindElement(By.Id("loading"));
                return !loading.Displayed;
            });
        }

        // Gets the text after loading finishes
        protected string GetFinishText()
        {
            var finishElement = _driver.FindElement(By.Id("finish"));
            return finishElement.Text;
        }

        // Checks if the finish text is displayed
        protected bool IsFinishTextDisplayed()
        {
            try
            {
                var finishElement = _driver.FindElement(By.Id("finish"));
                return finishElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
