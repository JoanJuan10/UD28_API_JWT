using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX4.Models
{
    public partial class Equipos
    {
        public Equipos()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int? Facultad { get; set; }

        public virtual Facultad FacultadNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
