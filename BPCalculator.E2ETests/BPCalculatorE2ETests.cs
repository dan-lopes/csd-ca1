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
        private readonly ChromeDriver _driver;

        public BPCalculatorE2ETests()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            var webAppUri = configuration.GetValue<string>("webAppUri");

            var chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? ".";

            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--headless");
            options.AddArgument("--disable-dev-shm-usage");

            _driver = new ChromeDriver(chromeDriverPath, options);
            _driver.Navigate().GoToUrl(webAppUri);
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

        [Fact]
        public void BloodPressureCalculator_E2E_Selenium_Test_Charts_Are_Displayed()
        {
            var systolic = 190;
            var diastolic = 100;

            BloodPressureCalculator(systolic, diastolic);

            var chartSystolicDiv = FindElementWait("chart_div_systolic");
            var chartDiastolicDiv = FindElementWait("chart_div_diastolic");

            Assert.True(chartSystolicDiv.Displayed);
            Assert.True(chartDiastolicDiv.Displayed);

            var chartSystolic = chartSystolicDiv.FindElements(By.TagName("text"))[1].Text;
            var chartDiastolic = chartDiastolicDiv.FindElements(By.TagName("text"))[1].Text;

            Assert.Equal(systolic, int.Parse(chartSystolic));
            Assert.Equal(diastolic, int.Parse(chartDiastolic));
        }

        private string BloodPressureCalculator(int systolic, int diastolic)
        {
            var systolicElement = _driver.FindElement(By.Id("BP_Systolic"));
            systolicElement.Clear();
            systolicElement.SendKeys(systolic.ToString());

            var diastolicElement = _driver.FindElement(By.Id("BP_Diastolic"));
            diastolicElement.Clear();
            diastolicElement.SendKeys(diastolic.ToString());

            _driver.FindElement(By.Id("button_submit")).Submit();

            var resultElement = FindElementWait("alert_result");

            var bpCategory = resultElement.Text;

            return bpCategory;
        }

        private IWebElement FindElementWait(string elementName)
        {
            var element =
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(c => c.FindElement(By.Id(elementName)));

            return element;
        }

        ~BPCalculatorE2ETests()
        {
            _driver.Quit();
        }
    }
}