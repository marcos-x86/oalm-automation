using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public sealed class CommonHooks
{
    private HomeBasePage _homeBasePage;

    public CommonHooks(HomeBasePage homeBasePage)
    {
        _homeBasePage = homeBasePage;
    }

    [AfterTestRun]
    public static void AfterWebFeature()
    {
        Webdrivers.WebDriverManager.Instance.QuitDriver();
    }

    [AfterScenario(Order = 100000)]
    [Scope(Tag = "logout")]
    public void Logout()
    {
        _homeBasePage.GetNavigationBar().ClickUsernameButton();
        _homeBasePage.GetNavigationBar().ClickLogoutButton();
    }
}