using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADACTIN_HOTEL_MSTEST
{
    internal class LoginPage : BaseClass
    {
        By usernameTxt = By.Id("username");
        By passwordTxt = By.Id("password");
        By loginbtn = By.Id("login");
        By assertText = By.CssSelector("body > table.content > tbody > tr:nth-child(1) > td:nth-child(1)");

        public void ValidInput_Login(string url, string user, string pass)
        {
            driver.Url = url;
            ExtentReport.ChildLog("Valid Input Login");
            Action("write", usernameTxt, user, "UserName", "Image1.png", path, "Valid Username");
            Action("write", passwordTxt, pass, "Password", "Image2.png", path, "Valid Password");
            Action("click",loginbtn, "Login","Login_Btn" ,"Image3.png", path);
            Action("text",assertText, "Assertion","Assert_text" ,"Image4.png", path);
            

        }
        public void InValidInput_Login(string url, string user, string pass)
        {
            driver.Url = url;
            
            ExtentReport.ChildLog("InValid Input Login");
            Action("write", usernameTxt, user, "UserName", "Image1.png", path, "Invalid Password");
            //ExtentReport.LogReport("UserName", "Image1.png");
            Action("write", passwordTxt, pass, "Password", "Image2.png", path, "Invalid Password");
            //ExtentReport.LogReport("Password", "Image2.png");
            Action("click", loginbtn, "Login", "Login_Btn", "Image3.png", path);

        }
    }
}
