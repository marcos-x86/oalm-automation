using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using oalm_web.Pages;
using oalm_web.Pages.Constants;
using oalm_web.Utils;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public sealed class MarketStructureSteps
{
    private MarketStructurePage _marketStructurePage;
    private Context _context;

    public MarketStructureSteps(MarketStructurePage marketStructurePage, Context context)
    {
        _marketStructurePage = marketStructurePage;
        _context = context;
    }

    [When("the user sets the '(.*)' value to the '(.*)' row of the '(.*)' column in the PV Curve table")]
    public void ClicksMenuEntry(string value, string row, string column)
    {
        PVCurveColumn pvColumn = (PVCurveColumn) Enum.Parse(typeof(PVCurveColumn), column);
        string originalValue = _marketStructurePage.GetPvCurveTable().GetCellData(pvColumn, row);
        _marketStructurePage.GetPvCurveTable().SetCellData(pvColumn, row, value);
        _context.StorePVCurveData(new PVCurveData(pvColumn, row, originalValue));
    }

    [When("the user clicks on PV Curve Save button")]
    public void ClicksOnSave()
    {
        _marketStructurePage.ClickSaveButton();
    }

    [When("the user clicks on '(.*)' dropdown in the PV Curve Settings section")]
    public void ClickDropdown(string configOption)
    {
        _marketStructurePage.GetPvCurveSettings().ClickOnDropdown(configOption);
    }

    [Then("verifies that the '(.*)' value is displayed in the '(.*)' row of the '(.*)' column in the PV Curve table")]
    public void AssertCellValue(string expectedValue, string row, string column)
    {
        PVCurveColumn pvColumn = (PVCurveColumn) Enum.Parse(typeof(PVCurveColumn), column);
        Assert.True(_marketStructurePage.GetPvCurveTable().IsCellContainingData(pvColumn, row, expectedValue));
    }

    [Then("verifies that the PV Curve Save success toast message is displayed")]
    public void AssertSuccessToast()
    {
        Assert.True(_marketStructurePage.IsSuccessMessageDisplayed());
        _marketStructurePage.WaitUntilSuccessMessageIsNotDisplayed();
    }

    [Then("verifies that the following options are displayed for '(.*)' dropdown in the PV Curve Settings section")]
    public void AssertDropdownOptions(string dropdown, Table table)
    {
        List<string> options = table.Rows.Select(item => item["Options"]).ToList();
        options.ForEach(option => Assert.True(_marketStructurePage.GetPvCurveSettings().IsValuePresentInDropdown(dropdown, option)));
    }

    [Then("verifies that Maturity Point PV Curve Setting should display the following values")]
    public void AssertMaturityPointText(string expectedContent)
    {
        Assert.AreEqual(expectedContent, _marketStructurePage.GetPvCurveSettings().GetMaturityPointData());
    }
}