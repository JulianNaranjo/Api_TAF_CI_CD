using TestAutomationFramework.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using RestSharp;
using RestSharp.Serializers.Json;
using TestAutomationFramework.Helpers;

namespace TestAutomationFramework.Core
{
    public class JsonPlaceholderClient
    {
        private readonly IRestClient client;
        private RestResponse response = null;
        private RestRequest request;

        public JsonPlaceholderClient(string baseUrl)
        {
            var serializerOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

            client = new RestClient(
                options: new() { BaseUrl = new(baseUrl) },
                configureSerialization: s => s.UseSystemTextJson(serializerOptions));
        }

        public  void CreatedRequestAndSetResponse(string endpoint, string methodType)
        {
            if (methodType == "GET")
            {
                request = new RequestBuilder(endpoint, Method.Get).Build();
                response = client.Execute(request);

            }else if (methodType == "POST")
            {
                var newUser = CreateUsers.GenerateRandomUser();
                request = new RequestBuilder(endpoint, Method.Post).AddJsonBody(newUser).Build();
                response = client.Execute(request);
            }
        }

        public ApiResponse<List<User>> GetUsersAsync()
        {
            Console.WriteLine("get response " + response);
            var users = JsonSerializer.Deserialize<List<User>>(response.Content, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var contentHeaders = response.ContentHeaders.FirstOrDefault(
                h => h.Name.Equals("Content-type", StringComparison.OrdinalIgnoreCase))
                ?.Value?.ToString();
            return new ApiResponse<List<User>>
            {
                StatusCode = response.StatusCode,
                Data = users,
                ContentHeaders = contentHeaders,
                RawContent = response.Content
            };
        }

        public ApiResponse<User> CreateUserAsync()
        {
            var user = JsonSerializer.Deserialize<User>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            Logger.LogInfo($"API testing -- Data user: {user}");
            
            return new ApiResponse<User>
            {
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription,
                User = user,
            };
        }

        public async Task<ApiResponse<List<User>>> GetNotResourceAsync()
        {
            return new ApiResponse<List<User>>
            {
                StatusCode = response.StatusCode,
            };
        }

    }
}
