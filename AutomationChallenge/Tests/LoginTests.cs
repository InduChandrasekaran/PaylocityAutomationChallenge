using AutomationChallenge.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationChallenge.Tests
{
    [TestClass]
    public class LoginTests : Login
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Driver.Initialize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Quit();
        }

        [TestMethod]
        [TestCategory("SmokeLoginTest")]
        public void TestApplicationSuccessfulLogin()
        {
            Login.GoToLogin();
            Login.LoginAs();
            Login.VerifySuccessfulLogin();
        }

        [TestMethod]
        [TestCategory("SmokeLoginTest")]
        public void TestApplicationFailedLogin()
        {
            Login.GoToLogin();
            Login.LoginWithIncorrectUserName();
            Login.VerifyLoginError();
            Login.TakeScreenshot();
        }

    }
}
