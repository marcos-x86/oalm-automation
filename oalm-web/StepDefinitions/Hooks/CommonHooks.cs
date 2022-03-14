using oalm_web.Config;
using oalm_web.Pages;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public sealed class CommonHooks
{
    private string _downloadFolder = Environment.Config.GetProjectFolder() + Environment.Config.DownloadsFolder;
    private HomeBasePage _homeBasePage;

    public CommonHooks(HomeBasePage homeBasePage)
    {
        _homeBasePage = homeBasePage;
    }

    [AfterTestRun]
    public static void AfterFeatures()
    {
        LoginUtils.LogoutUser();
        Webdrivers.WebDriverManager.Instance.QuitDriver();
    }

    [AfterScenario]
    public void DeleteDownloads()
    {
        FileUtils.DeleteFilesInFolder(_downloadFolder);
    }
    
    [AfterScenario(Order = 100000)]
    [Scope(Tag = "logout")]
    public void Logout()
    {
        _homeBasePage.GetNavigationBar().ClickUsernameButton();
        _homeBasePage.GetNavigationBar().ClickLogoutButton();
    }
}