using System;
using oalm_web.Utils;
using OpenQA.Selenium;
using Environment = oalm_web.Config.Environment;

namespace oalm_web.Pages;

public class LoginPage
{
    private const string HomePartialUrl = "/home";
    private String LoginBaseUrl = Environment.Config.BaseUrl;
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
    private By _usernameLabel = By.CssSelector("span[title='Username']");
    private By _logoImage = By.CssSelector("#logo");

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

    public void ClickLogoImage()
    {
        WebDriverActions.Click(_logoImage);
    }

    public string GetUsernameLabelText()
    {
        return WebDriverActions.GetText(_usernameLabel);
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
        
        if (WebDriverActions.GetPageUrl().Contains(HomePartialUrl))
        {
            LoginUtils.CheckLoggedUser(this, username, password);
            return;
        }

        Webdrivers.WebDriverManager.Instance.GetWebDriver().Navigate().GoToUrl(LoginBaseUrl);
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