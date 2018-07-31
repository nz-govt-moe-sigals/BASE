using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Ux.Tests.Fixture;
using App.Module32.Ux.Tests.Models;
using App.Module32.Ux.Tests.Models.Data;
using App.Module32.Ux.Tests.Utility;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace App.Module32.Ux.Tests
{
    public class ForbiddenApiTests : IClassFixture<TokenFixture>
    {
        private readonly TokenFixture _fixture;
        private readonly HttpClient _httpClient;

        public ForbiddenApiTests(TokenFixture fixture)
        {
            _fixture = fixture;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }


        [Scenario(DisplayName = "Call a Get DoesStudentExist Without Token - Forbidden")]
        public void CallDoesStudentExistForbidden()
        {
            HttpResponseMessage response = null;
            "When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    var queryparam = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2011, 11, 01),
                        FullName = "Test User MumboNo5",
                        Gender = "M",
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId
                    }.ToQueryString();
                    var url = Configuration.Instance.DefaultUrl + "api/Transport/DoesStudentExist" + queryparam;
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await _httpClient.SendAsync(request);
                });
            "Then the response should not be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeFalse();
                });
        }



        [Scenario(DisplayName = "Call a Post Student Without Token - Forbidden")]
        public void CallPostStudentForbidden()
        {
            HttpResponseMessage response = null;
            "When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    var dto = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2011, 11, 01),
                        FullName = "Test User MumboNo5",
                        Gender = "M",
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId
                    };
                    var url = Configuration.Instance.DefaultUrl + "odata/ate/v1/students";
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                    // Add token to the Authorization header and make the request
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await _httpClient.PostAsync(new Uri(url), content);
                });
            "Then the response should not be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeFalse();
                });
        }


        [Scenario(DisplayName = "Call a Post School Without Token - Forbidden")]
        public void CallPostSchoolForbidden()
        {
            HttpResponseMessage response = null;
            "When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    var dto = SchoolData.GetSchoolData_999999();
                    var url = Configuration.Instance.DefaultUrl + "odata/ate/v1/schools";
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                    // Add token to the Authorization header and make the request
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    response = await _httpClient.PostAsync(new Uri(url), content);
                });
            "Then the response should not be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeFalse();
                });
        }
    }
}
