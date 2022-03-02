using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public class YieldCurveSteps
{
    private YieldCurvePage _yieldCurvePage;

    public YieldCurveSteps(YieldCurvePage yieldCurvePage)
    {
        _yieldCurvePage = yieldCurvePage;
    }

    [When("the user clicks on '(.*)' dropdown in the Yield Curve Settings section")]
    public void ClicksOnDropdown(string tabName)
    {
        _yieldCurvePage.ClickOnDropdown(tabName);
    }

    [Then("verifies that the following options are displayed for '(.*)' dropdown in the Yield Curve Settings section")]
    public void AssertDropdownOptions(string dropdown, Table table)
    {
        List<string> options = table.Rows.Select(item => item["Options"]).ToList();
        options.ForEach(option =>
            Assert.True(_yieldCurvePage.IsValuePresentInDropdown(dropdown, option)));
    }

    [Then("verifies that the '(.*)' dropdown is present in the Yield Curve Settings section")]
    public void AssertDropdown(string dropdown)
    {
        Assert.True(_yieldCurvePage.IsDropdownPresent(dropdown));
    }

    [Then("the user verifies that the REFRESH button is present in the Yield Curve Settings section")]
    public void AssertRefreshButton()
    {
        Assert.True(_yieldCurvePage.IsRefreshButtonDisplayed());
    }

    [Then("the user verifies that the EXPORT TO EXCEL button is present in the Yield Curve Settings section")]
    public void AssertExportToExcelButton()
    {
        Assert.True(_yieldCurvePage.IsExportToExcelButtonDisplayed());
    }
}