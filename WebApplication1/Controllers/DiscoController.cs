using MusicaLMFL.Comun;
using MusicaLMFL.Modelo;
using MusicaLMFL.Negocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicaLMFL.Controllers
{
    public class DiscoController : Controller
    {
        private ControlAccesoDAO<TDisco> control = new ControlAccesoDAO<TDisco>();

        public ActionResult Consultar()
        {
            List<TDisco> list = new List<TDisco>();

            foreach (var item in control.Obtener(new TDisco().GetType()))
            {
                list.Add((TDisco)item);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult CarroCompra()
        {
            List<TDisco> list = new List<TDisco>();

            foreach (var item in control.Obtener(new TDisco().GetType()))
            {
                list.Add((TDisco)item);
            }

            return View(list);
            
        }

        public PartialViewResult borrarDisco(string CodDisco)
        {
            control.BorradoVirtual((TDisco)control.Buscar(new TDisco().GetType(), CodDisco));            
            object[] modelos = new object[1];            
            modelos[0] = control.Obtener(new TDisco().GetType());            
            return PartialView("_BorrarDisco", modelos);           
        }

        public ActionResult verDisco(string CodDisco)
        {
            return PartialView("_verDisco", (TDisco)control.Buscar(new TDisco().GetType(), CodDisco));         
        }

        public ActionResult addDisco()
        {
            return View(control.Obtener(new TGenero().GetType()));
        }

        [HttpPost]
        public ActionResult addDisco(TDisco disco)
        {
            try
            {
                List<object> discos = new List<object>();
                disco.Precio = disco.Precio.Replace(".", ",");
                disco.CodDisco = Util.GenerarCodigo(disco.GetType());
                disco.Borrado = "0";
                disco.Formatouno = disco.Formatouno == null ? "N/A" : disco.Formatouno;
                disco.Formatodos = disco.Formatodos == null ? "N/A" : disco.Formatodos;
                disco.Formatotres = disco.Formatotres == null ? "N/A" : disco.Formatotres;
                discos.Add((TDisco)disco);
                if (control.Insertar(discos))
                {
                    return Json("Disco insertado correctamente");
                }

            }
            catch (Exception e)
            {
                return Json(Errores.ControlErrores(e));                
            }
            return RedirectToAction("Inicio");
        }

        public ActionResult modificarDisco(string codDisco)
        {
            object[] modelos = new object[2];
            modelos[0] = control.Buscar(new TDisco().GetType(), codDisco);
            modelos[1] = control.Obtener(new TGenero().GetType());
            return View(modelos);
        }

        [HttpPost]
        public ActionResult modificarDisco(TDisco disco)
        {            
            try
            {
                disco.Borrado = "0";
                disco.Formatouno = disco.Formatouno == null ? "N/A" : disco.Formatouno;
                disco.Formatodos = disco.Formatodos == null ? "N/A" : disco.Formatodos;
                disco.Formatotres = disco.Formatotres == null ? "N/A" : disco.Formatotres;
                control.Modificar(disco.CodDisco, disco);
                return RedirectToAction("Consultar");
            }
            catch (Exception e)
            {
                return Content(Mensaje.mostrarmensaje(Errores.ControlErrores(e), "modificarDisco"));
            }
        }

        [HttpPost]
        public ActionResult obtenerDiscos(string CodDisco)
        {
            object[] modelos = new object[1];            
            modelos[0] = control.Buscar(new TDisco().GetType(), CodDisco);
            return Json(modelos);
        }

        [HttpPost]
        public ActionResult comprar(List<TLinea> data)
        {
            TFactura factura = new TFactura("", ((TUsuario)Session["usuario"]).Nick, DateTime.Now.ToShortDateString());
            factura.CodFactura = Util.GenerarCodigo(factura.GetType());
            List<object> listaFacturaTemp = new List<object>();
            listaFacturaTemp.Add(factura);
            List<object> listaLineasFactura = new List<object>();

            foreach (TLinea linea in data)
            {
                TLineaFactura lineaTemp = new TLineaFactura(factura.CodFactura, linea.Disco, linea.Cantidad.ToString(), linea.Total.ToString());
                listaLineasFactura.Add(lineaTemp);
            }

            control.Insertar(listaLineasFactura);
            control.Insertar(listaFacturaTemp);
            return Json("Factura guardada correctamente");      
        }

    }
}
