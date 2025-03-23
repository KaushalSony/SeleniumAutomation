using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomation.Tests.Pages
{
    public class CheckboxesPage : BasePage
    {
        private readonly By _checkboxes = By.CssSelector("input[type='checkbox']");

        public CheckboxesPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
        }

        public void ClickCheckbox(int index)
        {
            var checkboxes = FindElements(_checkboxes);
            checkboxes[index].Click();
        }

        public bool IsCheckboxChecked(int index)
        {
            var checkboxes = FindElements(_checkboxes);
            return checkboxes[index].Selected;
        }

        public void ClickAllCheckboxes()
        {
            var checkboxes = FindElements(_checkboxes);
            foreach (var checkbox in checkboxes)
            {
                checkbox.Click();
            }
        }

        public List<bool> GetAllCheckboxStates()
        {
            var checkboxes = FindElements(_checkboxes);
            return checkboxes.Select(c => c.Selected).ToList();
        }
    }
} 