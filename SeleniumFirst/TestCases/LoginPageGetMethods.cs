using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.TestCases
{
    class LoginPageGetMethods
    {
        public static string GetTextFromTB(IWebElement element)
        {
           return element.GetAttribute("value");
        }
        public static string GetTextFromDDL(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }


        ////To get value from Input Text Boxes
        //public static string GetTextFromTB(string element, PropertyType elementType)
        //{
        //    if (elementType == PropertyType.Id)
        //        return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
        //    if (elementType == PropertyType.Name)
        //        return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
        //    else return string.Empty;
        //}
        ////To get value from Drop Down List
        //public static string GetTextFromDDL(string element, PropertyType elementType)
        //{
        //    if (elementType == PropertyType.Id)
        //        return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
        //    if (elementType == PropertyType.Name)
        //        return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;
        //    else return string.Empty;
        //}


    }
}
