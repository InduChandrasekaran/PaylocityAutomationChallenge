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
    public class AddEmployeeTests
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
        [TestCategory("SmokeAddEmployeeTest")]
        public void TestAddEmployee()
        {
            Login.GoToLogin();
            Login.LoginAs();
            Dashboard.AddEmployee.Click();
            AddEmployee.EnterFirstName("Selenium");
            AddEmployee.EnterLastName("Test");
            AddEmployee.EnterDependants("2");
            AddEmployee.Add();
            AddEmployee.VerifyAddedEmployee("Selenium", "Test");
        }
    }
}
