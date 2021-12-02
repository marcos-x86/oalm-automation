using oalm_web.Pages.Components;
using oalm_web.Utils;
using OpenQA.Selenium;

namespace oalm_web.Pages
{
    public class HomePage
    {
        private By _pageLoader = By.CssSelector("#pageLoader");
        private NavigationBar _navigationBar;
        private FooterBar _footerBar;

        public HomePage()
        {
            _navigationBar = new NavigationBar();
            _footerBar = new FooterBar();
        }

        public NavigationBar GetNavigationBar()
        {
            return _navigationBar;
        }

        public FooterBar GetFooterBar()
        {
            return _footerBar;
        }

        public void WaitUntilLoadIsCompleted()
        {
            WebDriverActions.WaitUntilNotDisplayed(_pageLoader);
        }
    }
}