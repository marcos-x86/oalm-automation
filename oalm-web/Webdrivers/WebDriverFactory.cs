using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace oalm_web.Webdrivers;

public sealed class WebDriverFactory
{
    private WebDriverFactory()
    {
    }

    public static WebDriver GetDriver(String driverType)
    {
        Dictionary<String, IBrowser> strategy = new Dictionary<String, IBrowser>();
        strategy.Add("CHROME", new ChromeBrowser());
        strategy.Add("FIREFOX", new FirefoxBrowser());
        return strategy[driverType.ToUpper()].GetDriver();
    }
}