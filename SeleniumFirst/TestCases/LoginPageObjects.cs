using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.TestCases
{
    class LoginPageObjects
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public string UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "validation-summary-errors")]
        public string ValidationMsg { get; set; }

        //[FindsBy(How = How.XPath, Using = "SelectedInstance")]
        //public IWebElement SelectInstance { get; set; }


    }
}
