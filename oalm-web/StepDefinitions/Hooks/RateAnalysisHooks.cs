using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public class RateAnalysisHooks
{
    private RateAnalysisPage _page;

    public RateAnalysisHooks(RateAnalysisPage page)
    {
        _page = page;
    }
    
    [AfterScenario(Order = 90000)]
    [Scope(Tag = "closeRateAnalysisTab")]
    public void CloseTab()
    {
        _page.CloseActiveTab("Rate Analysis");
    }
}