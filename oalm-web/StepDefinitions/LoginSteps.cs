using System;
using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;
using Environment = oalm_web.Config.Environment;

namespace oalm_web.StepDefinitions;

[Binding]
public sealed class LoginSteps
{
    private readonly String _baseUrl = Environment.Config.BaseUrl;
    private LoginPage _loginPage;

    public LoginSteps(LoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    [Given("the user goes to the login page")]
    public void GotoLoginPage()
    {
        Webdrivers.WebDriverManager.Instance.GetWebDriver().Navigate().GoToUrl(_baseUrl);
    }

    [When("the user logins with valid credentials")]
    public void LoginWithValidCredentials()
    {
        String username = Environment.Config.Username;
        String password = Environment.Config.Password;
        _loginPage.LoginWithCredentials(username, password);
    }

    [When("the user selects '(.*)' database")]
    public void WhenTheUserSelectsDatabase(string dbName)
    {
        _loginPage.SelectDB(dbName);
        _loginPage.ClickSelectDBButton();
    }

    [When("the user logins with the '(.*)' username")]
    public void WhenTheUserLoginsWithTheUsername(string username)
    {
        _loginPage.SetUsername(username);
        _loginPage.ClickContinueButton();
    }

    [Then("verifies that a error message modal is displayed with the following text")]
    public void VerifyErrorMessageModal(string expectedContent)
    {
        Assert.AreEqual(expectedContent, _loginPage.GetErrorModalMessage());
    }
}