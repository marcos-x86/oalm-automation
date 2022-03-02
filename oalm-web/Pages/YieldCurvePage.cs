using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class YieldCurvePage : HomeBasePage
{
    private const string DropdownBaseLocator =
        "//span[@class='form-lable' and text()='{0}:']//following-sibling::div//descendant::div[@id='{1}']";

    private const string DropdownItemBaseLocator = "//div[@id='{0}']//descendant::span[text()='{1}']";
    private const string DropdownTaskId = "dropdownlistWrapperddltask";
    private const string InnerListTaskId = "innerListBoxddltask";
    private const string DropdownViewId = "dropdownlistContentddlview";
    private const string InnerListViewId = "innerListBoxddlview";
    private const string DropdownMarketDataId = "dropdownlistWrapperddlmkt1";
    private const string DropdownCurveId = "dropdownlistWrapperddlcurve1";
    private By refreshButton = By.CssSelector("#btnrefresh");
    private By exportToExcelButton = By.CssSelector("#btnExportYieldCurveAnalysis");
    private By _rateAnalysisFrame = By.CssSelector("[name='iframeRateAnalysis']");

    public void ClickOnDropdown(string option)
    {
        string dropdownId = GetDropdownId(option);
        string locator = String.Format(DropdownBaseLocator, option, dropdownId);
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        WebDriverActions.Click(By.XPath(locator));
        WebDriverActions.SwitchToDefaultFrame();
    }

    public Boolean IsRefreshButtonDisplayed()
    {
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        Boolean result = WebDriverActions.IsDisplayed(refreshButton);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    public Boolean IsExportToExcelButtonDisplayed()
    {
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        Boolean result = WebDriverActions.IsDisplayed(exportToExcelButton);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    public Boolean IsDropdownPresent(string option)
    {
        string dropdownId = GetDropdownId(option);
        string locator = String.Format(DropdownBaseLocator, option, dropdownId);
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        Boolean result = WebDriverActions.IsDisplayed(By.XPath(locator));
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }
    
    public Boolean IsValuePresentInDropdown(string option, string value)
    {
        string dropdownId = GetDropdownInnerListId(option);
        string locator = String.Format(DropdownItemBaseLocator, dropdownId, value);
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        Boolean result = WebDriverActions.IsDisplayed(By.XPath(locator));
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    private string GetDropdownId(string dropdown)
    {
        Dictionary<string, string> dropdownIds = new Dictionary<string, string>
        {
            {"Task", DropdownTaskId},
            {"View", DropdownViewId},
            {"Market Data", DropdownMarketDataId},
            {"CurveID", DropdownCurveId}
        };
        return dropdownIds[dropdown];
    }

    private string GetDropdownInnerListId(string dropdown)
    {
        Dictionary<string, string> dropdownIds = new Dictionary<string, string>
        {
            {"Task", InnerListTaskId},
            {"View", InnerListViewId}
        };
        return dropdownIds[dropdown];
    }
}