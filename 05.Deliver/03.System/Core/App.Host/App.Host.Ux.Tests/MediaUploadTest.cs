using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.Host.Ux.Tests.Fixture;
using App.Host.Ux.Tests.Models;
using FluentAssertions;
using Xbehave;
using Xunit;

namespace App.Host.Ux.Tests
{
    public class MediaUploadTest : IClassFixture<TokenFixture>
    {

        protected readonly TokenFixture Fixture;

        public MediaUploadTest(TokenFixture fixture)
        {
            Fixture = fixture;
        }

        [Scenario(DisplayName = "Test Media ")]
        public void MediaUploadRequest()
        {
            HttpResponseMessage response = null;
            string token = null;
            var filename = "FileUpload.txt";
            var filepath = Configuration.Instance.GetExecutingAssemblyLocation($"\\{filename}");
            "Arrange - When I the set the data up"
                .x(() =>
                {
                    token = Fixture.GetAuthToken();
                });
            "Act - When I make a Http Request to a restricted email API"
                .x(() =>
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        var url = Configuration.Instance.DefaultUrl + "api/MediaUpload/Upload";
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                        using (var reader = new System.IO.FileStream(filepath, FileMode.Open))
                        using (var formData = new MultipartFormDataContent())
                        {
                            // Add token to the Authorization header and make the request
                            var content = new StreamContent(reader);
                            content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(filepath));
                            formData.Add(content, filename, filename);
                            response = client.PostAsync(new Uri(url), formData).Result;
                        }
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



        private async Task<HttpResponseMessage> Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                return  await client.PostAsync(actionUrl, formData);
               
            }
        }
    }
}
