using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace SeleniumTest
{
    public class BaseTest
    {
        public IWebDriver driver;
        public ExtentTest test;

        public string baseUrl = "https://funky-beat-website.vercel.app";

        [SetUp]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            

            

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            test = ExtentReportsHelper.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
            }
            ExtentReportsHelper.Flush();
        }

        public void CaptureScreenshot(string screenshotName)
        {
            string screenshotPath = ExtentReportsHelper.CaptureScreenshot(driver, screenshotName);
            test.AddScreenCaptureFromPath(screenshotPath);
        }
    }
}
