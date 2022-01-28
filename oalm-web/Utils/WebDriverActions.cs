using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace oalm_web.Utils
{
    public sealed class WebDriverActions
    {
        private static readonly WebDriverWait Wait = Webdrivers.WebDriverManager.Instance.GetWebDriverWait();

        public static void ClearText(By locator, String text)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.Clear();
        }

        public static void SetText(By locator, String text)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            ClearText(locator, text);
            element.SendKeys(text);
        }

        public static void Click(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }
        
        public static void DoubleClick(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementExists(locator));
            Actions actions = new Actions(Webdrivers.WebDriverManager.Instance.GetWebDriver());
            actions.DoubleClick(element).Perform();
        }     
        
        public static void PressEnter(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            element.SendKeys(Keys.Return);
        }

        public static String GetText(By locator)
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element.Text;
        }

        public static Boolean IsDisplayed(By locator)
        {
            try
            {
                IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element not found.");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean IsDisplayed(By locator, int time)
        {
            WebDriverWait wait = new WebDriverWait(Webdrivers.WebDriverManager.Instance.GetWebDriver(),
                new TimeSpan(0, 0, time));
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element not found.");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean AreDisplayed(List<By> elements)
        {
            return elements.TrueForAll(IsDisplayed);
        }

        public static void WaitUntilNotDisplayed(By locator)
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void SelectElementDropDownList(By locator, String text) 
        {
            IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            SelectElement dropdownList = new SelectElement(element);
            dropdownList.SelectByText(text);
        }
    }
}