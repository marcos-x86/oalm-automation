using oalm_web.Pages;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public class MarketStructureHooks
{
    private Context _context;
    private MarketStructurePage _page;

    public MarketStructureHooks(Context context, MarketStructurePage page)
    {
        _context = context;
        _page = page;
    }

    [AfterScenario(Order = 1000)]
    [Scope(Tag = "restorePVTableData")]
    public void RestorePVTableData()
    {
        foreach (PVCurveData data in _context.GetPVCurveData())
        {
            _page.GetPvCurveTable().SetCellData(data._column, data._row, data._value);
            _page.ClickSaveButton();
            _page.WaitUntilSuccessMessageIsNotDisplayed();
        }
    }
}