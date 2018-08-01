
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using App.Module32.Ux.Tests.Fixture;
using App.Module32.Ux.Tests.Models;
using App.Module32.Ux.Tests.Utility;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace App.Module32.Ux.Tests
{
    public class SchoolApiTests : IClassFixture<TokenFixture>
    {
        private readonly TokenFixture _fixture;
        private readonly HttpClient _httpClient;

        public SchoolApiTests(TokenFixture fixture)
        {
            
            _fixture = fixture;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Scenario(DisplayName = "Call a Get Schools API Without Token - Open")]
        public void CallSchoolsApiOpen()
        {
            HttpResponseMessage response = null;
            "When I make a Http Request to a unrestricted Schools API"
                .x(async () =>
                {
                    var url = Configuration.Instance.DefaultUrl + "odata/ate/v1/schools";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await _httpClient.SendAsync(request);
                });
            "Then the response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                });
        }

        [Scenario(DisplayName = "Call a Get Schools API Without Token - and ensure data is correct")]
        public void CallSchoolsApiOpen_CheckData()
        {
            HttpResponseMessage response = null;
            SchoolDto dto = null;
            "When I Set up Data"
                .x(() =>
                {
                    dto = new SchoolDto()
                    {
                        SchoolId = 999999,
                        Name = "Test School 999999"
                    };
                    _fixture.InsertSchool(dto);
                });
            "When I make a Http Request to a unrestricted Schools API"
                .x(async () =>
                {
                    var url = Configuration.Instance.DefaultUrl + "odata/ate/v1/schools?$orderby=SchoolId%20desc";
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await _httpClient.SendAsync(request);
                });
            "Then the response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseWrapper<List<SchoolDto>>>(response.Content
                        .ReadAsStringAsync().Result);
                    obj.Should().NotBeNull();
                    obj.Value.Count.Should().BeGreaterThan(0);
                    obj.Value.Any(x => x.SchoolId == dto.SchoolId).Should().BeTrue();
                });
        }

    }
}
