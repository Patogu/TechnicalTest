using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechnicalTestPatricia.Pages;
using TechTalk.SpecFlow;

namespace TechnicalTestPatricia.Steps
{
    [Binding]
    public class CreateANewAccountSteps
    {
        private readonly ScenarioContext scenarioContext;

        public CreateANewAccountSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null) throw new ArgumentNullException("scenarioContext");
            this.scenarioContext = scenarioContext;
        }

        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            var basePage = scenarioContext.Get<BasePage>("basePage");
            basePage.GoToProdHome();
            basePage.GoToSignUp();
          
        }

        [When(@"I complete the sign up form")]
        public void WhenICompleteTheSignUpForm()
        {
            var user = scenarioContext.Get<Member>("user");
            var signupPage = scenarioContext.Get<SignupPage>("signupPage");      
            signupPage.CompleteSignup(user.Username, user.Email, user.Password);  
           

        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            var signupPage = scenarioContext.Get<SignupPage>("signupPage");
            signupPage.SignupButton.Click();
        }

        [Then(@"my username is displayed")]
        public void ThenMyUsernameIsDisplayed()
        {
         
            scenarioContext.Set(scenarioContext.Get<Member>("user").Username);
            var signupPage = scenarioContext.Get<SignupPage>("signupPage");         
            signupPage.AssertSignedUp(scenarioContext.Get<Member>("user").Username);
        }

    }
}
