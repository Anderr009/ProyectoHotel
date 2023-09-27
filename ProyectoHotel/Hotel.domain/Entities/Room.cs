using Hotel.domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Room : Status
    {
        public int IdHabitacion { get; set; }
        public int Numero { get; set; }
        public string Detalle { get; set; }
        public double Precio { get; set; }
        public int IdEstadoHabitacion { get; set; }
        public int IdPiso { get; set; }
        public int IdCategoria { get; set; }
    }
}
