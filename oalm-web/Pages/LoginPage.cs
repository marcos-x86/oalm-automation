using System;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class LoginPage
{
    private By _usernameInput = By.CssSelector("#txtUsername");
    private By _passwordInput = By.CssSelector("#txtPassword");
    private By _continueButton = By.CssSelector("#btnCheckName");
    private By _loginButton = By.CssSelector("#btnLogin");
    private By _activeSessionModal = By.CssSelector("#layui-layer1");
    private By _activeSessionOkButton = By.CssSelector(".layui-layer-btn .layui-layer-btn1");
    private By _sessionSignOutModal = By.CssSelector(".layui-layer-dialog .fa-check-circle");
    private By _dropdownListDB = By.Id("dropdownlistContentselDatabases");
    private By _selectButtonDB = By.Id("btnSelectDatabase");
    private By _errorModalContent = By.CssSelector(".layui-layer-dialog .layui-layer-content");
    private By _okButton = By.CssSelector("a[class='layui-layer-btn0 btn btn-primary']");

    public void SetUsername(String username)
    {
        WebDriverActions.SetText(_usernameInput, username);
    }

    public void SetPassword(String password)
    {
        WebDriverActions.SetText(_passwordInput, password);
    }

    public void ClickContinueButton()
    {
        WebDriverActions.Click(_continueButton);
    }

    public void ClickLoginButton()
    {
        WebDriverActions.Click(_loginButton);
    }

    public void AcceptActiveSessionModal()
    {
        if (WebDriverActions.IsDisplayed(_activeSessionModal, 2))
        {
            WebDriverActions.Click(_activeSessionOkButton);
            WebDriverActions.WaitUntilNotDisplayed(_sessionSignOutModal);
        }
    }

    public void LoginWithCredentials(String username, String password)
    {
        SetUsername(username);
        ClickContinueButton();
        SetPassword(password);
        ClickLoginButton();
    }

    public void SelectDB(String dbName)
    {
        WebDriverActions.Click(_dropdownListDB);
    }

    public void ClickSelectDBButton()
    {
        WebDriverActions.Click(_selectButtonDB);
        AcceptActiveSessionModal();
    }

    public string GetErrorModalMessage()
    {
        return WebDriverActions.GetText(_errorModalContent);
    }

    public void ClickOKButton()
    {
        WebDriverActions.Click(_okButton);
    }
}