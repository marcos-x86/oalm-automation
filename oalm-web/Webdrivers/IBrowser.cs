using OpenQA.Selenium;

namespace oalm_web.Webdrivers;

public interface IBrowser
{
    WebDriver GetDriver();
}