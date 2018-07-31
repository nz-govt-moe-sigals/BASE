using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DoesStudentExistApiTests : IClassFixture<TokenFixture>
    {
        private readonly TokenFixture _fixture;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Rest of the logic to be covered by unit tests
        /// </summary>
        /// <param name="fixture"></param>
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

        [Scenario(DisplayName = "ExactMatchForStudent")]
        public void ExactMatchForStudent()
        {
            HttpResponseMessage response = null;
            StudentDto studentDto = null;
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    studentDto = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2011, 11, 01),
                        FullName = "Guywood Threepwood",
                        Gender = "M",
                        SchoolId = SchoolData.GetSchoolData_999998().SchoolId,
                        StudentId = "TestUserv1"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999998());
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
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("EnrolledAtSchool");
                });
        }

        [Scenario(DisplayName = "ExactMatchForStudent v2")]
        public void ExactMatchForStudentv2()
        {
            HttpResponseMessage response = null;
            StudentDto studentDto = null;
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    studentDto = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2008, 09, 21),
                        FullName = "JaJa Binks",
                        Gender = "M",
                        SchoolId = SchoolData.GetSchoolData_999997().SchoolId,
                        StudentId = "TestUserv2"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999997());
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    studentDto.FullName = "jaja binks";
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("EnrolledAtSchool");
                });
        }

        [Scenario(DisplayName = "TwoVariationForStudent")]
        public void TwoVariationForStudent()
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
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId,
                        StudentId = "TestUser1"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999999());
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    studentDto.FullName = "est User MumboNo6";
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("EnrolledAtSchool");
                });
        }

        [Scenario(DisplayName = "TwoVariationForStudent Any order")]
        public void TwoVariationForStudentAnyOrder()
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
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId,
                        StudentId = "TestUser1"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999999());
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    studentDto.FullName = "Use MuboNo5 Test";
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("EnrolledAtSchool");
                });
        }

        [Scenario(DisplayName = "StudentFoundNotAtSchool")]
        public void StudentFoundNotAtSchool()
        {
            HttpResponseMessage response = null;
            StudentDto studentDto = null;
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    studentDto = new StudentDto()
                    {
                        DateOfBirth = new DateTime(2011, 11, 01),
                        FullName = "SomeOther Person Dunno",
                        Gender = "M",
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId,
                        StudentId = "TestUser2"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999998());
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    studentDto.SchoolId = SchoolData.GetSchoolData_999998().SchoolId;
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("Enrolled");
                });
        }

        [Scenario(DisplayName = "ThreeVariationForStudent - Not found")]
        public void ThreeVariationForStudent()
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
                        SchoolId = SchoolData.GetSchoolData_999999().SchoolId,
                        StudentId = "TestUser1"
                    };
                    _fixture.InsertSchool(SchoolData.GetSchoolData_999999());
                    _fixture.InsertStudent(studentDto);
                });

            "Act - When I make a Http Request to a restricted DoesStudentExist API"
                .x(async () =>
                {
                    studentDto.FullName = "est Usr MumboNo6";
                    response = await MakeApiRequestAsync(studentDto);
                });
            "Assert - Then the I response should be successful"
                .x(() =>
                {
                    response.Should().NotBeNull();
                    response.IsSuccessStatusCode.Should().BeTrue();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentDoesExistResult>(response.Content.ReadAsStringAsync().Result);
                    result.Status.Should().Be("NotEnrolled");
                });
        }

    }
}
