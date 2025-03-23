using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Drivers;
using SeleniumAutomation.Tests.Pages;
using System;

namespace SeleniumAutomation.Tests.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _loginPage = new LoginPage(_driver);
            _loginPage.NavigateTo();
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        [Test]
        [TestCase("tomsmith", "SuperSecretPassword!", "You logged into a secure area!")]
        public void ValidLogin_ShouldSucceed(string username, string password, string expectedMessage)
        {
            // Act
            var securePage = _loginPage.Login(username, password);

            // Assert
            Assert.That(securePage.IsSecureAreaDisplayed(), Is.True, "Secure area should be displayed");
            Assert.That(securePage.GetFlashMessage(), Does.Contain(expectedMessage), "Success message should be displayed");
            Assert.That(securePage.GetCurrentUrl(), Does.Contain("/secure"), "URL should contain /secure");
        }

        [Test]
        [TestCase("invaliduser", "SuperSecretPassword!", "Your username is invalid!")]
        [TestCase("tomsmith", "wrongpassword", "Your password is invalid!")]
        [TestCase("", "", "Your username is invalid!")]
        public void InvalidLogin_ShouldShowErrorMessage(string username, string password, string expectedMessage)
        {
            // Act
            _loginPage.Login(username, password);

            // Assert
            Assert.That(_loginPage.IsFlashMessageDisplayed(), Is.True, "Flash message should be displayed");
            Assert.That(_loginPage.GetFlashMessage(), Does.Contain(expectedMessage), "Error message should match expected message");
            Assert.That(_loginPage.GetCurrentUrl(), Does.Contain("/login"), "Should remain on login page");
        }
    }
} 