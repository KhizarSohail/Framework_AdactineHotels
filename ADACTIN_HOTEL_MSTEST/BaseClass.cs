using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MongoDB.Driver.Core.Operations;
using System.ComponentModel.Composition.Primitives;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.Extensions.Options;
using OpenQA.Selenium.DevTools.V108.HeadlessExperimental;
using OpenQA.Selenium.DevTools.V108.Browser;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace ADACTIN_HOTEL_MSTEST
{
    public class BaseClass
    {
        //gobal variabe
        public static IWebDriver driver;
        public static string path = "B:\\C-sharp Files\\ADACTIN_HOTEL_MSTEST\\ADACTIN_HOTEL_MSTEST\\ScreenShot\\";


        public static void SeleniumInit(string browser, string type)
        {
            BOptions(browser, type);
            ExtentReport.Sys_Info(browser);
        }
        public static void Write(By by, string text, string Detailname1, string filename1, string path, string browser, string childNode = "")
        {
            try
            {
                driver.FindElement(by).SendKeys(text);
                ExtentReport.ChildLog(childNode);
                ExtentReport.LogReport(Detailname1, filename1, path, browser);
            }
            catch (Exception)
            {
                ExtentReport.LogReportFailed(Detailname1, filename1, path, browser);
            }
        }
    
        public static void Action(string operation, By by, string text, string Detailname1, string filename1, string path, string childNode = "")
        {
            operation.ToLower();
            if (operation == "write")
            {
                try
                {
                    driver.FindElement(by).SendKeys(text); 
                    ExtentReport.LogReport(Detailname1, filename1, path);
                }
                catch (Exception)
                {
                    ExtentReport.LogReportFailed(Detailname1, filename1, path);
                }
            }
            else if (operation == "click")
            {
                try
                {
                    driver.FindElement(by).Click();
                    ExtentReport.LogReport(Detailname1, filename1, path);
                }
                catch (Exception)
                {
                    ExtentReport.LogReportFailed(Detailname1, filename1, path);
                    throw;
                }
            }
            else if (operation == "text")
            {
                try
                {
                    string asserttext = driver.FindElement(by).Text;
                    ExtentReport.LogReport(Detailname1, filename1, path);
                }
                catch (Exception)
                {
                    ExtentReport.LogReportFailed(Detailname1, filename1, path);
                    throw;
                }
            }

        }
        
        public static void ScreenShot(string filename, string path, string fileformat)
        {
            fileformat.ToUpper();
            Screenshot image_user = ((ITakesScreenshot)BaseClass.driver).GetScreenshot();
            if (fileformat == "PNG")
            {
                image_user.SaveAsFile(path + filename, ScreenshotImageFormat.Png);
            }
            else if (fileformat == "JPEG")
            {
                image_user.SaveAsFile(path + filename, ScreenshotImageFormat.Jpeg);
            }
            else if (fileformat == "GIF")
            {
                image_user.SaveAsFile(path + filename, ScreenshotImageFormat.Gif);
            }
            else if (fileformat == "BMP")
            {
                image_user.SaveAsFile(path + filename, ScreenshotImageFormat.Bmp);
            }
        }

        public static void BOptions(string browser, string type)
        {
            browser.ToLower();
            type.ToLower();
            if (browser == "chrome")
            {
                ChromeOptions options = new ChromeOptions();
                if (type == "incognito")
                {
                    options.AddArgument("--incognito");
                }
                else if (type == "headless")
                {
                    options.AddArgument("--headless=new");
                }
                driver = new ChromeDriver(options);
            }
            else if (browser == "firefox")
            {
                var options = new FirefoxOptions();
                if (type == "incognito")
                {
                    options.AddArgument("--incognito");
                }
                else if (type == "headless")
                {
                    options.AddArgument("--headless=new");
                }
                driver = new FirefoxDriver(options);
            }

        }
        public static void JS_Executor(string type, int value)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)driver);
            type.ToUpper();
            if (type == "SCROLLDOWN")
            {
                js.ExecuteScript("window.scrollBy(0," + value + ")");
            }
            else if (type == "SCROLLUP")
            {
                js.ExecuteScript("window.scrollBy(0," + (value) + ")");
            }
            else if (type == "ZOOMIN")
            {
                js.ExecuteScript(string.Format("document.body.style.zoom=" + value + ""));
            }
            else if (type == "ZOOMOUT")
            {
                js.ExecuteScript(string.Format("document.body.style.zoom=" + value + ""));
            }

        }
    }
}

//public static void Click(By by, string Detailname1, string filename1, string path)
//{
//    try
//    {

//        driver.FindElement(by).Click();
//        ExtentReport.LogReport(Detailname1, filename1, path);
//    }
//    catch (Exception)
//    {
//        ExtentReport.LogReportFailed(Detailname1, filename1, path);
//        throw;
//    }

//}
//public static void Text(By by, string Detailname1, string filename1, string path, string browser)
//{
//    try
//    {
//        string asserttext = driver.FindElement(by).Text;
//        ExtentReport.LogReport(Detailname1, filename1, path, browser);
//    }
//    catch (Exception)
//    {
//        ExtentReport.LogReportFailed(Detailname1, filename1, path, browser);
//        throw;
//    }