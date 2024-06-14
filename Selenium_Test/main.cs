using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Internal;

namespace Selenium_Test;
[TestFixture]
public class FormsFillUp
{
    private IWebDriver driver;
    public void MainForm ()
    {
        
        driver = new ChromeDriver();
        //driver = new FirefoxDriver();
        //driver = new EdgeDriver();
         
    }


    [Test]
    public void HomepageContents()
    {
        
        IWebDriver driver = new ChromeDriver();
         driver.Navigate().GoToUrl("https://www.ilovetaters.com/staging/admin");
        IWebElement email = driver.FindElement(By.Id(":r0:"));
        
        email.SendKeys("Admin");
        
        IWebElement password = driver.FindElement(By.Id(":r1:"));

        password.SendKeys("Admin");

        IWebElement submit = driver.FindElement(By.ClassName("w-full"));
        submit.Click();

        try
        {
            IWebElement login = driver.FindElement(By.ClassName("w-full"));
            Console.WriteLine("login failed");
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine("login success");
        }
        
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60)); 
        driver.Quit();
    
    }


}

//dotnet test .bin\Debug\net8.0\Forms.dll --filter TestCategory="Selenium"

