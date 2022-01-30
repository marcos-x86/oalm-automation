using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace oalm_web.Webdrivers;

public class ChromeBrowser : IBrowser
{
    public WebDriver GetDriver()
    {
        DriverManager manager = new DriverManager();
        manager.SetUpDriver(new ChromeConfig());
        return new ChromeDriver();
    }
}