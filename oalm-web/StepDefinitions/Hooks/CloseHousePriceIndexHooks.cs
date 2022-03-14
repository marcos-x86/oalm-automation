using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public class CloseHousePriceIndexHooks
{
    private HousePriceIndexPage _page;

    public CloseHousePriceIndexHooks(HousePriceIndexPage page)
    {
        _page = page;
    }

    [AfterScenario(Order = 90000)]
    [Scope(Tag = "closeHousePriceIndexTab")]
    public void CloseTab()
    {
        _page.CloseActiveTab("House Price Index");
    }
}