using ABMCTurnosClinica.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABMCTurnosClinica.Models;

namespace ABMCTurnosClinica.Controllers
{
    public class TurneroController : Controller
    {
        // GET: Turnero
        public ActionResult AltaTurno()
        {
            Gestor gestor = new Gestor();
            VMAltaTurno vm = new VMAltaTurno();
            vm.Prestacions = gestor.listarPrestaciones();
            return View(vm);
        }

        [HttpPost]
        public ActionResult AltaTurno(Turno turno)
        {
            Gestor gestor = new Gestor();
            gestor.InsertarTurno(turno);
            VMAltaTurno vm = new VMAltaTurno();
            vm.Prestacions = gestor.listarPrestaciones();            
            return View(vm);
        }

        public ActionResult ListadoTurnos()
        {
            Gestor gestor = new Gestor();
            List<DTOListadoTurnos> dt = gestor.listarTurnos();
            return View(dt);
        }

        public ActionResult Reportes()
        {
            Gestor gestor = new Gestor();
            VMReporte vm = new VMReporte();
            vm.listaReporte = gestor.listarTurnos();
            vm.cantPorPrestacion = gestor.cantPorPrestacion();
            return View(vm);
        }
    }
}