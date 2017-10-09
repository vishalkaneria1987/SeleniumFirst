using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.TestCases
{
    enum PropertyType
    {
        Id,
        Xpath,
        Class,
        LinkText,
        CssName,
        Type,
        Value,
        Name,
    }
    class PropertiesCollection
    {
        //Auto-implemented property
        public static IWebDriver driver { get; set; }
        public static WebDriverWait wait { get; set; }
    }
}
