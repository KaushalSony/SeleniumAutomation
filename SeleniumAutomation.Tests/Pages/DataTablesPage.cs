using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomation.Tests.Pages
{
    public class DataTablesPage : BasePage
    {
        private readonly By _table1 = By.Id("table1");
        private readonly By _table2 = By.Id("table2");
        private readonly By _tableHeaders = By.CssSelector("th");
        private readonly By _tableRows = By.CssSelector("tbody tr");

        public DataTablesPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
        }

        public void ClickColumnHeader(string tableId, string columnName)
        {
            var table = tableId == "table1" ? _table1 : _table2;
            var headers = FindElement(table).FindElements(_tableHeaders);
            var header = headers.FirstOrDefault(h => h.Text.Contains(columnName));
            header?.Click();
        }

        public string[] GetColumnValues(string tableId, int columnIndex)
        {
            var table = tableId == "table1" ? _table1 : _table2;
            var rows = FindElement(table).FindElements(_tableRows);
            return rows.Select(row => row.FindElements(By.CssSelector("td"))[columnIndex].Text).ToArray();
        }

        public Dictionary<string, string[]> GetTableData(string tableId)
        {
            var table = tableId == "table1" ? _table1 : _table2;
            var headers = FindElement(table).FindElements(_tableHeaders);
            var rows = FindElement(table).FindElements(_tableRows);

            var data = new Dictionary<string, string[]>();
            for (int i = 0; i < headers.Count; i++)
            {
                data[headers[i].Text] = rows.Select(row => row.FindElements(By.CssSelector("td"))[i].Text).ToArray();
            }

            return data;
        }

        public bool IsTableSorted(string tableId, string columnName, bool ascending = true)
        {
            var table = tableId == "table1" ? _table1 : _table2;
            var headers = FindElement(table).FindElements(_tableHeaders);
            var columnIndex = headers.FindIndex(h => h.Text.Contains(columnName));

            var values = GetColumnValues(tableId, columnIndex);
            return ValueComparer.IsSorted(values, ascending);
        }
    }
} 