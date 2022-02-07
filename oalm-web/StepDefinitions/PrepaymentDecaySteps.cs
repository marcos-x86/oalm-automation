using oalm_web.Pages;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public class PrepaymentDecaySteps
{
    private PrepaymentDecayPage _prepaymentDecayPage;
    private Context _context;

    public PrepaymentDecaySteps(PrepaymentDecayPage prepaymentDecayPage, Context context)
    {
        _prepaymentDecayPage = prepaymentDecayPage;
        _context = context;
    }

    [When("the user clicks on More options icon button in Prepayment Decay page")]
    public void ClickMoreOptions()
    {
        _prepaymentDecayPage.ClickDotsIconButton();
    }
    
    [When("the user clicks on '(.*)' option in Prepayment Decay page")]
    public void ClickMoreOptionsMenuItem(string option)
    {
        _prepaymentDecayPage.ClickOnMoreMenuItem(option);
    }
    
    [When("the user clicks on OK button in Export Selector menu")]
    public void ClickOkButtonExportSelector()
    {
        _prepaymentDecayPage.GetExportSelectorMenu().ClickOnOkButton();
    }
}