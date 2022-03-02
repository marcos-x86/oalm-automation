using System;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages;

public class RateAnalysisPage : HomeBasePage
{
    private const string TabsBaseLocator = "//div[contains(@class,'jqx-tabs-titleContentWrapper') and text()='{0}']";
    private By _rateAnalysisFrame = By.CssSelector("[name='iframeRateAnalysis']");

    public Boolean IsTabPresent(string name)
    {
        string xpathLocator = String.Format(TabsBaseLocator, name);
        By tabLocator = By.XPath(xpathLocator);
        WebDriverActions.SwitchToFrame(_rateAnalysisFrame);
        Boolean result = WebDriverActions.IsDisplayed(tabLocator);
        WebDriverActions.SwitchToDefaultFrame();
        return result;
    }
}