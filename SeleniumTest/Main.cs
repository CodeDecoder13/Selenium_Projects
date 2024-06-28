using System;
using OpenQA.Selenium;
using NUnit.Framework;
using AventStack.ExtentReports;

namespace SeleniumTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Main : BaseTest
    {
        [Test]
        public void TestCase1()
        {
            //test.AssignCategory("tag-1");

            driver.Navigate().GoToUrl(baseUrl);
            CaptureScreenshot("HomePage");
            test.Log(Status.Pass, "Site load success: " + baseUrl);

            driver.FindElement(By.LinkText("Book Now")).Click();
            test.Log(Status.Info, "Clicking the Book Now");
            CaptureScreenshot("Contect Page");

            driver.FindElement(By.Id("name")).SendKeys("Rhuzzel l. Paramio");
            test.Log(Status.Info, "Send Keys for Full name: Rhuzzel L. Paramio");
            CaptureScreenshot("FullName");

            driver.FindElement(By.Id("subject")).SendKeys("Testing Automation");
            test.Log(Status.Info, "Send Keys for Subject: Testing Automation");
            CaptureScreenshot("Subject");

            driver.FindElement(By.Id("email")).SendKeys("rhuzzel.paramio@reedelsevier.com");
            test.Log(Status.Info, "Send Keys for Email: rhuzzel.paramio@reedelsevier.com");
            CaptureScreenshot("email");

            driver.FindElement(By.Id("phone")).SendKeys("09277417341");
            test.Log(Status.Info, "Send Keys for Contect Num: 09277417341");
            CaptureScreenshot("phone");

            driver.FindElement(By.Id("message")).SendKeys("hello how are you hehehehe");
            test.Log(Status.Info, "Send Keys for Message:   Contents ");
            CaptureScreenshot("message");

            driver.FindElement(By.ClassName("button-27")).Click();
            test.Log(Status.Pass, "Click the Submit Button");
            CaptureScreenshot("Submit");

            Console.WriteLine("Submit successful!!!!!");
        }
    }
}
