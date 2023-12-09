using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.Web.Models.Response
{
    public class ClientListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<ClientViewModel> data { get; set; }
    }
    
    public class ClientViewModel
    {
        public string? FullName { get; set; }
        public string? Mail { get; set; }
        public int ClientId { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
        public bool State { get; set; }
    }

}
