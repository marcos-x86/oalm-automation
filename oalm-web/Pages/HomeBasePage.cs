using System;
using oalm_web.Pages.Components;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class HomeBasePage
{
    private const string TabBaseLocator = "//div[@class='content-tabs']//descendant::*[contains(text(),'{0}')]";

    private const string CloseTabBaseLocator =
        "//div[@class='content-tabs']//descendant::*[contains(text(),'{0}')]//descendant::i";

    private By _pageLoader = By.CssSelector("#pageLoader");
    private NavigationBar _navigationBar;
    private FooterBar _footerBar;

    public HomeBasePage()
    {
        _navigationBar = new NavigationBar();
        _footerBar = new FooterBar();
    }

    public NavigationBar GetNavigationBar()
    {
        return _navigationBar;
    }

    public FooterBar GetFooterBar()
    {
        return _footerBar;
    }

    public Boolean IsTabPresent(string tabName)
    {
        string locator = String.Format(TabBaseLocator, tabName);
        return WebDriverActions.IsDisplayed(By.XPath(locator));
    }

    public void WaitUntilLoadIsCompleted()
    {
        WebDriverActions.WaitUntilNotDisplayed(_pageLoader);
    }

    public void CloseActiveTab(string tabDataId)
    {
        string locator = String.Format(CloseTabBaseLocator, tabDataId);
        WebDriverActions.Click(By.XPath(locator));
    }
}