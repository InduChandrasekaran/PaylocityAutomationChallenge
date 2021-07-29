using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationChallenge.PageObjects
{
    public class AddEmployee
    {
        public static void EnterFirstName(string firstName)
        {
            Driver.Instance.FindElement(By.Id("firstName")).SendKeys(firstName);
        }

        public static void EnterLastName(string lastName)
        {
            Driver.Instance.FindElement(By.Id("lastName")).SendKeys(lastName);
        }
        public static void EnterDependants(string dependants)
        {
            Driver.Instance.FindElement(By.Id("dependants")).Clear();
            Driver.Instance.FindElement(By.Id("dependants")).SendKeys(dependants);
        }

        public static void Add()
        {
            Driver.Instance.FindElement(By.Id("addEmployee")).Click();
        }

        public static void Update()
        {
            Driver.Instance.FindElement(By.Id("updateEmployee")).Click();
        }


        public static void VerifyAddedEmployee(string firstName, string lastName)
        {
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Driver.Instance.FindElement(By.Id("employeesTable"));

            IList<IWebElement> rowelements = Driver.Instance.FindElements(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr"));
            Console.WriteLine("Total rows" + rowelements.Count());
            int rowsize = rowelements.Count();

            // Loop through all the rows of the table to find if the employee added shows up in the table.
            for (int i = 1; i <= rowsize; i++)
            {
                if ((Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[2]")).Text.Contains(firstName)) &&
                    (Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[3]")).Text.Contains(lastName)))
                {
                    Console.WriteLine("Found the added employee");
                    // Verifying the first and last name of the added employee
                    var firstNameFromTable = Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[2]")).Text;
                    Assert.AreEqual(firstName, firstNameFromTable);
                    var lastNameFromTable = Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[3]")).Text;
                    Assert.AreEqual(lastName, lastNameFromTable);

                    // Now cleaning up the test data that was added
                    Console.WriteLine("Now deleting the added employee");
                    Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[9]/i[2]")).Click();
                    Driver.Instance.FindElement(By.Id("deleteEmployee")).Click();                    
                    break;
                };
            }

        }

    }
}
