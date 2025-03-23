using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace SeleniumAutomation.Tests.Pages
{
    public class FileUploadPage : BasePage
    {
        private readonly By _fileInput = By.Id("file-upload");
        private readonly By _uploadButton = By.Id("file-submit");
        private readonly By _uploadedFiles = By.Id("uploaded-files");

        public FileUploadPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/upload");
        }

        public void UploadFile(string filePath)
        {
            FindElement(_fileInput).SendKeys(filePath);
            FindElement(_uploadButton).Click();
        }

        public string GetUploadedFileName()
        {
            return FindElement(_uploadedFiles).Text;
        }

        public bool IsFileUploaded(string fileName)
        {
            return GetUploadedFileName().Contains(fileName);
        }

        public string CreateTestFile()
        {
            var fileName = $"test_file_{DateTime.Now:yyyyMMddHHmmss}.txt";
            var filePath = Path.Combine(Path.GetTempPath(), fileName);
            File.WriteAllText(filePath, "Test file content");
            return filePath;
        }
    }
} 