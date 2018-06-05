using App.Core.Shared.Attributes;

namespace App.Module01.Shared.Models.Configuration
{
    /// <summary>
    ///     A Configuration object used by a Service Client
    ///     (eg: an MVC app making calls to a remote backend service)
    ///     to describe the service being Consumed from a Service Provider.
    ///     <para>
    ///         This is not used by the WebAPI app that provides the service to others.
    ///     </para>
    /// </summary>
    public class ExampleApiConfiguration
    {
        private string _serviceIdentifier;

        /// <summary>
        ///     The Service Identifier is the uri that was developed when the Service (not the Client)
        ///     was registered.
        ///     <para>
        ///         Used by both the API Provider, in its Setup phase, and the Consumer when it is about to make a remote API
        ///         call.
        ///     </para>
        ///     <para>eg: https://myb2c.onmicrosoft.com/example_webapi </para>
        ///     <para>
        ///         Note: When registering the Service as an App in the B2C, the Url should have been registered
        ///         with a final slash as it will be prefixed to Scopes (eg:'example.read' would become
        ///         `https://myb2c.onmicrosoft.com/example_webapi/exampe.read`) to disambiguate
        ///         across services with the same scope name.
        ///     </para>
        /// </summary>
        [Alias("api:ServiceIdentifier")]
        public string ServiceIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(this._serviceIdentifier) && !this._serviceIdentifier.EndsWith("/"))
                {
                    //Ensure it ends with a slash, so that it can be easily 
                    // joined up with Scope.
                    this._serviceIdentifier += "/";
                }
                return this._serviceIdentifier;
            }
            set => this._serviceIdentifier = value;
        }


        /// <summary>
        ///     One of the Scope/Permission tags developed when the Service was registered within the B2C.
        ///     <para>
        ///         In this case, we're talking about consuming a service to allow reading to example
        ///         entities -- which might have been labelled 'example.read', or 'example/read'
        ///     </para>
        ///     <para>
        ///         Used by both the API Provider, in its Setup phase, and the Consumer when it is about to make a remote API
        ///         call.
        ///     </para>
        /// </summary>
        [Alias("api:Example.ReadScope")]
        public string ExampleReadScope { get; set; }


        public string FQExampleReadScope => this.ServiceIdentifier + this.ExampleReadScope;

        /// <summary>
        ///     One of the Scope/Permission tags developed when the Service was registered within the B2C.
        ///     <para>
        ///         In this case, we're talking about consuming a service to allow writting to example
        ///         entities -- which might have been labelled 'example.write', or 'example/write'
        ///     </para>
        ///     <para>
        ///         Used by both the API Provider, in its Setup phase, and the Consumer when it is about to make a remote API
        ///         call.
        ///     </para>
        /// </summary>
        [Alias("api:Example.WriteScope")]
        public string ExampleWriteScope { get; set; }


        public string FQExampleWriteScope => this.ServiceIdentifier + this.ExampleWriteScope;

        /// <summary>
        ///     The base Url of the server on which the Service is offered.
        ///     <para>This will be the base url of the remote service being consumed.</para>
        ///     <para>
        ///         Whereas the other variables (ServiceIdentifier, Write/read Scope) are used by
        ///         both the Provider and Consumer apps, this property is only used by the
        ///         Consumer, when it builds up the Uri in order to the call to the remote API.
        ///     </para>
        ///     <para>
        ///         Note that in this 'articificial' scenario where we are registereing the app
        ///         twice with B2B (in order to demonstrate both features in one app) this 'remote' url
        ///         happens to be the same base url as the consumer client app.
        ///     </para>
        ///     <para>http://localhost:43311</para>
        /// </summary>
        [Alias("api:ServiceUrl")]
        public string ServiceUrl { get; set; }
    }
}