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
        private IConfiguration _configuration;

        public BPCalculatorE2ETests()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_LowBloodPressure()
        {
            using (var driver = GetChromeDriver())
            {
                var bpCategory = BloodPressureCalculator(driver, 80, 60);
                driver.Quit();

                Assert.Contains(bpCategory, "Low Blood Pressure");
            }
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_IdealBloodPressure()
        {
            using (var driver = GetChromeDriver())
            {
                var bpCategory = BloodPressureCalculator(driver, 120, 80);
                driver.Quit();

                Assert.Contains(bpCategory, "Ideal Blood Pressure");
            }
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_PreHighBloodPressure()
        {
            using (var driver = GetChromeDriver())
            {
                var bpCategory = BloodPressureCalculator(driver, 130, 80);
                driver.Quit();

                Assert.Contains(bpCategory, "Pre-High Blood Pressure");
            }
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_HighBloodPressure()
        {
            using (var driver = GetChromeDriver())
            {
                var bpCategory = BloodPressureCalculator(driver, 190, 100);
                driver.Quit();

                Assert.Contains(bpCategory, "High Blood Pressure");
            }
        }

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_Charts_Are_Displayed()
        {
            using (var driver = GetChromeDriver())
            {
                var systolic = 190;
                var diastolic = 100;

                BloodPressureCalculator(driver, systolic, diastolic);

                var chartSystolicDiv = FindElementWait(driver, "chart_div_systolic");
                var chartDiastolicDiv = FindElementWait(driver, "chart_div_diastolic");

                var chartSystolicDisplayed = chartSystolicDiv.Displayed;
                var chartDiastolicDisplayed = chartDiastolicDiv.Displayed;

                var chartSystolic = chartSystolicDiv.FindElements(By.TagName("text"))[1].Text;
                var chartDiastolic = chartDiastolicDiv.FindElements(By.TagName("text"))[1].Text;

                driver.Quit();

                Assert.True(chartSystolicDisplayed);
                Assert.True(chartDiastolicDisplayed);

                Assert.Equal(systolic, int.Parse(chartSystolic));
                Assert.Equal(diastolic, int.Parse(chartDiastolic));
            }
        }

        private ChromeDriver GetChromeDriver()
        {
            var webAppUri = _configuration.GetValue<string>("webAppUri");

            var chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? ".";

            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-dev-shm-usage");

            var driver = new ChromeDriver(chromeDriverPath, options);
            driver.Navigate().GoToUrl(webAppUri);

            return driver;
        }

        private string BloodPressureCalculator(IWebDriver driver, int systolic, int diastolic)
        {
            var systolicElement = driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Clear();
            systolicElement.SendKeys(systolic.ToString());

            var diastolicElement = driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Clear();
            diastolicElement.SendKeys(diastolic.ToString());

            driver.FindElement(By.Id("button_submit")).Submit();

            var resultElement = FindElementWait(driver, "alert_result");

            var bpCategory = resultElement.Text;

            return bpCategory;
        }

        private IWebElement FindElementWait(IWebDriver driver, string elementName)
        {
            var element =
                new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id(elementName)));

            return element;
        }
    }
}