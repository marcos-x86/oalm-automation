using oalm_web.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oalm_web.Pages.Sections
{
    public class PVCurveHeader
    {
        private By _saveButton = By.CssSelector("input[id='btnSave1']");
        private By _moreButton = By.CssSelector("input[id='btnMore']");
        public void ClickOnMoreButton()
        {
            WebDriverActions.Click(_moreButton);
        }

        public Boolean SaveButtonIsDisplayed()
        {
            return WebDriverActions.IsDisplayed(_saveButton);
        }
    }
}
