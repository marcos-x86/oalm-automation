using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Menus;

public class ExportSelectorMenu
{
    private By _okButton = By.CssSelector("#popoverExportSelector .buttonGroupRight input[value='OK']");
    private By _cancelButton = By.CssSelector("#popoverExportSelector .buttonGroupRight input[value='Cancel']");
    private By _prepaymentDecayFrame = By.CssSelector("[name='iframePrepaymentDecayTables']");

    public void ClickOnOkButton()
    {
        WebDriverActions.WaitFixedTime(1000);
        WebDriverActions.SwitchToFrame(_prepaymentDecayFrame);
        WebDriverActions.Click(_okButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnCancelButton()
    {
        WebDriverActions.SwitchToFrame(_prepaymentDecayFrame);
        WebDriverActions.Click(_cancelButton);
        WebDriverActions.SwitchToDefaultFrame();
    }
}