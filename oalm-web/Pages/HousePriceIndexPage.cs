using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class HousePriceIndexPage : HomeBasePage
{
    private const string MoreOptionsItemBaseLocator =
        "//div[@id='moreButtons_Menu']//descendant::li[contains(text(),'{0}')]";
    private By _saveButton = By.CssSelector("#btnFinalSave");
    private By _moreOptionsButton = By.CssSelector("#btnMore");
    private By _housePriceIndexFrame = By.CssSelector("[name='iframeHousePriceIndex']");

    public Boolean IsSaveButtonDisplayed()
    {
        WebDriverActions.SwitchToFrame(_housePriceIndexFrame);
        Boolean result = WebDriverActions.IsDisplayed(_saveButton);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    public void ClickOnSaveButton()
    {
        WebDriverActions.SwitchToFrame(_housePriceIndexFrame);
        WebDriverActions.Click(_saveButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnMoreOptionsButton()
    {
        WebDriverActions.SwitchToFrame(_housePriceIndexFrame);
        WebDriverActions.Click(_moreOptionsButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public void ClickOnMoreOptionsItem(string option)
    {
        By optionLocator = GetMoreOptionsItemLocator(option);
        WebDriverActions.SwitchToFrame(_housePriceIndexFrame);
        WebDriverActions.Click(optionLocator);
        WebDriverActions.SwitchToDefaultFrame();
    }
    
    public Boolean IsMoreOptionsItemDisplayed(string option)
    {
        By optionLocator = GetMoreOptionsItemLocator(option);
        WebDriverActions.SwitchToFrame(_housePriceIndexFrame);
        Boolean result = WebDriverActions.IsDisplayed(optionLocator);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }

    private By GetMoreOptionsItemLocator(string option)
    {
        Dictionary<string, By> locators = new Dictionary<string, By>
        {
            {"Upload HPI Table", By.XPath(String.Format(MoreOptionsItemBaseLocator, "Upload HPI Table"))},
            {"Export to Excel", By.XPath(String.Format(MoreOptionsItemBaseLocator, "Export to Excel"))},
            {"Add Row", By.XPath(String.Format(MoreOptionsItemBaseLocator, "Add Row"))},
            {"Delete Row", By.XPath(String.Format(MoreOptionsItemBaseLocator, "Delete Row"))}
        };
        return locators[option];
    }
}