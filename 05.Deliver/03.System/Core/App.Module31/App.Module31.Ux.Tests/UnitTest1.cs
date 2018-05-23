using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace App.Module31.Ux.Tests
{

    /// <summary>
    /// EXAMPLE TODO RE-WRITE XUNIT
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;
        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.bing.com/";
#if DEBUG
            driver = new ChromeDriver();
#else
            driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
#endif


        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("VSTS");
            driver.FindElement(By.Id("sb_form_go")).Click();
            driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
            Assert.IsTrue(driver.Title.Contains("VSTS"), "Verified title of the page");
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
