using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace SeleniumAutomation.Tests.Utils
{
    public static class WaitHelper
    {
        public static bool WaitForCondition(IWebDriver driver, Func<bool> condition, TimeSpan timeout, TimeSpan pollingInterval)
        {
            var wait = new WebDriverWait(driver, timeout);
            wait.PollingInterval = pollingInterval;

            try
            {
                return wait.Until(d => condition());
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public static bool WaitForElementToBeVisible(IWebDriver driver, By locator, TimeSpan timeout)
        {
            return WaitForCondition(driver, () =>
            {
                try
                {
                    return driver.FindElement(locator).Displayed;
                }
                catch
                {
                    return false;
                }
            }, timeout, TimeSpan.FromMilliseconds(500));
        }

        public static bool WaitForElementToBeInvisible(IWebDriver driver, By locator, TimeSpan timeout)
        {
            return WaitForCondition(driver, () =>
            {
                try
                {
                    return !driver.FindElement(locator).Displayed;
                }
                catch
                {
                    return true;
                }
            }, timeout, TimeSpan.FromMilliseconds(500));
        }

        public static bool WaitForElementToBeClickable(IWebDriver driver, By locator, TimeSpan timeout)
        {
            return WaitForCondition(driver, () =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed && element.Enabled;
                }
                catch
                {
                    return false;
                }
            }, timeout, TimeSpan.FromMilliseconds(500));
        }
    }
} 