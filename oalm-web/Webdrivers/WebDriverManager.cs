using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Environment = oalm_web.Config.Environment;

namespace oalm_web.Webdrivers;

public sealed class WebDriverManager
{
    private static WebDriverManager _instance;

    private WebDriver _webDriver;
    private WebDriverWait _webDriverWait;

    private WebDriverManager()
    {
        _webDriver = WebDriverFactory.GetDriver(Environment.Config.Browser);
        _webDriverWait = new WebDriverWait(_webDriver,
            new TimeSpan(0, 0, Environment.Config.ExplicitWaitTime));
        _webDriver.Manage().Window.Maximize();
    }

    public static WebDriverManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new WebDriverManager();
            }

            return _instance;
        }
    }

    public WebDriver GetWebDriver()
    {
        return _webDriver;
    }

    public WebDriverWait GetWebDriverWait()
    {
        return _webDriverWait;
    }

    public void QuitDriver()
    {
        _webDriver.Quit();
        _webDriver = null;
    }
}