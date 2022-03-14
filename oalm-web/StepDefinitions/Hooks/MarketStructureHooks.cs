using System;
using oalm_web.Pages;
using oalm_web.Pages.Modals;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks;

[Binding]
public class MarketStructureHooks
{
    private Context _context;
    private MarketStructurePage _page;
    private readonly ScenarioContext _scenarioContext;

    public MarketStructureHooks(Context context, MarketStructurePage page, ScenarioContext scenarioContext)
    {
        _context = context;
        _page = page;
        _scenarioContext = scenarioContext;
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

    [AfterScenario(Order = 2000)]
    [Scope(Tag = "deletePVCurveCreated")]
    public void DeletePVTable()
    {
        string id = _context.GetPVCurveId();
        if (!String.IsNullOrEmpty(id) && _scenarioContext.TestError == null)
        {
            string currentPvCurve = _page.GetPvCurveHeader().GetPvCurveValue();
            if (currentPvCurve.Equals(id))
            {
                _page.GetPvCurveHeader().ClickOnMoreButton();
                _page.ClickOnMoreOptionsMenuItem("Delete Curve");
                ConfirmDialog dialog = new ConfirmDialog();
                dialog.ClickOnConfirmButton(_page.GetFrame());
                _page.WaitUntilSuccessMessageIsNotDisplayed();
            }
        }
    }
    
    [AfterScenario(Order = 90000)]
    [Scope(Tag = "closeMarketStructureTab")]
    public void CloseTab()
    {
        _page.CloseActiveTab("Market Structure");
    }
}