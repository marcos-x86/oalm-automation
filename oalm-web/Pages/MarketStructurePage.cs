using System;
using oalm_web.Pages.Modals;
using oalm_web.Pages.Sections;
using oalm_web.Pages.Tables;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class MarketStructurePage : HomeBasePage
{
    private const string MenuItemBaseLocator = "//div[@id='moreButton_Term']//descendant::li[text()='{0}']";
    private PVCurveTable _pvCurveTable;
    private PVCurveSettings _pvCurveSettings;
    private PVCurveHeader _pVCurveHeader;
    private AddPVCurveModal _addPvCurveModal;
    private By _successMessage = By.CssSelector(".layui-layer-msg-success");
    private By _saveButton = By.CssSelector(".buttonGroupRight #btnSave1");
    private By _marketStructureFrame = By.CssSelector("[name='iframeMarketStructure']");

    public MarketStructurePage()
    {
        _pvCurveTable = new PVCurveTable();
        _pvCurveSettings = new PVCurveSettings();
        _pVCurveHeader = new PVCurveHeader();
        _addPvCurveModal = new AddPVCurveModal();
    }

    public By GetFrame()
    {
        return _marketStructureFrame;
    }

    public PVCurveTable GetPvCurveTable()
    {
        return _pvCurveTable;
    }

    public PVCurveSettings GetPvCurveSettings()
    {
        return _pvCurveSettings;
    }

    public PVCurveHeader GetPvCurveHeader() 
    {
        return _pVCurveHeader;
    }

    public AddPVCurveModal GetAddPvCurveModal()
    {
        return _addPvCurveModal;
    }
    
    public void ClickSaveButton()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(_saveButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public Boolean IsSuccessMessageDisplayed()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        Boolean isDisplayed = WebDriverActions.IsDisplayed(_successMessage);
        WebDriverActions.SwitchToDefaultFrame();
        return isDisplayed;
    }

    public void WaitUntilSuccessMessageIsNotDisplayed()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.WaitUntilNotDisplayed(_successMessage);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnMoreOptionsMenuItem(string option)
    {
        string xpathLocator = String.Format(MenuItemBaseLocator, option);
        By itemLocator = By.XPath(xpathLocator);
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(itemLocator);
        WebDriverActions.SwitchToDefaultFrame();
    }
}