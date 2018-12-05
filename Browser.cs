using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTestPatricia
{
    public static class Browser
    {
        public static IWebDriver Driver { get; set; }    
        public static string ProdUrl { get { return ConfigurationManager.AppSettings["prod url"]; } }
        public static string TestUrl { get { return ConfigurationManager.AppSettings["test url"]; } }
        public static string Prodsite { get { return ProdUrl.Split('.')[2]; } }
        public static string Testsite { get { return TestUrl.Split('.')[2]; } }

        public static void Refresh()
        {
            Driver.Url = Driver.Url;

        }
    }
}
