using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.application.Dtos.Client
{
    public class ClientDtoUpdate
    {
        public int IdClient { get; set; }
        public string? FullName { get; set; }
        public string? DocumentType { get; set; }
        public string? Document { get; set; }
        public bool State { get; set; }
        public string? Mail { get; set; }
        public int ChangeUser { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
