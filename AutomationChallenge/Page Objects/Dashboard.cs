using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationChallenge.PageObjects
{
    public class Dashboard
    {
        public static class AddEmployee
        {
            public static void Click()
            {
                Driver.Instance.FindElement(By.Id("add")).Click();
            }
        }

        public static void EditEmployee(string firstName, string lastName)
        {
            Driver.Instance.FindElement(By.Id("employeesTable"));            
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            IList<IWebElement> rowelements = Driver.Instance.FindElements(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr"));
            Console.WriteLine("Total rows" + rowelements.Count());
            int rowsize = rowelements.Count();

            for (int i = 1; i <= rowsize; i++)
            {
                if ((Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[2]")).Text.Contains(firstName)) &&
                    (Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[3]")).Text.Contains(lastName)))
                {
                    Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[9]/i[1]")).Click();
                };
            }

        }
        public static void VerifyEditedEmployee(string firstName, string lastName, int dependants)
        {
            Driver.Instance.FindElement(By.Id("employeesTable"));            

            IList<IWebElement> rowelements = Driver.Instance.FindElements(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr"));
            int rowsize = rowelements.Count();

            for (int i = 1; i <= rowsize; i++)
            {
                if ((Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[2]")).Text.Contains(firstName)) &&
                    (Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[3]")).Text.Contains(lastName)))
                {
                    string dependantsValue = Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[4]")).Text;
                    Assert.IsTrue(dependantsValue.Equals(dependants.ToString()));
                };
            }
        }


        public static void VerifyBenefitsForEmployee(string firstName, string lastName, int dependants)
        {
            Driver.Instance.FindElement(By.Id("employeesTable"));            

            IList<IWebElement> rowelements = Driver.Instance.FindElements(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr"));
            Console.WriteLine("Total rows" + rowelements.Count());
            int rowsize = rowelements.Count();

            for (int i = 1; i <= rowsize; i++)
            {
                if ((Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[2]")).Text.Contains(firstName)) &&
                    (Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[3]")).Text.Contains(lastName)))
                {
                    var benefitsCost = Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[7]")).Text;
                    double employeeBenefitsPerMonth = Math.Round((1000.00 / 26), 2);
                    double dependantBenefitsPerMonth = Math.Round((500.00 / 26), 2);
                    double computedBenefitsCost = employeeBenefitsPerMonth + (dependants * dependantBenefitsPerMonth);
                    Assert.IsTrue(benefitsCost.Equals(computedBenefitsCost.ToString()));

                    var netPay = Driver.Instance.FindElement(By.XPath("//*[@id=\"employeesTable\"]/tbody/tr[" + i + "]/td[8]")).Text;
                    double computedNetPay = Math.Round((2000.00 - computedBenefitsCost), 2);
                    Assert.IsTrue(netPay.Equals(computedNetPay.ToString()));
                };
            }
        }
    }
}
