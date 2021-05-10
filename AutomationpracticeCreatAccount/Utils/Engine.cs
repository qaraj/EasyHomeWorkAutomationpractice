

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace AutomationpracticeCreatAccount.Utils
{

    /// <summary>
    /// Common Selenium framework  reusable methods
    /// </summary>
    class Engine
    {
        public static IWebDriver Driver { get; set; }

        public void PrintMessage(String msg)
        {
            TestContext.Out.WriteLine(msg);
        }

        /// <summary>
        /// Wait for element to visible in application Overload method
        /// </summary>
        /// <param name="xpath">XPath locators from web application</param>
        public void WaitUntilElementFound(string xpath)
        {
            WaitUntilElementFound(By.XPath(xpath));
        }

        /// <summary>
        /// Wait for element to visible in application
        /// </summary>
        /// <param name="by"> By object  from web application</param>
        public void WaitUntilElementFound(By by)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocated‌​By(by));
        }


        /// <summary>
        /// The method waits for the element with the passed locator to become clickable(displayed and enabled)
        ///<param name="by"> the element locator we are waiting for action</param>
        /// <param name="waitInterval">  timespan for driver to  wait for the element to load in the DOM tree</param>
        /// <return> return the selected WebElement </return>
        public IWebElement WaitToBeClickable(By by, int waitInterval)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitInterval));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        /// <summary>
        /// The Overloaded method waits for the element with the passed locator to appear in  teh DOM tree
        ///<param name="xpath"> the  locator string we are waiting for presence</param>
        /// <param name="waitInterval">  timespan for driver to  wait for the element to appear in the DOM tree</param>
        /// <return> return the selected WebElement </return>
        public IWebElement WaitForElementPresence(string xpath, int waitInterval = 30)
        {
            return WaitForElementPresence(By.XPath(xpath), waitInterval);
        }

        /// <summary>
        /// The method waits for the element with the passed locator to appear in  teh DOM tree
        ///<param name="by"> the element locator we are waiting for presence</param>
        /// <param name="waitInterval">  timespan for driver to  wait for the element to appear in the DOM tree</param>
        /// <return> return the selected WebElement </return>
        public IWebElement WaitForElementPresence(By selector, int waitInterval = 30)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitInterval));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(selector));
            //if (element is ReadOnlyCollection<IWebElement>) return element[0];
            //if (element is IWebElement) return element;
            if (element != null) return element[0];
            return null;

        }

        /// <summary>
        /// The method to perform click action on button element
        ///<param name="locator"> the element locator to perform click action
        public void ClickOnElement(String locator)
        {
            Driver.FindElement(By.XPath(locator)).Click();
        }

        /// <summary>
        /// The method to enter the value in input box
        ///<param name="locator"> the element locator to perform click action </param>
        ///<param name="_value"> the data value to enter in the textbox </param>
        public void EnterValue(String locator, String _value)
        {
            //Driver.FindElement(By.XPath(locator)).SendKeys(_value);
            // mySendKey(By.XPath(locator), _value);
            WaitForElementPresence(locator).SendKeys(_value);
        }

        /// <summary>
        /// overload method to Select Dropdown By Text
        /// </summary>
        /// <param name="xpath">XPath locator to select</param>
        /// <param name="data">Value need to be selected</param>
        public void SelectDropDownByText(String xpath, String data)
        {
            IWebElement element = Driver.FindElement(By.XPath(xpath));
            SelectDropDownByText(element, data);
        }

        /// <summary>
        /// method to Select Dropdown By Text
        /// </summary>
        /// <param name="element">Element object</param>
        /// <param name="data">Value need to be selected</param>
        public void SelectDropDownByText(IWebElement element, String data)
        {
            try
            {
                new SelectElement(element).SelectByText(data);
            }
            catch (Exception e)
            {
                PrintMessage(e.Message);
            }
        }


        /// <summary>
        /// returns the text of the elements
        /// </summary>
        /// <param name="xpath"> pass the xpath to get the text value</param>
        /// <returns> string value of the field </returns>
        public string GetTextValueOfElement(string xpath)
        {
            WaitUntilElementFound(xpath);
            return Driver.FindElement(By.XPath(xpath)).GetAttribute("textContent"); ;
        }

        /// <summary>
        /// returns the CSS attribute data of the elements
        /// </summary>
        /// <param name="xpath"> pass the xpath of the element</param>
        /// <param name="attribute"> provide the attribute  to which get the  value</param>
        /// <returns> string value of the field </returns>
        public string GetCSSValueOfElement(string xpath, string attribute)
        {
            WaitUntilElementFound(xpath);
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(e => e.FindElement(By.XPath(xpath)));
            return element.GetCssValue(attribute);
        }

        /// <summary>
        /// Pause execution for specified time
        /// </summary>
        /// <param name="time"> Time in ms format</param>
        public static void Wait(int time = 2000)
        {
            var waitTill = DateTime.Now.AddMilliseconds(time);
            while (DateTime.Now < waitTill) ;
        }


        /// <summary>
        /// Launch Browser with the give URL
        /// </summary>
        public void OpenChromeBrowser()
        {
            String appURL = "http://automationpractice.com/index.php";
            try
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("test-type");
                options.AddArgument("-disable-extensions");
                options.AddArgument("--disable-gpu");
                options.AddArgument("start-maximized");
                options.LeaveBrowserRunning = true;
                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("disable-popup-blocking", "true");
                Driver = new ChromeDriver(options);
                Driver.Navigate().GoToUrl(appURL);
                PrintMessage("Test Application open Successfully. Test App URL: " + appURL);
            }
            catch (Exception ex)
            {
                PrintMessage("Test Application launch  Successfully. Test App URL: " + appURL + ". Error message:" + ex.InnerException.ToString());
            }
        }

        /// <summary>
        /// Verify the Existence of Element in application
        /// </summary>
        /// <param name="locator">Element</param>
        /// <returns> true or false </returns>
        public Boolean IsElementPresent(By Locator)
        {
            try
            {
                Driver.FindElement(Locator);
            }
            catch (Exception e)
            {
                PrintMessage(e.Message);
                return false;
            }
            return true;
        }

        //Just for reference, replacement of ElementToBeClickable
        public void mySendKey(By by, String _value, int waitInterval = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitInterval));
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = Driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(_value);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception : element located by {by.ToString()} not visible and enabled within {waitInterval} seconds.");
            }
        }


        public void TakeScreenShot(string filename = null)
        {
            if (filename == null) filename = "testfail";
            ITakesScreenshot screenshotDriver = Driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile("../../../output/"+filename+ DateTime.Now.ToString("yyyyMMddHHmmssffff")+".png", ScreenshotImageFormat.Png);
        }

    }
}
