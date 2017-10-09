using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFirst.Utilities;

namespace SeleniumFirst.TestCases
{
    [TestFixture]
    class SampleLogin
    {
        IWebDriver driver = new FirefoxDriver();

            [SetUp]
            public void Initialize()
            {
                driver.Navigate().GoToUrl("https://assistwebtest.azurewebsites.net/Account/Login");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                IWebElement HomePageLoad = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='pageaccount_login']")));


            }
            [Test]
            public void ExecuteTest()
            {
                LoginPageMethods.EnterText(driver, "UserName", "Admin", "Name");

            }
            [TearDown]
            public void CleanUp()
            {
                driver.Close();
            }
        }
    }

