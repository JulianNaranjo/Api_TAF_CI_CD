using System.Text.Json;
using RestSharp;

namespace TestAutomationFramework.Core
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;

        public RequestBuilder(string endpoint, Method method)
        {
            _request = new RestRequest(endpoint, method);
        }

        public RequestBuilder AddJsonBody(object body)
        {
            _request.AddJsonBody(JsonSerializer.Serialize(body));
            return this;
        }

        public RestRequest Build()
        {
            return _request;
        }
    }
}