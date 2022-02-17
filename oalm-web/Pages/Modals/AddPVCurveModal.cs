using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Modals;

public class AddPVCurveModal
{
    private By _idTextInput = By.CssSelector("#dvAddTable #txtNewID2");
    private By _okButton = By.CssSelector("#dvAddTable #btnOK");
    private By _cancelButton = By.CssSelector("#dvAddTable #btnCancel");
    private By _marketStructureFrame = By.CssSelector("[name='iframeMarketStructure']");

    public void SetIdTextInput(string id)
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.SetText(_idTextInput, id);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnOkButton()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(_okButton);
        WebDriverActions.SwitchToDefaultFrame();
    }
    
    public void ClickOnCancelButton()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(_cancelButton);
        WebDriverActions.SwitchToDefaultFrame();
    }
}