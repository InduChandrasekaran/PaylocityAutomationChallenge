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
    public class EditEmployeeTests
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
        [TestCategory("SmokeEditEmployeeTest")]
        public void TestEditEmployee()
        {
            Login.GoToLogin();
            Login.LoginAs();
            Dashboard.EditEmployee("Edit", "Dependants");
            AddEmployee.EnterDependants("2");
            AddEmployee.Update();
            Dashboard.VerifyEditedEmployee("Edit", "Dependants", 2);
        }

        [TestMethod]
        [TestCategory("SmokeEditEmployeeTest")]
        public void VerifyBenefitsForEmployee()
        {
            Login.GoToLogin();
            Login.LoginAs();
            Dashboard.VerifyBenefitsForEmployee("Calculate", "Benefits", 2);
        }
    }
}
