using oalm_web.Config;
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
        var chromeOptions = new ChromeOptions();
        var downloadDirectory = Environment.Config.GetProjectFolder() + Environment.Config.DownloadsFolder;
        chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
        chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
        chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
        return new ChromeDriver(chromeOptions);
    }
}