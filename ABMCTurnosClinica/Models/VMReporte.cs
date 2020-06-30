using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABMCTurnosClinica.Models
{
    public class VMReporte
    {
        public List<DTOListadoTurnos> listaReporte { get; set; }
        public List<DTOCantPorPrestacion> cantPorPrestacion { get; set; }
        public double MontoPacientes18a40
        {
            get
            {
                double monto = 0;
                foreach (var item in listaReporte)
                {
                    if (item.Edad >= 18 && item.Edad <= 40)
                    {
                        monto += item.Monto;
                    }
                }
                return monto;
            }
        }
    }
}