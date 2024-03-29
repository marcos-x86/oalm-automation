﻿using System;
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

    [Given("the user logins with valid credentials using the '(.*)' database")]
    [When("the user logins with valid credentials using the '(.*)' database")]
    public void LoginWithValidCredentials(string dbName)
    {
        String username = Environment.Config.Username;
        String password = Environment.Config.Password;
        _loginPage.LoginWithCredentials(username, password, dbName);
    }

    [Given("the user selects '(.*)' database")]
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

    [When(@"the user clicks on OK")]
    public void ThenTheUserClicksOnOK()
    {
        _loginPage.ClickOKButton();
    }

}