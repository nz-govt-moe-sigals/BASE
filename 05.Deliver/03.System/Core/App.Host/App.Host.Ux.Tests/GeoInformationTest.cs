using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App.Host.Ux.Tests.Fixture;
using App.Host.Ux.Tests.Models;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace App.Host.Ux.Tests
{
    public class GeoInformationTest : IClassFixture<TokenFixture>
    {
        protected readonly TokenFixture Fixture;

        public GeoInformationTest(TokenFixture fixture)
        {
            Fixture = fixture;
        }

        [Scenario(DisplayName = "GeoInfromationRequest")]
        public void GeoInfromationRequest()
        {
            HttpResponseMessage response = null;
            string token = null;
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    token = Fixture.GetAuthToken();
                });
            "Act - When I make a Http Request to a restricted GeoInfomration API"
                .x(() =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var url = Configuration.Instance.DefaultUrl + "odata/core/v1/GeoInformation";
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                        // Add token to the Authorization header and make the request

                        response = client.GetAsync(new Uri(url)).Result;
                    }
                });
            $"Assert - Then the response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = response.Content.ReadAsStringAsync().Result;
                    //result.Status.Should().Be(responseMessage);
                });
        }
    }
}
