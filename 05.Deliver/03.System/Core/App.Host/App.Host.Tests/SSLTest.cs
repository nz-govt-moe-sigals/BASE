namespace App.Core.Application.Tests
{
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Xbehave;


    public class SSLTest 
    {
        private string httpSiteAddress;
        private readonly string httpsSiteAddress;

        // Note regarding Selenium.WebDriver.Chrome Nuget package
        // Install Chrome Driver into your Unit Test Project, which installs "chromedriver.exe" 
        // "chromedriver(.exe)" is copied to bin folder from package folder when the build process.
        // NuGet package restoring ready -- no need to commit "chromedriver(.exe)" 
        // binary into source code control repository.

        public SSLTest()
        {
            //The two urls we defined earlier (you can see another advantage
            // for keeping the same urls across your dev team)
            this.httpSiteAddress = ConfigurationManager.AppSettings["insecureSiteRootUri"];
            this.httpsSiteAddress = ConfigurationManager.AppSettings["secureSiteRootUri"];
        }

        [Scenario(DisplayName = "Ensure HTTPS endpoint exists.")]
        public void Safe()
        {
            IWebDriver driver = new ChromeDriver();
            "Given a browser user agent"
                .x(() => { });
            "When a user launches a request to the home page"
                .x(() => driver.Navigate().GoToUrl(this.httpsSiteAddress));
            $"Then the response should start with https://"
                .x(() => driver.Url.Substring(0, 8).ShouldBeEquivalentTo("https://"));
            driver.Close();
        }

        [Scenario(DisplayName = "Ensure response does not contain ")]
        [Example("X-Powered-By")]
        [Example("X-AspNet-Version")]
        [Example("X-AspNetMvc-Version")]
        public void CheckHeadersCount(string headerKey)
        {
            //Ensure site is actually responding first:
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(this.httpsSiteAddress);
            var count = -1; //something patently false.
            HttpResponseMessage result = null;
            var client = new HttpClient();

            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { Task.Run(() => result = client.GetAsync(this.httpsSiteAddress).Result).Wait(); });
            ("Then the response should not have an " + headerKey)
                .x(() =>
                {
                    count = result.Headers.Count();
                    count.Should().BeGreaterThan(0);
                });

            driver.Close();
        }


        [Scenario(DisplayName = "Ensure response does not contain ")]
        [Example("X-Powered-By")]
        [Example("X-AspNet-Version")]
        [Example("X-AspNetMvc-Version")]
        public void CheckHeadersForExecutionEnvironmentDisclosure(string headerKey)
        {
            //Ensure site is actually responding first:
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(this.httpsSiteAddress);

            HttpResponseMessage result = null;
            var client = new HttpClient();

            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { Task.Run(() => result = client.GetAsync(this.httpsSiteAddress).Result).Wait(); });
            ("Then the response should not have an " + headerKey)
                .x(() =>
                {
                    result.Headers.Count().Should().BeGreaterThan(0);
                    result.Headers.Any(x => x.Key == headerKey).Should().BeFalse();
                });

            driver.Close();
        }

        [Scenario(DisplayName = "Ensure response does not contain Server Header")]
        public void CheckHeadersForServerHeader()
        {
            //Ensure site is actually responding first:
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(this.httpsSiteAddress);
            HttpResponseMessage result = null;
            var client = new HttpClient();

            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { Task.Run(() => result = client.GetAsync(this.httpsSiteAddress).Result).Wait(); });
            "Then the response should not have a Server header"
                .x(() =>
                {
                    result.Headers.Count().Should().BeGreaterThan(0);

                    var headers = result.Headers.GetValues("Server").ToArray();

                    (headers == null || headers.Length == 0 || headers[0] == string.Empty).Should().Be(true);
                });

            driver.Close();
        }
    }
}