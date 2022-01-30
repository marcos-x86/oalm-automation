using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace oalm_web.Webdrivers;

public class FirefoxBrowser : IBrowser
{
    public WebDriver GetDriver()
    {
        DriverManager manager = new DriverManager();
        manager.SetUpDriver(new FirefoxConfig());
        return new FirefoxDriver();
    }
}