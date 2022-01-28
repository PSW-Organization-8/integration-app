using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumEndToEndTests
{
    public class CreateObjectionTest
    {
        private IWebDriver driver;
        private readonly string frontEndAddress = Environment.GetEnvironmentVariable("FRONTEND_ADDRESS") ?? @"http://localhost:4200/";
        private readonly string localTest = Environment.GetEnvironmentVariable("LOCAL_TEST") ?? "false";

        [SkippableFact(typeof(SkipException))]
        public void Creating_tender()
        {
            Skip.IfNot(localTest.Equals("true"));

            CreateDriver();

            var oldRowCount = GetTableRowCount();
            CreateObjection();
            var newRowCount = GetTableRowCount();

            newRowCount.ShouldBe(oldRowCount + 1);

            CloseDriver();

        }

        private void CloseDriver()
        {
            driver.Quit();
            driver.Dispose();
        }

        private void CreateObjection()
        {
            driver.Navigate().GoToUrl(frontEndAddress + @"createObjection");

            var pharmacyName = new SelectElement(driver.FindElement(By.Name("something")));
            pharmacyName.SelectByIndex(1);
            var objectionText = driver.FindElement(By.Name("objectionText"));
            objectionText.SendKeys("Nece da mi se jave!");


            var openTenderButton = driver.FindElement(By.ClassName("send"));
            openTenderButton.Click();
            System.Threading.Thread.Sleep(2000);
        }

        private void CreateDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);
        }

        private int GetTableRowCount()
        {
            driver.Navigate().GoToUrl(frontEndAddress + @"allObjections");
            System.Threading.Thread.Sleep(2000);
            return driver.FindElements(By.ClassName("element1")).Count;
        }
    }
}
