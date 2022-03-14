using System;
using oalm_web.Pages;

namespace oalm_web.Utils;

public sealed class LoginUtils
{
    private const string HomePartialUrl = "/home";

    public static Boolean LoginWithUser(string username, string password, string dbName)
    {
        if (WebDriverActions.GetPageUrl().Contains(HomePartialUrl))
        {
            LoginPage loginPage = new LoginPage();
            if (loginPage.GetUsernameLabelText().Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                loginPage.ClickLogoImage();
                return true;
            }

            HomeBasePage homeBasePage = new HomeBasePage();
            homeBasePage.GetNavigationBar().ClickUsernameButton();
            homeBasePage.GetNavigationBar().ClickLogoutButton();

            loginPage.SetUsername(username);
            loginPage.ClickContinueButton();
            loginPage.SetPassword(password);
            loginPage.ClickLoginButton();
            loginPage.SelectDB(dbName);
            loginPage.ClickSelectDBButton();
            return true;
        }

        return false;
    }

    public static void LogoutUser()
    {
        if (WebDriverActions.GetPageUrl().Contains(HomePartialUrl))
        {
            HomeBasePage homeBasePage = new HomeBasePage();
            homeBasePage.GetNavigationBar().ClickUsernameButton();
            homeBasePage.GetNavigationBar().ClickLogoutButton();
        }
    }
}