﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCTurnosClinica.Models
{
    public class DTOListadoTurnos
    {
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public int Edad { get; set; }
        public string Fecha { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        
    }
}