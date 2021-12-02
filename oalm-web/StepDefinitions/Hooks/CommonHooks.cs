using TechTalk.SpecFlow;

namespace oalm_web.StepDefinitions.Hooks
{
    [Binding]
    public sealed class CommonHooks
    {
        [AfterTestRun]
        public static void AfterWebFeature()
        {
            Webdrivers.WebDriverManager.Instance.QuitDriver();
        }
    }
}