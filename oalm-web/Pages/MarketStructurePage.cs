﻿using System;
using oalm_web.Pages.Tables;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class MarketStructurePage : HomeBasePage
{
    private PVCurveTable _pvCurveTable;
    private By _successMessage = By.CssSelector(".layui-layer-msg-success");
    private By _saveButton = By.CssSelector(".buttonGroupRight #btnSave1");
    private By _marketStructureFrame = By.CssSelector("[name='iframeMarketStructure']");

    public MarketStructurePage()
    {
        _pvCurveTable = new PVCurveTable();
    }

    public PVCurveTable GetPvCurveTable()
    {
        return _pvCurveTable;
    }

    public void ClickSaveButton()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.Click(_saveButton);
        WebDriverActions.SwitchToDefaultFrame();
    }

    public Boolean IsSuccessMessageDisplayed()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        Boolean isDisplayed = WebDriverActions.IsDisplayed(_successMessage);
        WebDriverActions.SwitchToDefaultFrame();
        return isDisplayed;
    }

    public void WaitUntilSuccessMessageIsNotDisplayed()
    {
        WebDriverActions.SwitchToFrame(_marketStructureFrame);
        WebDriverActions.WaitUntilNotDisplayed(_successMessage);
        WebDriverActions.SwitchToDefaultFrame();
    }
}