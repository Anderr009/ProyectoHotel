

namespace Hotel.application.Dtos.Client
{
    public class ClientDtoBase : DtoBase
    {
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
        public string? FullName { get; set; }
        public string? Mail { get; set; }
        public bool State { get; set; }
    }
}
