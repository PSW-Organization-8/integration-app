using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using Shouldly;
using Xunit;

namespace SeleniumEndToEndTests
{
    public class CreatingTenderTest
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
            CreateTender();
            var newRowCount = GetTableRowCount();

            newRowCount.ShouldBe(oldRowCount + 1);

            CloseDriver();

            DeleteCreatedEndToEndTender();
        }

        private static void DeleteCreatedEndToEndTender()
        {
            RestClient restClient = new RestClient(Environment.GetEnvironmentVariable("INTEGRATION_API_URL") ??
                                                   "http://localhost:7313" + "/api/Tendering/deleteEndToEndTestTenders");
            RestRequest request = new RestRequest();
            restClient.Delete(request);
        }

        private void CloseDriver()
        {
            driver.Quit();
            driver.Dispose();
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
            driver.Navigate().GoToUrl(frontEndAddress + @"tenders");
            System.Threading.Thread.Sleep(2000);
            return driver.FindElements(By.ClassName("tender_rows")).Count;
        }

        private void CreateTender()
        {
            driver.Navigate().GoToUrl(frontEndAddress + @"createTender");

            var nameElement = driver.FindElement(By.Name("name"));
            nameElement.SendKeys("TenderEndToEndTest");
            var complationDateElement = driver.FindElement(By.Name("complationDate"));
            complationDateElement.SendKeys("12-12-2022");

            var addMoreButton = driver.FindElement(By.TagName("a"));
            addMoreButton.Click();

            var medicationNameElement = driver.FindElement(By.Name("medicationName"));
            medicationNameElement.SendKeys("medicationTest");
            var quantityElement = driver.FindElement(By.Name("quantity"));
            quantityElement.SendKeys("1");

            var openTenderButton = driver.FindElement(By.CssSelector("button[class='button is-block is-info is-large is-fullwidth'"));
            openTenderButton.Click();
            System.Threading.Thread.Sleep(2000);
        }
    }
}
