using System;
using System.Collections.Generic;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages.Components
{
    public class NavigationBar
    {
        private By _logoImage = By.CssSelector("#logo");
        private By _marketButton = By.CssSelector("#mainNav a[tab-menuname='MARKET']");
        private By _currentPositionButton = By.CssSelector("#mainNav a[tab-menuname='CURRENT POSITION']");
        private By _assumptionsButton = By.CssSelector("#mainNav a[tab-menuname='ASSUMPTIONS']");
        private By _reportingSetupButton = By.CssSelector("#mainNav a[tab-menuname='REPORTING SETUP']");
        private By _processAndReportButton = By.CssSelector("#mainNav a[tab-menuname='PROCESS & REPORT']");
        private By _utilitiesButton = By.CssSelector("#mainNav a[tab-menuname='UTILITIES']");
        private By _usernameButton = By.CssSelector("#aUserName span[title='Username']");

        public String GetUsernameDisplayed()
        {
            return WebDriverActions.GetText(_usernameButton);
        }

        public Boolean IsDisplayed()
        {
            List<By> elements = new List<By>()
            {
                _logoImage, _marketButton, _currentPositionButton, _assumptionsButton,
                _reportingSetupButton, _processAndReportButton, _utilitiesButton, _usernameButton
            };
            return WebDriverActions.AreDisplayed(elements);
        }
    }
}