using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Drivers;
using SeleniumAutomation.Tests.Pages;
using System;

namespace SeleniumAutomation.Tests.Tests
{
    [TestFixture]
    public class WindowsAndFramesTests
    {
        private IWebDriver _driver;
        private WindowsPage _windowsPage;
        private FramePage _framePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _windowsPage = new WindowsPage(_driver);
            _framePage = new FramePage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        [Test]
        public void NewWindow_ShouldOpenAndDisplayCorrectContent()
        {
            _windowsPage.NavigateTo();
            _windowsPage.ClickHere();
            _windowsPage.SwitchToNewWindow();

            Assert.That(_windowsPage.GetNewWindowHeading(), Is.EqualTo("New Window"), 
                "New window should display correct heading");

            _windowsPage.CloseNewWindow();
        }

        [Test]
        public void Frame_ShouldAllowTextEntryAndFormatting()
        {
            _framePage.NavigateTo();
            _framePage.SwitchToFrame();

            var testText = "Test text for formatting";
            _framePage.EnterText(testText);
            Assert.That(_framePage.GetEditorText(), Is.EqualTo(testText), 
                "Text should be entered correctly");

            _framePage.ClickBoldButton();
            _framePage.ClickItalicButton();

            _framePage.SwitchToMainContent();
            Assert.That(_driver.Url, Does.Contain("/iframe"), 
                "Should remain on iframe page after formatting");
        }
    }
} 