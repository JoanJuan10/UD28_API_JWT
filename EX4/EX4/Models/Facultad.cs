using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX4.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Equipos = new HashSet<Equipos>();
            Investigadores = new HashSet<Investigadores>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<Investigadores> Investigadores { get; set; }
    }
}
