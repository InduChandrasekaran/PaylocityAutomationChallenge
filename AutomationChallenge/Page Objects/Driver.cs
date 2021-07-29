using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace AutomationChallenge.PageObjects
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
        }
        public static void Quit()
        {
            Instance.Quit();
        }
    }
}