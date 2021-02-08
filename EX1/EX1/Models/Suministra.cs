using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX1.Models
{
    public partial class Suministra
    {
        public int CodigoPieza { get; set; }
        public string IdProveedor { get; set; }
        public int Precio { get; set; }

        public virtual Piezas CodigoPiezaNavigation { get; set; }
        public virtual Proveedores IdProveedorNavigation { get; set; }
    }
}
