using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Components;

public class NavigationBar
{
    private const string MenuItemBaseLocator = "//a[contains(@class,'menuItem') and text()='{0}']";
    private const string MenuEntryButtonBaseLocator = "#mainNav a[tab-menuname='{0}']";

    private By _logoImage = By.CssSelector("#logo");
    private By _usernameButton = By.CssSelector("#aUserName span[title='Username']");
    private By _logoutButton = By.CssSelector("a[onclick='top._status.logoutAfterNotify();']");

    public String GetUsernameDisplayed()
    {
        return WebDriverActions.GetText(_usernameButton);
    }

    public Boolean IsDisplayed()
    {
        List<By> elements = new List<By>()
        {
            _logoImage, _usernameButton
        };
        return WebDriverActions.AreDisplayed(elements);
    }

    public void ClickUsernameButton()
    {
        WebDriverActions.Click(_usernameButton);
    }

    public void ClickLogoutButton()
    {
        WebDriverActions.Click(_logoutButton);
    }

    public void ClickMenuEntryButton(string menuName)
    {
        string buttonCssLocator = String.Format(MenuEntryButtonBaseLocator, menuName.ToUpper());
        By buttonLocator = By.CssSelector(buttonCssLocator);
        WebDriverActions.Click(buttonLocator);
    }

    public void ClickMenuItem(string itemName)
    {
        By itemLocator = By.XPath(String.Format(MenuItemBaseLocator, itemName));
        WebDriverActions.Click(itemLocator);
    }
}