using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.TestCases
{
  /* [TestFixture]
    class Login2
    {
        
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new FirefoxDriver();
            PropertiesCollection.wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(30));
            PropertiesCollection.driver.Navigate().GoToUrl("https://assistwebtest.azurewebsites.net/Account/Login");           
            IWebElement HomePageLoad = PropertiesCollection.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='pageaccount_login']")));
            PropertiesCollection.driver.Manage().Window.Maximize();
            
        }
        [Test]
        public void ExecuteTest()
        {
            //Initialize the code by calling its reference

            LoginPageObjects objLogin = new LoginPageObjects();
            objLogin.UserName.SendKeys("Admin");
            objLogin.Password.SendKeys("Admin-1");
            objLogin.SignInBtn.Click();

            //LoginPageSetMethods.EnterText("UserName", "Admin", PropertyType.Id);
            //LoginPageSetMethods.EnterText("Password", ;"Admin-1", PropertyType.Name);
            //Console.WriteLine("The value from the UserName is:" +LoginPageGetMethods.GetTextFromTB("UserName", PropertyType.Name));
            //Console.WriteLine("The value from the UserName is:" + LoginPageGetMethods.GetTextFromTB("Password", PropertyType.Name));


        }
        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
        }
    } */
}
