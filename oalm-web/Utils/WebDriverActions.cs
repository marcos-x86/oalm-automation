﻿using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace oalm_web.Utils;

public sealed class WebDriverActions
{
    private static readonly WebDriverWait Wait = Webdrivers.WebDriverManager.Instance.GetWebDriverWait();

    public static void ClearText(By locator)
    {
        IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        element.Clear();
    }

    public static void SetText(By locator, String text)
    {
        IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        ClearText(locator);
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

    public static void SwitchToFrame(By frameLocator)
    {
        IWebElement frameElement = Wait.Until(ExpectedConditions.ElementExists(frameLocator));
        Webdrivers.WebDriverManager.Instance.GetWebDriver().SwitchTo().Frame(frameElement);
    }

    public static void SwitchToDefaultFrame()
    {
        Webdrivers.WebDriverManager.Instance.GetWebDriver().SwitchTo().DefaultContent();
    }

    public static void WaitFixedTime(int millis)
    {
        Thread.Sleep(millis);
    }

    public static string GetAttribute(By locator, string attribute)
    {
        IWebElement element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        return element.GetAttribute(attribute);
    }

    public static void RefreshPage()
    {
        Webdrivers.WebDriverManager.Instance.GetWebDriver().Navigate().Refresh();
    }

    public static string GetPageTitle()
    {
        return Webdrivers.WebDriverManager.Instance.GetWebDriver().Title;
    }
    
    public static string GetPageUrl()
    {
        return Webdrivers.WebDriverManager.Instance.GetWebDriver().Url;
    }
}