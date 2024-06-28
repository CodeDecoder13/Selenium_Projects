using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Collections.Generic;
using AventStack.ExtentReports.Reporter.Config;

namespace SeleniumTest
{
    public class ExtentReportsHelper
    {
        private static ExtentReports extent;
        private static string screenshotDirectory;
        private static string reportDirectory;
        private static string reportFilePath;
        private static string author;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                SetDirectories();
                var reporter = new ExtentSparkReporter(reportFilePath);
                reporter.Config.Theme = Theme.Dark;  // Set the theme to Dark
                extent.AttachReporter(reporter);
                extent.AddSystemInfo("OS", "Windows 11");
                if (!string.IsNullOrEmpty(author))
                {
                    extent.AddSystemInfo("Author", author);
                }
            }
            return extent;
        }


        public static ExtentTest CreateTest(string testName, string description = "")
        {
            return GetExtent().CreateTest(testName, description);
        }

        public static void Flush()
        {
            if (extent != null)
            {
                extent.Flush();
                Process.Start("explorer.exe", Path.GetFullPath(reportFilePath));
                extent = null;  // Reset extent to ensure a new report is created for each run
            }
        }

        private static void SetDirectories()
        {
            string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Screenshot repo");
            string dateDirectory = DateTime.Now.ToString("yyyy-MM-dd");
            screenshotDirectory = Path.Combine(baseDirectory, dateDirectory);

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            string reportBaseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "HtmlReport");
            if (!Directory.Exists(reportBaseDirectory))
            {
                Directory.CreateDirectory(reportBaseDirectory);
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            reportFilePath = Path.Combine(reportBaseDirectory, $"report_{timestamp}.html");
        }

        public static string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filePath = Path.Combine(screenshotDirectory, $"{screenshotName}_{timestamp}.png");
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);
            return filePath;
        }






    }


}
