using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Components;

public class FooterBar
{
    private By _copyrightText = By.CssSelector("#footer-wrapper div:first-child");
    private By _sessionTimeText = By.CssSelector("#footer-wrapper #dvSessionTime");
    private By _onlineStatusButton = By.CssSelector("#footer-wrapper #btnOnlineStatus");
    private By _jobStatusButton = By.CssSelector("#footer-wrapper #btnJobStatus");

    public String GetCopyrightText()
    {
        return WebDriverActions.GetText(_copyrightText);
    }

    public Boolean IsDisplayed()
    {
        List<By> elements = new List<By>()
        {
            _copyrightText, _sessionTimeText, _onlineStatusButton, _jobStatusButton
        };
        return WebDriverActions.AreDisplayed(elements);
    }
}