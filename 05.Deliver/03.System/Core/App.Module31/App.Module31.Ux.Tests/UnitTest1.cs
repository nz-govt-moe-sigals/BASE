using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;


namespace App.Module31.Ux.Tests
{

    /// <summary>
    /// EXAMPLEs
    /// </summary>

    public class UnitTest1 : IDisposable
    {
        private IWebDriver _driver;

        public UnitTest1()
        {

#if DEBUG
            _driver = new ChromeDriver();
#else
            _driver = new ChromeDriver(Environment.GetEnvironmentVariable("ChromeWebDriver"));
#endif

        }

        //TODO del
        [Fact]
        public void TestMethodExmple()
        {
            _driver.Navigate().GoToUrl("http://www.bing.com/");
            _driver.FindElement(By.Id("sb_form_q")).SendKeys("VSTS");
            _driver.FindElement(By.Id("sb_form_go")).Click();
            _driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
            Assert.True(_driver.Title.Contains("VSTS"), "Verified title of the page");
        }


        [Fact]
        public void TestMethodMoreTargetedExample()
        {
            _driver.Navigate().GoToUrl(Configuration.Instance.DefaultUrl);
            Assert.True(_driver.Title.Contains("App Foundation"), "Verified title of the page");
        }

        public void Dispose()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }
    }
}
