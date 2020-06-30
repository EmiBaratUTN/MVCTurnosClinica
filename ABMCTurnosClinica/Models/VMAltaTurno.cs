using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCTurnosClinica.Models
{
    public class VMAltaTurno
    {
        public List<Prestacion> Prestacions { get; set; }
        public  Turno turno { get; set; }
    }
}