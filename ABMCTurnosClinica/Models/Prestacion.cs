using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCTurnosClinica.Models
{
    public class Prestacion
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }

    }
}