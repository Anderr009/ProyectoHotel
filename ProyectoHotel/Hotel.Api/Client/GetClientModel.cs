namespace Hotel.Api.Client
{
    public class GetClientModel
    {
        public string? FullName { get; set; }
        public int ClientId { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }

        public string? State { get; set; }
        public string? Mail { get; set; }
    }
}
