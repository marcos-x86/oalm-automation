using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public class RateAnalysisSteps
{
    private RateAnalysisPage _rateAnalysisPage;

    public RateAnalysisSteps(RateAnalysisPage rateAnalysisPage)
    {
        _rateAnalysisPage = rateAnalysisPage;
    }

    [Then("verifies that the '(.*)' tab is present in Rate Analysis page")]
    public void AssertTabName(string tabName)
    {
        Assert.True(_rateAnalysisPage.IsTabPresentInPage(tabName));
    }
}