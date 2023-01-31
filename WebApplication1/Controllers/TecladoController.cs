using MusicaLMFL.Comun;
using MusicaLMFL.Modelo;
using MusicaLMFL.Negocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicaLMFL.Controllers
{
    public class TecladoController : Controller
    {
        private ControlAccesoDAO<TTeclado> control = new ControlAccesoDAO<TTeclado>();

        public ActionResult Consultar()
        {
            List<TTeclado> list = new List<TTeclado>();

            foreach (var item in control.Obtener(new TTeclado().GetType()))
            {
                list.Add((TTeclado)item);
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult CarroCompra()
        {
            List<TTeclado> list = new List<TTeclado>();

            foreach (var item in control.Obtener(new TTeclado().GetType()))
            {
                list.Add((TTeclado)item);
            }

            return View(list);
            
        }

        public PartialViewResult borrarTeclado(string CodTeclado)
        {
            control.BorradoVirtual((TTeclado)control.Buscar(new TTeclado().GetType(), CodTeclado));            
            object[] modelos = new object[1];            
            modelos[0] = control.Obtener(new TTeclado().GetType());            
            return PartialView("_BorrarTeclado", modelos);           
        }

        public ActionResult verTeclado(string CodTeclado)
        {
            return PartialView("_verTeclado", (TTeclado)control.Buscar(new TTeclado().GetType(), CodTeclado));         
        }

        public ActionResult addTeclado()
        {
            return View(control.Obtener(new TSwitch().GetType()));
        }

        [HttpPost]
        public ActionResult addTeclado(TTeclado teclado)//Revisar
        {
            try
            {
                List<object> teclados = new List<object>();
                teclado.Precio = teclado.Precio.Replace(".", ",");
                teclado.CodTeclado = Util.GenerarCodigo(teclado.GetType());
                teclado.Borrado = "0";

                teclado.Hotswap = teclado.Hotswap == null ? "N/A" : teclado.Hotswap;
                teclado.Qmk = teclado.Qmk == null ? "N/A" : teclado.Qmk;
                teclado.Via = teclado.Via == null ? "N/A" : teclado.Via;
                teclado.Rgb = teclado.Rgb == null ? "N/A" : teclado.Rgb;

                teclados.Add((TTeclado)teclado);
                if (control.Insertar(teclados))
                {
                    return Json("Teclado insertado correctamente");
                }

            }
            catch (Exception e)
            {
                return Json(Errores.ControlErrores(e));                
            }
            return RedirectToAction("Inicio");
        }

        public ActionResult modificarTeclado(string CodTeclado)
        {
            object[] modelos = new object[2];
            modelos[0] = control.Buscar(new TTeclado().GetType(), CodTeclado);
            modelos[1] = control.Obtener(new TSwitch().GetType());
            return View(modelos);
        }

        [HttpPost]
        public ActionResult modificarTeclado(TTeclado teclado)//Revisar
        {            
            try
            {
                teclado.Borrado = "0";
                teclado.Hotswap = teclado.Hotswap == null ? "N/A" : teclado.Hotswap;
                teclado.Qmk = teclado.Qmk == null ? "N/A" : teclado.Qmk;
                teclado.Via = teclado.Via == null ? "N/A" : teclado.Via;
                teclado.Rgb = teclado.Rgb == null ? "N/A" : teclado.Rgb;

                control.Modificar(teclado.CodTeclado, teclado);
                return RedirectToAction("Consultar");
            }
            catch (Exception e)
            {
                return Content(Mensaje.mostrarmensaje(Errores.ControlErrores(e), "modificarTeclado"));
            }
        }

        [HttpPost]
        public ActionResult obtenerTeclados(string CodTeclado)
        {
            object[] modelos = new object[1];            
            modelos[0] = control.Buscar(new TTeclado().GetType(), CodTeclado);
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
                TLineaFactura lineaTemp = new TLineaFactura(factura.CodFactura, linea., linea.Cantidad.ToString(), linea.Total.ToString());//Revisar
                listaLineasFactura.Add(lineaTemp);
            }

            control.Insertar(listaLineasFactura);
            control.Insertar(listaFacturaTemp);
            return Json("Factura guardada correctamente");      
        }

    }
}
