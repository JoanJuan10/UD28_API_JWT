using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX4.Models
{
    public partial class Investigadores
    {
        public Investigadores()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string Dni { get; set; }
        public string NomApels { get; set; }
        public int? Facultad { get; set; }

        public virtual Facultad FacultadNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
