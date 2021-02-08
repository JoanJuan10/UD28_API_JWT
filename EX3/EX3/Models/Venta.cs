using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX3.Models
{
    public partial class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public virtual Cajeros CajeroNavigation { get; set; }
        public virtual MaquinasRegistradas MaquinaNavigation { get; set; }
        public virtual Productos ProductoNavigation { get; set; }
    }
}
