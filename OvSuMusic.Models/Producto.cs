using System;
using System.Collections.Generic;
using OvSuMusic.Models.Enumerations;

#nullable disable

namespace OvSuMusic.Models
{
    public class Producto
    {
        public Producto()
        {
            DetalleOrdens = new HashSet<DetalleOrden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public EstatusProducto Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; }
    }
}
