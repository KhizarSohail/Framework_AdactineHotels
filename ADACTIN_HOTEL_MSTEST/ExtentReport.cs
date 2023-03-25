using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using OpenQA.Selenium.DevTools.V108.Browser;
using System.Xml.Linq;

namespace ADACTIN_HOTEL_MSTEST
{
    public class ExtentReport : BaseClass
    {
        //GLOBAL VARIABLE
        public static ExtentHtmlReporter htmlreporter = new ExtentHtmlReporter(path);
        public static ExtentReports report = new ExtentReports();
        public static ExtentTest parent;
        public static ExtentTest childreport;

        public static void LogReport(string Detailname, string filename, string path, string browser="")
        {
            parent = report.CreateTest("LoginPage");
            childreport = parent.CreateNode("Login");
            Sys_Info(browser);
            BaseClass.ScreenShot(filename, path, "PNG");
            childreport.Log(Status.Pass, (Detailname + " :Pass"), MediaEntityBuilder.CreateScreenCaptureFromPath(path + filename).Build());
        }

        public static void ParentLog(string parentTag)
        {
            parent = report.CreateTest(parentTag);
        }

        public static void ChildLog(string nodeName)
        {
            childreport = parent.CreateNode(nodeName);
        }

        public static void LogReport(string Detailname, string filename, string path)
        {
            BaseClass.ScreenShot(filename, path, "PNG");
            childreport.Log(Status.Pass, (Detailname + " :Pass"), MediaEntityBuilder.CreateScreenCaptureFromPath(path + filename).Build());
        }

        public static void LogReportFailed(string Detailname, string filename, string path, string browser = "")
        {
            BaseClass.ScreenShot(filename, path, "PNG");
            childreport.Log(Status.Fail, (Detailname + " :Failed"), MediaEntityBuilder.CreateScreenCaptureFromPath(path + filename).Build());
        }
        public static void LogReportFailed(string Detailname, string filename, string path)
        {
            //Sys_Info(browser);

            BaseClass.ScreenShot(filename, path, "PNG");
            childreport.Log(Status.Fail, (Detailname + " :Failed"), MediaEntityBuilder.CreateScreenCaptureFromPath(path + filename).Build());
        }
        public static void Sys_Info(string browser)
        {
            report.AddSystemInfo("Opearating System:", "Window 10");
            report.AddSystemInfo("HostName:", "SeleniumPC");
            report.AddSystemInfo("Browser:", browser);
        }
        public static void Report()
        {
            report.AttachReporter(htmlreporter);
        }
        public static void flush()
        {
            report.Flush();
        }
    }
}
