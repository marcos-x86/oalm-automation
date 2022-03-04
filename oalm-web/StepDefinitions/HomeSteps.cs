using System;
using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;
using Environment = oalm_web.Config.Environment;

namespace oalm_web.StepDefinitions;

[Binding]
public sealed class HomeSteps
{
    private HomeBasePage _homeBasePage;

    public HomeSteps(HomeBasePage homeBasePage)
    {
        _homeBasePage = homeBasePage;
    }

    [When("the user clicks on '(.*)' menu in the navigation bar")]
    public void ClicksMenuEntry(string menuName)
    {
        _homeBasePage.GetNavigationBar().ClickMenuEntryButton(menuName);
    }

    [When("the user clicks the '(.*)' menu item button")]
    public void ClicksMenuItem(string menuItem)
    {
        _homeBasePage.GetNavigationBar().ClickMenuItem(menuItem);
    }

    [Then("verifies that the Home page is displayed")]
    public void VerifyHomePageDisplayed()
    {
        _homeBasePage.WaitUntilLoadIsCompleted();
        Assert.IsTrue(_homeBasePage.GetFooterBar().IsDisplayed());
    }

    [Then("verifies that the username is displayed in the Main Navigation bar")]
    public void VerifyUsernameDisplayed()
    {
        String expectedUsername = Environment.Config.Username;
        Assert.AreEqual(expectedUsername, _homeBasePage.GetNavigationBar().GetUsernameDisplayed());
    }

    [Then("the user logs out")]
    public void ThenTheUserLogOut()
    {
        _homeBasePage.GetNavigationBar().ClickUsernameButton();
        _homeBasePage.GetNavigationBar().ClickLogoutButton();
    }
    
    [Then("verifies that the '(.*)' tab is present")]
    public void AssertTabIsPresent(string tabName)
    {
        Assert.True(_homeBasePage.IsTabPresent(tabName));
    }
}