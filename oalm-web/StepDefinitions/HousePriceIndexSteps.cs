using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions;

[Binding]
public class HousePriceIndexSteps
{
    private HousePriceIndexPage _housePriceIndexPage;

    public HousePriceIndexSteps(HousePriceIndexPage housePriceIndexPage)
    {
        _housePriceIndexPage = housePriceIndexPage;
    }

    [When("the user clicks on More Options icon button in House Price Index page")]
    public void ClickMoreOptions()
    {
        _housePriceIndexPage.ClickOnMoreOptionsButton();
    }

    [Then("verifies that the SAVE button is displayed in House Price Index page")]
    public void AssertSaveButton()
    {
        Assert.True(_housePriceIndexPage.IsSaveButtonDisplayed());
    }

    [Then("verifies that the following items are displayed for More Options menu in House Price Index page")]
    public void AssertMoreOptions(Table table)
    {
        List<string> options = table.Rows.Select(item => item["Options"]).ToList();
        options.ForEach(option =>
            Assert.True(_housePriceIndexPage.IsMoreOptionsItemDisplayed(option)));
    }
}