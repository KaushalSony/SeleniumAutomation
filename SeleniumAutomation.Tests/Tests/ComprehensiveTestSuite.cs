using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Pages;
using System;
using System.IO;

namespace SeleniumAutomation.Tests.Tests
{
    [TestFixture]
    [Category("Smoke")]
    public class ComprehensiveTestSuite : TestBase
    {
        private LoginPage _loginPage;
        private DropdownPage _dropdownPage;
        private CheckboxesPage _checkboxesPage;
        private FileUploadPage _fileUploadPage;

        [SetUp]
        public void SetUp()
        {
            base.Setup();
            _loginPage = new LoginPage(_driver);
            _dropdownPage = new DropdownPage(_driver);
            _checkboxesPage = new CheckboxesPage(_driver);
            _fileUploadPage = new FileUploadPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            base.TearDown();
        }

        [Test]
        [Category("Critical")]
        public void Login_ValidCredentials_ShouldSucceed()
        {
            Log("Starting login test...");
            _loginPage.NavigateTo();
            var securePage = _loginPage.Login("tomsmith", "SuperSecretPassword!");
            Assert.That(securePage.IsSecureAreaDisplayed(), Is.True, "Secure area should be displayed.");
            Log("Login test completed successfully.");
        }

        [Test]
        [Category("Critical")]
        public void Dropdown_SelectOption_ShouldUpdateSelection()
        {
            Log("Starting dropdown test...");
            _dropdownPage.NavigateTo();
            _dropdownPage.SelectOption("1");
            Assert.That(_dropdownPage.GetSelectedOption(), Is.EqualTo("Option 1"), "Selected option should be Option 1.");
            Log("Dropdown test completed successfully.");
        }

        [Test]
        [Category("Critical")]
        public void Checkboxes_ToggleAll_ShouldUpdateStates()
        {
            Log("Starting checkboxes test...");
            _checkboxesPage.NavigateTo();
            var initialState = _checkboxesPage.GetAllCheckboxStates();
            _checkboxesPage.ClickAllCheckboxes();
            var finalState = _checkboxesPage.GetAllCheckboxStates();
            Assert.That(finalState, Is.Not.EqualTo(initialState), "Checkbox states should change.");
            Log("Checkboxes test completed successfully.");
        }

        [Test]
        [Category("Critical")]
        public void FileUpload_ValidFile_ShouldSucceed()
        {
            Log("Starting file upload test...");
            _fileUploadPage.NavigateTo();

            string filePath = _fileUploadPage.CreateTestFile();
            try
            {
                _fileUploadPage.UploadFile(filePath);
                Assert.That(_fileUploadPage.IsFileUploaded(Path.GetFileName(filePath)), Is.True, "File should be uploaded successfully.");
            }
            finally
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }

            Log("File upload test completed successfully.");
        }

        [Test]
        [Category("Regression")]
        public void CrossFeature_Workflow_ShouldComplete()
        {
            Log("Starting cross-feature workflow test...");

            // Login Step
            _loginPage.NavigateTo();
            var securePage = _loginPage.Login("tomsmith", "SuperSecretPassword!");
            Assert.That(securePage.IsSecureAreaDisplayed(), Is.True, "Login should succeed.");

            // Dropdown Step
            _dropdownPage.NavigateTo();
            _dropdownPage.SelectOption("2");
            Assert.That(_dropdownPage.GetSelectedOption(), Is.EqualTo("Option 2"), "Dropdown selection should work.");

            // Checkbox Step
            _checkboxesPage.NavigateTo();
            _checkboxesPage.ClickCheckbox(0);
            Assert.That(_checkboxesPage.IsCheckboxChecked(0), Is.True, "Checkbox should be checked.");

            // File Upload Step
            string filePath = _fileUploadPage.CreateTestFile();
            try
            {
                _fileUploadPage.UploadFile(filePath);
                Assert.That(_fileUploadPage.IsFileUploaded(Path.GetFileName(filePath)), Is.True, "File should be uploaded.");
            }
            finally
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }

            Log("Cross-feature workflow test completed successfully.");
        }
    }
}
