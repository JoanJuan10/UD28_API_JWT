using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX3.Models
{
    public partial class Productos
    {
        public Productos()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Precio { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}
