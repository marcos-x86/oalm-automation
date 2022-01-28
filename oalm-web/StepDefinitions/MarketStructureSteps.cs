using System;
using NUnit.Framework;
using oalm_web.Pages;
using oalm_web.Pages.Constants;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public sealed class MarketStructureSteps
{
    private MarketStructurePage _marketStructurePage;

    public MarketStructureSteps(MarketStructurePage marketStructurePage)
    {
        _marketStructurePage = marketStructurePage;
    }

    [When("the user sets the '(.*)' value to the '(.*)' row of the '(.*)' column in the PV Curve table")]
    public void ClicksMenuEntry(string value, string row, string column)
    {
        PVCurveColumn pvColumn = (PVCurveColumn) Enum.Parse(typeof(PVCurveColumn), column);
        _marketStructurePage.GetPvCurveTable().SetCellData(pvColumn, row, value);
    }

    [Then("verifies that the '(.*)' value is displayed in the '(.*)' row of the '(.*)' column in the PV Curve table")]
    public void AssertCellValue(string expectedValue, string row, string column)
    {
        PVCurveColumn pvColumn = (PVCurveColumn) Enum.Parse(typeof(PVCurveColumn), column);
        Assert.True(_marketStructurePage.GetPvCurveTable().IsCellContainingData(pvColumn, row, expectedValue));
    }
}