using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class SecurePage : BasePage
    {
        // Locators
        private readonly By _logoutButton = By.CssSelector("a.button.secondary.radius");
        private readonly By _flashMessage = By.Id("flash");
        private readonly By _secureAreaHeading = By.TagName("h2");

        public SecurePage(IWebDriver driver) : base(driver)
        {
            WaitForElementVisible(_secureAreaHeading);
        }

        public string GetFlashMessage()
        {
            return FindElement(_flashMessage).Text;
        }

        public bool IsFlashMessageDisplayed()
        {
            try
            {
                return FindElement(_flashMessage).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public LoginPage ClickLogoutButton()
        {
            FindElement(_logoutButton).Click();
            return new LoginPage(_driver);
        }

        public string GetSecureAreaHeading()
        {
            return FindElement(_secureAreaHeading).Text;
        }

        public bool IsSecureAreaDisplayed()
        {
            try
            {
                return FindElement(_secureAreaHeading).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
} 