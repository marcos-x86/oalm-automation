using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public sealed class PrepaymentDecayHooks
{

    private PrepaymentDecayPage _page;
    
    public PrepaymentDecayHooks(PrepaymentDecayPage page)
    {
        _page = page;
    }
    
    [AfterScenario(Order = 90000)]
    [Scope(Tag = "closePrepaymentTab")]
    public void CloseTab()
    {
        _page.CloseActiveTab("Prepayment/Decay Tables");
    }
}