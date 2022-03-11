using System;
using oalm_web.Pages;

namespace oalm_web.Utils;

public sealed class LoginUtils
{
    public static void CheckLoggedUser(LoginPage page, string username, string password)
    {
        if (page.GetUsernameLabelText().Equals(username, StringComparison.OrdinalIgnoreCase))
        {
            page.ClickLogoImage();
            return;
        }

        HomeBasePage homeBasePage = new HomeBasePage();
        homeBasePage.GetNavigationBar().ClickUsernameButton();
        homeBasePage.GetNavigationBar().ClickLogoutButton();

        page.SetUsername(username);
        page.ClickContinueButton();
        page.SetPassword(password);
        page.ClickLoginButton();
    }
}