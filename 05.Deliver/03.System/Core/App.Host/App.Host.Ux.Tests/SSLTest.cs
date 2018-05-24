
using System.Linq;
using System.Net.Http;
using Tasks = System.Threading.Tasks;
using FluentAssertions;
using Xbehave;

namespace App.Host.Ux.Tests
{
    public class SslTest
    {
        private readonly string _baseurl;
        public SslTest()
        {
            _baseurl = Configuration.Instance.DefaultUrl;
        }

        [Scenario(DisplayName = "Ensure response Has Headers")]
        public void CheckHeadersCount()
        {
            HttpResponseMessage result = null;
            var client = new HttpClient();
            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { result = client.GetAsync(_baseurl).Result; });
            "Then the response should not have a Server header"
                .x(() =>
                {
                    result.Headers.Count().Should().BeGreaterThan(0);
                });
        }


        [Scenario(DisplayName = "Ensure response does not contain ")]
        [Example("X-Powered-By")]
        [Example("X-AspNet-Version")]
        [Example("X-AspNetMvc-Version")]
        public void CheckHeadersRemoved(string headerKey)
        {
            HttpResponseMessage result = null;
            var client = new HttpClient();

            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { result = client.GetAsync(_baseurl).Result; });
            ("Then the response should not have an " + headerKey)
                .x(() =>
                {
                    foreach (var header in result.Headers)
                    {
                        header.Key.Should().NotBe(headerKey);
                    }
                });
        }


        [Scenario(DisplayName = "Ensure response does not contain Server Header")]
        public void CheckHeadersForServerHeaderIsEmpty()
        {
            HttpResponseMessage result = null;
            var client = new HttpClient();
            "Given a browser user"
                .x(() => { });
            "When a user requests the secure home page"
                .x(() => { result = client.GetAsync(_baseurl).Result; });
            "Then the response should not have a Server header"
                .x(() =>
                {
                    var headers = result.Headers.GetValues("Server").ToArray();
                    ( headers.Length == 1 || headers[0] == string.Empty).Should().Be(true);
                });
        }
    }
}
