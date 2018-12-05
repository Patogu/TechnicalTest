using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Net;
using TechnicalTestPatricia.Pages;
using TechTalk.SpecFlow;


namespace TechnicalTestPatricia
{
    [Binding]
    public sealed class BrowserSetup
    {
        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public BrowserSetup(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;

            if (featureContext == null) throw new ArgumentNullException("featureContext");
            this.featureContext = featureContext;
        }

        [Before]
        public void Before()
        {
            TestSetup();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

          
            //pages
            scenarioContext.Set(new BasePage(), "basePage");
            scenarioContext.Set(new SignupPage(), "signupPage");
            //object
            scenarioContext.Set(new Member().Random(), "user");
            if (scenarioContext.ScenarioInfo.Tags.Contains("test"))
            {
                Browser.Driver.Url = Browser.TestUrl;
            }
            else
            {
                Browser.Driver.Url = Browser.ProdUrl;
            }
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            Browser.Driver.Quit();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Browser.Driver.Manage().Cookies.DeleteAllCookies();
        }


        public void TestSetup()
        {
            if (Browser.Driver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--disable-extensions");
                options.AddArgument("--no-sandbox");
                Browser.Driver = new ChromeDriver();
                Browser.Driver.Manage().Window.Maximize();
                Browser.Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
                Browser.Driver.Manage().Cookies.DeleteAllCookies();
               
            }
        }
    }
}
