using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class LoginPage : BasePage
    {
        // Locators
        private readonly By _usernameField = By.Id("username");
        private readonly By _passwordField = By.Id("password");
        private readonly By _loginButton = By.CssSelector("button[type='submit']");
        private readonly By _flashMessage = By.Id("flash");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
        }

        public void EnterUsername(string username)
        {
            FindElement(_usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            FindElement(_passwordField).SendKeys(password);
        }

        public SecurePage ClickLoginButton()
        {
            FindElement(_loginButton).Click();
            return new SecurePage(_driver);
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

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }
    }
} 