using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX4.Models
{
    public partial class Reserva
    {
        public string Dni { get; set; }
        public string NumSerie { get; set; }
        public DateTime? Comienzo { get; set; }
        public DateTime? Fin { get; set; }

        public virtual Investigadores DniNavigation { get; set; }
        public virtual Equipos NumSerieNavigation { get; set; }
    }
}
