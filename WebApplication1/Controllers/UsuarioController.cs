using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MusicaLMFL.Negocio;
using MusicaLMFL.Modelo;

namespace MusicaLMFL.Controllers
{
    public class UsuarioController : Controller
    {
        ControlAccesoDAO<TUsuario> control = new ControlAccesoDAO<TUsuario>();

        public ActionResult verFacturas()
        {
            return View(control.Buscar(new TFactura().GetType(), "Cliente", (Session["usuario"] as TUsuario).Nick));
        }

        public ActionResult detalleFactura(string CodFactura)
        {

            List<LineaAuxiliar> listaVentas = new List<LineaAuxiliar>();

            foreach (TLineaFactura lineaFactura in control.Buscar(new TLineaFactura().GetType(), "CodFactura", CodFactura))
            {
                listaVentas.Add(new LineaAuxiliar(lineaFactura.CodFactura, (control.Buscar(new TTeclado().GetType(), lineaFactura.Teclado) as TTeclado), lineaFactura.Cantidad, lineaFactura.Total));
            }

            return View(listaVentas);
        }

    }
}