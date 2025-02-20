using System.Net;

namespace TestAutomationFramework.Models
{
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? StatusDescription { get; set; }
        public string ContentHeaders { get; set; }
        public T Data { get; set; }
        public string RawContent { get; set; }
        public User User { get; set; }
    }
}
