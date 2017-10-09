using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using SeleniumFirst.Utilities;
using System.Threading;
using System.Text;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;

namespace SeleniumFirst.TestCases
{
    [TestFixture]
    class SignInPage
    {
        private StringBuilder verificationErrors;
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.wait = new WebDriverWait(PropertiesCollection.driver, TimeSpan.FromSeconds(30));
            PropertiesCollection.driver.Navigate().GoToUrl("https://assistwebtest.azurewebsites.net/Account/Login");
            IWebElement HomePageLoad = PropertiesCollection.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='pageaccount_login']")));
            PropertiesCollection.driver.Manage().Window.Maximize();
            verificationErrors = new StringBuilder();
        }
        [Test]
       // public static void main(String[] arg)
        //{??

 //       }
             
             public void  ExecuteTest()
            {


                ExcelUtilities objExcelUtils = new ExcelUtilities("D:\\Data.xlsx", "LoginData");
                Dictionary<string, Dictionary<string, string>> ObjDictSheetData = objExcelUtils.ReadExcelSheetData();
                for (int rowIndex = 1; rowIndex <= ObjDictSheetData.Count; rowIndex++)
                {
                    try
                    {
                        IDictionary<string, string> ObjDictRowData = ObjDictSheetData["Row" + rowIndex.ToString()];

                        PropertiesCollection.driver.FindElement(By.Name("UserName")).Clear();
                        PropertiesCollection.driver.FindElement(By.Name("UserName")).SendKeys(ObjDictRowData["UserName"]);
                        PropertiesCollection.driver.FindElement(By.Name("Password")).Clear();

                        PropertiesCollection.driver.FindElement(By.Name("Password")).SendKeys(ObjDictRowData["Password"]);
                        PropertiesCollection.driver.FindElement(By.ClassName("btn")).Click();
                        Thread.Sleep(2000);
                        //IWebElement ValidationMsg1 = PropertiesCollection.driver.FindElement(By.XPath("//li[contains(text(),'The user name or password provided is incorrect.')]"));
                        //IWebElement ValidationMsg2 = PropertiesCollection.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='field-validation-error']")));
                        //Assert.IsTrue(ValidationMsg1.Displayed);
                        //continue;

                        bool found = false;
                        try
                        {
                            IWebElement ValidationMsg1 = PropertiesCollection.driver.FindElement(By.XPath("//li[contains(text(),'The user name or password provided is incorrect.')]"));
                            found = ValidationMsg1.Displayed;
                        }

                        catch (NoSuchElementException ex)
                        {
                            Debug.WriteLine(ex.ToString());
                        }

                        if (found == true)
                        {
                            continue;
                        }
                        else
                        {
                            //IWebElement instanceSel = PropertiesCollection.driver.FindElement(By.XPath("//div[@class='form-group']//span[@class='select2-arrow']"));
                            IWebElement instanceSel = PropertiesCollection.driver.FindElement(By.XPath("//*[@id='s2id_SelectedInstance']/a/span[2]/b"));
                            instanceSel.Click();
                            PropertiesCollection.driver.FindElement(By.XPath("(//div[@class='select2-result-label'])[2]")).Click();
                            IWebElement button = PropertiesCollection.driver.FindElement(By.XPath("//input[@value='Choose Instance' and @type='submit']"));
                            button.Click();
                            Thread.Sleep(2000);
                        }

                    }

                    catch (NoSuchElementException ex)
                    {
                        Debug.WriteLine(ex.ToString());
                        break;
                    }
                }
            }    
        
        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
            //Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}



