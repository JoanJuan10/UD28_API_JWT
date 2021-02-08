using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX3.Models
{
    public partial class Cajeros
    {
        public Cajeros()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
