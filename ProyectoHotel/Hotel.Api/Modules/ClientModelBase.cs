using Hotel.Api.Models.Core;

namespace Hotel.Api.Client
{
    public class ClientModelBase : ModelBase
    {
        public string? FullName { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
        public bool State { get; set; }
        public string? Mail { get; set; }

     
    }
}