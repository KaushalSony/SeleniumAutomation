using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomation.Tests.Pages
{
    public class FramePage : BasePage
    {
        private readonly By _iframe = By.Id("mce_0_ifr");
        private readonly By _editorBody = By.Id("tinymce");
        private readonly By _boldButton = By.CssSelector("button[aria-label='Bold']");
        private readonly By _italicButton = By.CssSelector("button[aria-label='Italic']");

        public FramePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
        }

        public void SwitchToFrame()
        {
            _driver.SwitchTo().Frame(FindElement(_iframe));
        }

        public void SwitchToMainContent()
        {
            _driver.SwitchTo().DefaultContent();
        }

        public void EnterText(string text)
        {
            var editor = FindElement(_editorBody);
            editor.Clear();
            editor.SendKeys(text);
        }

        public string GetEditorText()
        {
            return FindElement(_editorBody).Text;
        }

        public void ClickBoldButton()
        {
            SwitchToMainContent();
            FindElement(_boldButton).Click();
            SwitchToFrame();
        }

        public void ClickItalicButton()
        {
            SwitchToMainContent();
            FindElement(_italicButton).Click();
            SwitchToFrame();
        }
    }
} 