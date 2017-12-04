namespace App.Core.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net;
    using System.Reflection;
    using App.Core.Infrastructure.Services;
    using App.Core.Shared.Models.Entities;
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Deserializers;

    public class ScaniiClient
    {
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly RestClient client;

        public ScaniiClient(IDiagnosticsTracingService diagnosticsTracingService, string key, string secret,
            string baseUri = "https://api.scanii.com/v2.1")
        {
            this.BaseUri = baseUri;

            if (string.IsNullOrWhiteSpace(this.BaseUri))
            {
                this.BaseUri = "https://api.scanii.com/v2.1";
            }

            this._diagnosticsTracingService = diagnosticsTracingService;

            this.client = new RestClient(this.BaseUri)
            {
                Authenticator = new HttpBasicAuthenticator(key, secret),
                UserAgent = "scanii-csharp/v" + Assembly.GetExecutingAssembly().GetName().Version
            };


            Log("Running in debug mode " + Assembly.GetExecutingAssembly().GetName());
            Log("Base URI: " + this.BaseUri);
        }

        public string BaseUri { get; }


        public ScaniiResult Process(byte[] bytes, string fileName, string contentMimeType,
            Dictionary<string, string> metadata = null)
        {
            if (metadata == null)
            {
                metadata = new Dictionary<string, string>();
            }
            var restRequest = new RestRequest("files") {RequestFormat = DataFormat.Json};

            // adding payload
            restRequest.AddFileBytes("file", bytes, fileName, contentMimeType);

            //restRequest.AddFile("file", path);

            foreach (var keyValuePair in metadata)
            {
                Log("medata item " + keyValuePair);
                restRequest.AddParameter($"metadata[{keyValuePair.Key}]", keyValuePair.Value);
            }

            var restResponse = this.client.Post(restRequest);
            Log("content " + restResponse.Content);
            Log("status code " + restResponse.StatusCode);

            if (restResponse.StatusCode != HttpStatusCode.Created)
            {
                throw new ScaniiException(
                    $"Invalid HTTP response status: {restResponse.StatusCode} message: {restResponse.Content}");
            }

            Log("response: " + restResponse.Content);
            var json = restResponse.Content;

            var result =
                JsonConvert.DeserializeObject<ScaniiResult>(json);

            return result;
        }

        public string Retrieve(string id)
        {
            Contract.Requires(id != null);
            Log($"loading id: {id}");

            var req = new RestRequest("/files/{id}") {RequestFormat = DataFormat.Json};
            req.AddUrlSegment("id", id);
            var resp = this.client.Get(req);

            Log("content " + resp.Content);
            Log("status code " + resp.StatusCode);

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new ScaniiException($"Invalid HTTP response status: {resp.StatusCode} message: {resp.Content}");
            }

            Log("response: " + resp.Content);
            return resp.Content;
        }


        private void Log(string message)
        {
            this._diagnosticsTracingService.Trace(TraceLevel.Verbose, "ScaniiClient: " + message);
        }
    }

    public class ScaniiException : Exception
    {
        public ScaniiException(string s) : base(s)
        {
        }
    }

    public class ScaniiResult
    {
        public long ContentLength;

        public DateTime? CreationDate = null;
        public List<string> Findings = new List<string>();
        public Dictionary<string, string> Metadata = new Dictionary<string, string>();

        public string RawResponse;

        [DeserializeAs(Name = "id")]
        public string Id { get; set; }

        [DeserializeAs(Name = "checksum")]
        public string CheckSum { get; set; }

        [DeserializeAs(Name = "content_type")]
        public string ContentType { get; set; }

        public override string ToString()
        {
            return
                $"RawResponse: {this.RawResponse}, ContentLength: {this.ContentLength}, Findings: {this.Findings}, CreationDate: {this.CreationDate}, Metadata: {this.Metadata}, Id: {this.Id}, CheckSum: {this.CheckSum}, ContentType: {this.ContentType}";
        }
    }
}