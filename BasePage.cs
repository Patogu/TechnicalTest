using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TechnicalTestPatricia.Pages
{
 public class BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "ul:nth-child(2) > li:nth-child(3) > a")]
        public readonly IWebElement Signup;

        [FindsBy(How = How.ClassName, Using = "navbar navbar-light")]
        public readonly IWebElement Menubar;
        
        public static Random rnd = new Random();
        public static IWebDriver Driver = Browser.Driver;

        public BasePage()
        {
            PageFactory.InitElements(Driver, this);

        }

        public void GoToProdHome()
        {
            Driver.Url = Browser.ProdUrl;
        }


        public void GoToTestHome()
        {
            Driver.Url = Browser.TestUrl;
        }

        public void Refresh()
        {
            Driver.Url = Driver.Url;
        }

        public void GoToSignUp()
        {
            
            Signup.Click();
            new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
        }

        public void WaitForElementInvisibility(IWebElement element, int timeout = 10)
        {
            new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(timeout)).Until(Driver => !element.Displayed);
        }

        public void AssertElementPresent(IWebElement element)
        {
            Assert.IsTrue(element.Displayed);
        }

        public void AssertElementNotPresent(IWebElement element)
        {
            try
            {
                AssertElementPresent(element);
            }
            catch (Exception e)
            {
                var str = e.Message;
                Assert.IsTrue(e.Message.Contains("Expected: True") && e.Message.Contains("But was: False"));
            }
        }

    }
}
