using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Modals;

public class ConfirmDialog
{
    private By _confirmButton = By.CssSelector(".layui-layer-dialog .btn-primary");
    private By _cancelButton = By.CssSelector(".layui-layer-dialog .btn-secondary");

    public void ClickOnConfirmButton(By frameSelector)
    {
        WebDriverActions.SwitchToFrame(frameSelector);
        WebDriverActions.Click(_confirmButton);
        WebDriverActions.SwitchToDefaultFrame();
    }
    
    public void ClickOnCancelButton(By frameSelector)
    {
        WebDriverActions.SwitchToFrame(frameSelector);
        WebDriverActions.Click(_cancelButton);
        WebDriverActions.SwitchToDefaultFrame();
    }
}