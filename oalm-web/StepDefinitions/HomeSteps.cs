using System;
using NUnit.Framework;
using oalm_web.Pages;
using TechTalk.SpecFlow;
using Environment = oalm_web.Config.Environment;

namespace oalm_web.StepDefinitions
{
    [Binding]
    public sealed class HomeSteps
    {
        private HomePage _homePage;

        public HomeSteps(HomePage homePage)
        {
            _homePage = homePage;
        }

        [Then("verifies that the Home page is displayed")]
        public void VerifyHomePageDisplayed()
        {
            _homePage.WaitUntilLoadIsCompleted();
            Assert.IsTrue(_homePage.GetFooterBar().IsDisplayed());
        }

        [Then("verifies that the username is displayed in the Main Navigation bar")]
        public void VerifyUsernameDisplayed()
        {
            String expectedUsername = Environment.Config.Username;
            Assert.AreEqual(expectedUsername, _homePage.GetNavigationBar().GetUsernameDisplayed());
        }
    }
}