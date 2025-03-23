using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomation.Tests.Pages
{
    public class DropdownPage : BasePage
    {
        private readonly By _dropdown = By.Id("dropdown");

        public DropdownPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
        }

        public void SelectOption(string value)
        {
            var dropdown = new SelectElement(FindElement(_dropdown));
            dropdown.SelectByValue(value);
        }

        public string GetSelectedOption()
        {
            var dropdown = new SelectElement(FindElement(_dropdown));
            return dropdown.SelectedOption.Text;
        }

        public List<string> GetAllOptions()
        {
            var dropdown = new SelectElement(FindElement(_dropdown));
            return dropdown.Options.Select(o => o.Text).ToList();
        }
    }
} 