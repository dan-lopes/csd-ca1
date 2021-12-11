using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace BPCalculator.E2ETests
{
    public class BPCalculatorE2ETests
    {
        private readonly IConfiguration _configuration;
        private readonly string _webAppUri;

        public BPCalculatorE2ETests()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            _webAppUri = _configuration.GetValue<string>("webAppUri");
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_LowBloodPressure()
        {
            var bpCategory = BloodPressureCalculator(80, 60);
            Assert.Contains(bpCategory, "Low Blood Pressure");
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_IdealBloodPressure()
        {
            var bpCategory = BloodPressureCalculator(120, 80);
            Assert.Contains(bpCategory, "Ideal Blood Pressure");
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_PreHighBloodPressure()
        {
            var bpCategory = BloodPressureCalculator(130, 80);
            Assert.Contains(bpCategory, "Pre-High Blood Pressure");
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_HighBloodPressure()
        {
            var bpCategory = BloodPressureCalculator(190, 100);
            Assert.Contains(bpCategory, "High Blood Pressure");
        }

        private string BloodPressureCalculator(int systolic, int diastolic)
        {
            var chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? ".";

            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-dev-shm-usage");

            using var driver = new ChromeDriver(chromeDriverPath, options);
            driver.Navigate().GoToUrl(_webAppUri);

            var systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Clear();
            systolicElement.SendKeys(systolic.ToString());

            var diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Clear();
            diastolicElement.SendKeys(diastolic.ToString());

            driver.FindElement(By.Id("button_submit")).Submit();

            var resultElement =
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id("alert_result")));

            var bpCategory = resultElement.Text;

            driver.Quit();

            return bpCategory;
        }
    }
}