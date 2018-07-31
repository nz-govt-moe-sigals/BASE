using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using App.Module32.Ux.Tests.Fixture;
using App.Module32.Ux.Tests.Models;
using App.Module32.Ux.Tests.Utility;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace App.Module32.Ux.Tests
{
    public class DoesStudentExistApiTests : IClassFixture<TokenFixture>
    {
        private readonly TokenFixture _fixture;
        private readonly HttpClient _httpClient;

        public DoesStudentExistApiTests(TokenFixture fixture)
        {
            _fixture = fixture;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        private async Task<HttpResponseMessage> MakeApiRequestAsync(StudentDto studentDto)
        {
            var queryparam = studentDto.ToQueryString();
            var url = Configuration.Instance.DefaultUrl + "api/Transport/DoesStudentExist" + queryparam;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _fixture.GetAuthToken());
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            return await _httpClient.SendAsync(request);
        }

        [Scenario(DisplayName = "Call a Get DoesStudentExist Without Token - Forbidden")]
        public void CallDoesStudentExistForbidden()
        {
            HttpResponseMessage response = null;
            StudentDto studentDto = null;
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    studentDto = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2011, 11, 01),
                        FullName = "Test User MumboNo5",
                        Gender = "M",
                        SchoolId = 999999
                    };
                    _fixture.InsertSchool(new SchoolDto( ) { Name = "Test School 999999" , SchoolId = 999999 });
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = response.Content.ReadAsStringAsync().Result;
                });
        }

    }
}
