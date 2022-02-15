using System;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Sections
{
    public class PVCurveHeader
    {
        private const string MoreOptionBaseLocator = "//li[contains(@class,'jqx-item') and text()='{0}']";
        private By _saveButton = By.CssSelector("input[id='btnSave1']");
        private By _moreButton = By.CssSelector("input[id='btnMore']");
        private By _marketStructureFrame = By.CssSelector("[name='iframeMarketStructure']");

        public void ClickOnMoreButton()
        {
            WebDriverActions.SwitchToFrame(_marketStructureFrame);
            WebDriverActions.Click(_moreButton);
            WebDriverActions.SwitchToDefaultFrame();
        }

        public Boolean IsSaveButtonDisplayed()
        {
            WebDriverActions.SwitchToFrame(_marketStructureFrame);
            Boolean result = WebDriverActions.IsDisplayed(_saveButton);
            WebDriverActions.SwitchToDefaultFrame();
            return result;
        }

        public Boolean IsValuePresentInMoreOptions(string option)
        {
            By locator = By.XPath(String.Format(MoreOptionBaseLocator, option));
            WebDriverActions.SwitchToFrame(_marketStructureFrame);
            Boolean result = WebDriverActions.IsDisplayed(locator);
            WebDriverActions.SwitchToDefaultFrame();
            return result;
        }
    }
}