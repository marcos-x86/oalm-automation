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

    [When("the user clicks on More options button in PV Curve page")]
    public void ClickMoreOptions()
    {
        _marketStructurePage.GetPvCurveHeader().ClickOnMoreButton();
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
        options.ForEach(option =>
            Assert.True(_marketStructurePage.GetPvCurveSettings().IsValuePresentInDropdown(dropdown, option)));
    }

    [Then("verifies that Maturity Point PV Curve Setting is displayed")]
    public void AssertMaturityPoint()
    {
        Assert.True(_marketStructurePage.GetPvCurveSettings().IsMaturityPointDisplayed());
    }

    [Then("verifies that SAVE button is displayed in PV Curve header section")]
    public void AssertSaveButton()
    {
        Assert.IsTrue(_marketStructurePage.GetPvCurveHeader().IsSaveButtonDisplayed());
    }

    [Then("verifies that the following items are displayed for More options menu")]
    public void AssertMoreOptions(Table table)
    {
        List<string> options = table.Rows.Select(item => item["Options"]).ToList();
        options.ForEach(option =>
            Assert.True(_marketStructurePage.GetPvCurveHeader().IsValuePresentInMoreOptions(option)));
    }

    [Then(@"verifies that ID PV Curve Setting has the '(.*)' value")]
    public void AssertIdSettingValue(string expectedValue)
    {
        Assert.AreEqual(expectedValue, _marketStructurePage.GetPvCurveSettings().GetIdSettingText());
    }
}