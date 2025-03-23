using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Tests.Drivers;
using SeleniumAutomation.Tests.Pages;
using System;

namespace SeleniumAutomation.Tests.Tests
{
    [TestFixture]
    public class DynamicLoadingTests
    {
        private IWebDriver _driver;
        private DynamicLoadingExample1Page _example1Page;
        private DynamicLoadingExample2Page _example2Page;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _example1Page = new DynamicLoadingExample1Page(_driver);
            _example2Page = new DynamicLoadingExample2Page(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void Example1_ElementHidden_ShouldAppearAfterLoading(int timeoutSeconds)
        {
            // Arrange
            _example1Page.NavigateTo();
            Assert.That(_example1Page.IsElementHidden(), Is.True, "Element should be hidden initially");

            // Act
            var result = _example1Page.LoadElement();

            // Assert
            Assert.That(result, Is.EqualTo("Hello World!"), "Element text should match expected value");
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void Example2_ElementRendered_ShouldAppearAfterLoading(int timeoutSeconds)
        {
            // Arrange
            _example2Page.NavigateTo();
            Assert.That(_example2Page.IsElementRendered(), Is.False, "Element should not be rendered initially");

            // Act
            var result = _example2Page.LoadElement();

            // Assert
            Assert.That(result, Is.EqualTo("Hello World!"), "Element text should match expected value");
        }

        [Test]
        public void LoadingIndicator_ShouldDisappearAfterLoading()
        {
            // Arrange
            _example1Page.NavigateTo();

            // Act
            _example1Page.ClickStartButton();

            // Assert
            Assert.That(_example1Page.IsLoadingIndicatorDisplayed(), Is.True, "Loading indicator should be visible initially");
            Assert.That(WaitHelper.WaitForElementToBeInvisible(_driver, By.Id("loading"), TimeSpan.FromSeconds(10)), 
                Is.True, "Loading indicator should disappear after loading");
        }
    }
} 