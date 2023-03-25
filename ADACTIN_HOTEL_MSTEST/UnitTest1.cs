using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition.Primitives;

namespace ADACTIN_HOTEL_MSTEST
{
    [TestClass]
    public class Execution
    {

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void TestInit()
        {
            ExtentReport.ParentLog(TestContext.TestName);
            ExtentReport.Report();
            ExtentReport.Sys_Info("Google Chrome");
            BaseClass.SeleniumInit("chrome", "incognito");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ExtentReport.flush();
            BaseClass.driver.Close();
        }

        LoginPage loginpage = new LoginPage();
        //SearchPage searchpage = new SearchPage();
        //SelectPage selectpage = new SelectPage();
        //BookHotelPage bookHotelPage = new BookHotelPage();

        [TestMethod]
        public void Login()
        {
            loginpage.ValidInput_Login("http://adactinhotelapp.com", "User2here", "user123");
            loginpage.InValidInput_Login("http://adactinhotelapp.com", "User3here", "usesr123");
        }















        //[TestMethod]
        //public void LoginPageTest()
        //{
        //    var htmlReporter = new ExtentHtmlReporter("B:\\C-sharp Files\\ADACTIN_HOTEL_MSTEST\\ADACTIN_HOTEL_MSTEST\\ScreenShot\\");
        //    var extent = new ExtentReports();
        //    extent.AttachReporter(htmlReporter);

        //    extent.AddSystemInfo("Opearating System:", "Window 10");
        //    extent.AddSystemInfo("HostName:", "SeleniumPC");
        //    extent.AddSystemInfo("Browser:", "Google Chrome");

        //    var test = extent.CreateTest("LoginPage");
        //    test.Log(Status.Info, "Step 1: Test case starts.");
        //    test.Log(Status.Pass, "Step 2: Test case for pass.");
        //    test.Log(Status.Fail, "Step 2: Test case for failed.");
        //    test.Pass("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath("B:\\C-sharp Files\\ADACTIN_HOTEL_MSTEST\\ADACTIN_HOTEL_MSTEST\\ScreenShot\\screenshot.png").Build());
        //    test.Pass("ScreenShot").AddScreenCaptureFromPath("B:\\C-sharp Files\\ADACTIN_HOTEL_MSTEST\\ADACTIN_HOTEL_MSTEST\\ScreenShot\\screenshot.png");
        //    extent.Flush();



        //[TestMethod]
        //public void SearchHotel()
        //{

        //    loginpage.Login("http://adactinhotelapp.com/", "user2here", "user123");

        //    searchpage.SearchHotel();

        //}
        //[TestMethod]
        //public void SelectHotel()
        //{

        //    loginpage.Login("http://adactinhotelapp.com/", "user2here", "user123");
        //    searchpage.SearchHotel();
        //    selectpage.SelectHotel();

        //}
        //[TestMethod]
        //public void BookHotelPage()
        //{

        //    loginpage.Login("http://adactinhotelapp.com/", "user2here", "user123");
        //    searchpage.SearchHotel();
        //    selectpage.SelectHotel();
        //    bookHotelPage.BookHotel();
        //    BaseClass.driver.Close();
        //}

        //[TestMethod]
        //public void Demo()
        //{
        //    PracticeForm practiceForm = new PracticeForm();
        //    practiceForm.Practice("https://demoqa.com/automation-practice-form");
        //}

    }
}
