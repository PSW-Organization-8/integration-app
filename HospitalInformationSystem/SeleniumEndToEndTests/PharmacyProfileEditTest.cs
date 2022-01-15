using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumEndToEndTests
{
    public class PharmacyProfileEditTest
    {
        private IWebDriver driver;
        private readonly string frontEndAddress = Environment.GetEnvironmentVariable("FRONTEND_ADDRESS") ?? @"http://localhost:4200/";
        private readonly string localTest = Environment.GetEnvironmentVariable("LOCAL_TEST") ?? "false";


        [SkippableFact(typeof(SkipException))]
        public void Pharmacy_profile_edit_Chrome()
        {
            Skip.IfNot(localTest.Equals("true"));

            CreateDriver();
            driver.Navigate().GoToUrl(frontEndAddress + @"pharmacyProfile/3");
            EnsurePageIsDisplayed();
            var notesElement = driver.FindElement(By.Name("notes"));
            string oldText = notesElement.GetAttribute("value");
            notesElement.Clear();
            notesElement.SendKeys("Neki novi opis");
            var updateButton = driver.FindElement(By.Id("updateButton"));
            updateButton.Click();

            driver.Navigate().GoToUrl(frontEndAddress + @"pharmacyProfile/3");
            EnsurePageIsDisplayed();
            var notesElementEdited = driver.FindElement(By.Name("notes"));
            string updatedText = notesElementEdited.GetAttribute("value");

            updatedText.ShouldBe("Neki novi opis");
            ReturnToPreviousState(oldText);
            Dispose();
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

        private void ReturnToPreviousState(string oldText)
        {
            var textArea = driver.FindElement(By.Name("notes"));
            textArea.Clear();
            textArea.SendKeys(oldText);
            var button = driver.FindElement(By.Id("updateButton"));
            button.Click();
        }

        private void EnsurePageIsDisplayed()
        {
            System.Threading.Thread.Sleep(1000);
        }

        private void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
