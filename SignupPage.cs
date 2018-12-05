using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace TechnicalTestPatricia.Pages
{
    public class SignupPage:BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "fieldset:nth-child(1) > input")]
        public readonly IWebElement Username;

        [FindsBy(How = How.CssSelector, Using = "fieldset > fieldset:nth-child(2) > input")]
        public readonly IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = "fieldset > fieldset:nth-child(3) > input")]
        public readonly IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "nav > div > ul:nth-child(3) > li:nth-child(4) > a")]
        public readonly IWebElement SignedIn;        

       [FindsBy(How = How.CssSelector, Using = "fieldset > button")]
        public readonly IWebElement SignupButton;

        public void CompleteSignup(string username, string email, string password)
        {
            
            Username.SendKeys(username);          
            Email.SendKeys(email);         
            Password.SendKeys(password);
          
        }
        public void AssertSignedUp(string username)
        {

            new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(5));
            Assert.IsTrue(SignedIn.Text.Contains(username));
        }

        
    }
}
