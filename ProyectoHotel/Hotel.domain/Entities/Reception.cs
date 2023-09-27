using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.domain.Entities
{
    public class Reception
    {
        public int IdRecepcion { get; set; }
        public int IdCliente { get; set; }   

        public int IdHabitacion { get; set; }   
        public DateTime FechaEntrada { get; set; }  
        public DateTime FechaSalidaConfirmacion { get; set; }   
        public double PrecioInicial { get; set; }   
        public double Adelanto { get; set; }    
        public double PrecioRestante { get; set; }  
        public double TotalPagado { get; set; } 
        public double CostoPenalidad { get; set; }  
        public string Observacion { get; set; }   
    }
}
