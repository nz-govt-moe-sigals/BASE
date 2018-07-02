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

        // Note regarding Selenium.WebDriver.Chrome Nuget package
        // Install Chrome Driver into your Unit Test Project, which installs "chromedriver.exe" 
        // "chromedriver(.exe)" is copied to bin folder from package folder when the build process.
        // NuGet package restoring ready -- no need to commit "chromedriver(.exe)" 
        // binary into source code control repository.
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
            System.Threading.Thread.Sleep(1000); // don't do this Normally
            Assert.True(_driver.Title.Contains("VSTS"), "Verified title of the page");
        }


        [Fact]
        public void TestMethodMoreTargetedExample()
        {
            _driver.Navigate().GoToUrl(Configuration.Instance.DefaultUrl);
            System.Threading.Thread.Sleep(1000); // don't do this Normally
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
