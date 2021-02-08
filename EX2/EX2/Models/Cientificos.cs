using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX2.Models
{
    public partial class Cientificos
    {
        public Cientificos()
        {
            AsignadoA = new HashSet<AsignadoA>();
        }

        public string Dni { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<AsignadoA> AsignadoA { get; set; }
    }
}
