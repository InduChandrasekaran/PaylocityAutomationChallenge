using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationChallenge.PageObjects
{
    public class Login
    {
        public static void GoToLogin()
        {
            Driver.Instance.Navigate().GoToUrl("https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login");
        }

        public static void LoginAs()
        {
            Driver.Instance.FindElement(By.Id("Username")).SendKeys("TestUser17");
            Driver.Instance.FindElement(By.Id("Password")).SendKeys("]#j$rdEPmDV=");
            Driver.Instance.FindElement(By.CssSelector(".btn-primary")).Click();
        }

        public static void LoginWithIncorrectUserName()
        {
            Driver.Instance.FindElement(By.Id("Username")).SendKeys("TestUser50");
            Driver.Instance.FindElement(By.Id("Password")).SendKeys("]#j$rdEPmDV=");
            Driver.Instance.FindElement(By.CssSelector(".btn-primary")).Click();
        }

        public static void VerifySuccessfulLogin()
        {
            if (Driver.Instance.FindElement(By.LinkText("Log Out")).Text.Equals("Log Out"))
            {
                Console.WriteLine("It successfully navigated to dashboard page");
            }
            else
            {
                Assert.Fail("It did not navigate to dashboard page");
            }

        }

        public static void VerifyLoginError()
        {
            if (Driver.Instance.FindElement(By.CssSelector(".validation-summary-errors.text-danger")).Text.Contains("There were one or more problems that prevented you from logging in:"))
            {
                Console.WriteLine("It successfully received error message on entering incorrect username");
            }
            else
            {
                Assert.Fail("It did not receive error message when incorrect username is entered");
            }

        }

        public static void TakeScreenshot()
        {
            Screenshot image = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            image.SaveAsFile("c:/screenshot.png", ScreenshotImageFormat.Png);
        }

    }
}
