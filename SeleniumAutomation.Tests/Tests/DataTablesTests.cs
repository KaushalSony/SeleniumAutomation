using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Drivers;
using SeleniumAutomation.Tests.Pages;
using System;

namespace SeleniumAutomation.Tests.Tests
{
    [TestFixture]
    public class DataTablesTests
    {
        private IWebDriver _driver;
        private DataTablesPage _dataTablesPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _dataTablesPage = new DataTablesPage(_driver);
            _dataTablesPage.NavigateTo();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        [Test]
        [TestCase("table1", "Last Name", true)]
        [TestCase("table1", "First Name", true)]
        [TestCase("table1", "Email", true)]
        [TestCase("table1", "Due", true)]
        [TestCase("table1", "Web Site", true)]
        [TestCase("table2", "Last Name", true)]
        [TestCase("table2", "First Name", true)]
        [TestCase("table2", "Email", true)]
        [TestCase("table2", "Due", true)]
        [TestCase("table2", "Web Site", true)]
        public void SortColumn_Ascending_ShouldSortCorrectly(string tableId, string columnName, bool ascending)
        {
            _dataTablesPage.ClickColumnHeader(tableId, columnName);
            Assert.That(_dataTablesPage.IsTableSorted(tableId, columnName, ascending), Is.True, 
                $"Column {columnName} should be sorted in {(ascending ? "ascending" : "descending")} order");
        }

        [Test]
        [TestCase("table1", "Last Name", false)]
        [TestCase("table1", "First Name", false)]
        [TestCase("table1", "Email", false)]
        [TestCase("table1", "Due", false)]
        [TestCase("table1", "Web Site", false)]
        [TestCase("table2", "Last Name", false)]
        [TestCase("table2", "First Name", false)]
        [TestCase("table2", "Email", false)]
        [TestCase("table2", "Due", false)]
        [TestCase("table2", "Web Site", false)]
        public void SortColumn_Descending_ShouldSortCorrectly(string tableId, string columnName, bool ascending)
        {
            _dataTablesPage.ClickColumnHeader(tableId, columnName);
            _dataTablesPage.ClickColumnHeader(tableId, columnName);
            Assert.That(_dataTablesPage.IsTableSorted(tableId, columnName, ascending), Is.True, 
                $"Column {columnName} should be sorted in {(ascending ? "ascending" : "descending")} order");
        }

        [Test]
        public void TableData_ShouldContainAllColumns()
        {
            var tableData = _dataTablesPage.GetTableData("table1");
            Assert.That(tableData.Keys, Has.Count.EqualTo(6), "Table should have 6 columns");
            Assert.That(tableData.Keys, Has.Some.Contains("Last Name"));
            Assert.That(tableData.Keys, Has.Some.Contains("First Name"));
            Assert.That(tableData.Keys, Has.Some.Contains("Email"));
            Assert.That(tableData.Keys, Has.Some.Contains("Due"));
            Assert.That(tableData.Keys, Has.Some.Contains("Web Site"));
        }
    }
} 