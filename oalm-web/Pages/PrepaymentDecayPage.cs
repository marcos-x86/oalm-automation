using System;
using oalm_web.Pages.Menus;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class PrepaymentDecayPage : HomeBasePage
{
    private const string MenuItemBaseLocator = "//div[@id='moreButtons_Menu']//descendant::li[text()='{0}']";
    private ExportSelectorMenu _exportSelectorMenu;
    private By _dotsIconButton = By.CssSelector("#btnMore");
    private By _prepaymentDecayFrame = By.CssSelector("[name='iframePrepaymentDecayTables']");
    private By _closeTabIcon = By.CssSelector("a[data-id='PrepaymentDecayTables'] i.fa-remove");

    public PrepaymentDecayPage()
    {
        _exportSelectorMenu = new ExportSelectorMenu();
    }

    public ExportSelectorMenu GetExportSelectorMenu()
    {
        return _exportSelectorMenu;
    }
    
    public void ClickDotsIconButton()
    {
        WebDriverActions.WaitFixedTime(1500);
        WebDriverActions.SwitchToFrame(_prepaymentDecayFrame);
        WebDriverActions.Click(_dotsIconButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnMoreOptionsMenuItem(string item)
    {
        string xpathLocator = String.Format(MenuItemBaseLocator, item);
        By itemLocator = By.XPath(xpathLocator);
        WebDriverActions.SwitchToFrame(_prepaymentDecayFrame);
        WebDriverActions.Click(itemLocator);
        WebDriverActions.SwitchToDefaultFrame();
    }
}