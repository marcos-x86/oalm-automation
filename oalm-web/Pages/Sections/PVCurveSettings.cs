using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace oalm_web.Pages.Sections;

public class PVCurveSettings
{
    private const string _dropdownBaseLocator =
        "//span[@class='setting-label' and text()='{0}:']//following-sibling::div//descendant::div[@id='{1}']";
    private const string _dropdownOptionsBaseLocator = "//div[@id='{0}']//descendant::span[text()='{1}']";
    private const string _protectionDropdownId = "listBoxContentinnerListBoxddlProtection";
    private const string _allowNegativeDropdownId = "listBoxContentinnerListBoxddlAllowNegative";
    private const string _protectionDropdownArrowId = "dropdownlistArrowddlProtection";
    private const string _allowNegativeDropdownArrowId = "dropdownlistArrowddlAllowNegative";
    private By _maturityPointText = By.CssSelector("#txtMaturityPoint");
    private By _marketStructureFrame = By.CssSelector("[name='iframeMarketStructure']");

    public void ClickOnDropdown(string option)
    {
        string arrowLocator = GetDropdownArrowId(option);
        string locator = String.Format(_dropdownBaseLocator, option, arrowLocator);
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(By.XPath(locator));
        WebDriverActions.SwitchToDefaultFrame();
    }

    public Boolean IsMaturityPointDisplayed()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        Boolean result = WebDriverActions.IsDisplayed(_maturityPointText);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    public Boolean IsValuePresentInDropdown(string dropdown, string value)
    {
        string locatorId = GetDropdownId(dropdown);
        string locator = String.Format(_dropdownOptionsBaseLocator, locatorId, value);
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        Boolean result = WebDriverActions.IsDisplayed(By.XPath(locator));
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    private string GetDropdownArrowId(string dropdown)
    {
        Dictionary<string, string> dropdownIds = new Dictionary<string, string>
        {
            {"Protection", _protectionDropdownArrowId},
            {"Allow Negative", _allowNegativeDropdownArrowId}
        };
        return dropdownIds[dropdown];
    }

    private string GetDropdownId(string dropdown)
    {
        Dictionary<string, string> dropdownIds = new Dictionary<string, string>
        {
            {"Protection", _protectionDropdownId},
            {"Allow Negative", _allowNegativeDropdownId}
        };
        return dropdownIds[dropdown];
    }
}