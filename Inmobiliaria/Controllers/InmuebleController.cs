using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BL;
using ENTIDAD;

namespace Inmobiliaria.Controllers
{
    public class InmuebleController : Controller
    {
        // GET: Inmueble
        
        Inmueble_BL inmueble_BL = new Inmueble_BL();

        public ActionResult Inicio()
        {
            return View();
        }

        #region Listado de Ventas
        public ActionResult VentaDepartamento()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.Departamento),Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta)));
        }
        public ActionResult VentaCasaDuplex()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.CasaDuplex), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta)));
        }
        public ActionResult VentaTipoCasa()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.TipoCasa), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta)));
        }
        public ActionResult VentaLocalGalpon()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.LocalGalpon), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta)));
        }
        public ActionResult VentaLoteTerreno()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.LoteTerreno), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta)));
        }
        #endregion

        #region Listado de Alquileres
        public ActionResult AlquilerDepartamento()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.Departamento), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Alquiler)));
        }
        public ActionResult AlquilerCasaDuplex()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.CasaDuplex), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Alquiler)));
        }
        public ActionResult AlquilerTipoCasa()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.TipoCasa), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Alquiler)));
        }
        public ActionResult AlquilerLocalGalpon()
        {
            return View(inmueble_BL.BuscarInmuebles(Convert.ToInt32(TipoPropiedad_E.TipoPropiedad.LocalGalpon), Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Alquiler)));
        }
        #endregion

        #region Metodos
        public ActionResult AgregarVenta()
        {
            cboVentaTipoPropiedad();
            cboLocalidades();
            return View();
        }
        public ActionResult AgregarAlquiler()
        {
            cboAlquilerTipoPropiedad();
            cboLocalidades();
            return View();
        }
        public ActionResult InsertarInmueble(int cboTipoPropiedad, bool esVenta, int importe, int superficie, string calle, int altura, int cboLocalidad, string descripcion, int estado, int cantAmbientes, string piso, string depto, bool? aptoCredito)
        {
            Inmueble_E inmueble = new Inmueble_E();
            inmueble.tipoPropiedad_E.Id_Tipo_Propiedad = cboTipoPropiedad;
            inmueble.Es_Venta = esVenta;                    
            inmueble.Importe = importe;
            inmueble.Superficie = superficie;
            inmueble.Calle = calle;
            inmueble.Altura = altura;
            inmueble.localidad_E.Id_Localidad = cboLocalidad;
            inmueble.Descripcion = descripcion;
            inmueble.estado_E.Id_Estado = estado;
            inmueble.Cant_Ambientes = cantAmbientes;
            inmueble.Piso = piso;
            inmueble.Depto = depto;
            if (aptoCredito == true)
            {
                inmueble.Apto_Credito = true;
            }
            else
            {
                inmueble.Apto_Credito = false;
            }
            string mensaje = "";
            if (inmueble_BL.AgregarInmueble(inmueble) == true)
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Inmueble Agregado'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Error'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }

            return Content(mensaje);
        }
        public ActionResult EditarVenta( int idInmueble)
        {
            cboVentaTipoPropiedad();
            cboLocalidades();
            cboEstados();
            return View(inmueble_BL.BuscarInmuebleId(idInmueble));
        }
        public ActionResult EditarAlquiler(int idInmueble)
        {
            cboVentaTipoPropiedad();
            cboLocalidades();
            cboEstados();
            return View(inmueble_BL.BuscarInmuebleId(idInmueble));
        }
        public ActionResult ActualizarInmueble(int idInmueble, int cboTipoPropiedad, bool? esVenta, int importe, int superficie, string calle, int altura, int cboLocalidad, string descripcion, int cboEstado, int cantAmbientes, string piso, string depto, bool? aptoCredito)
        {
            Inmueble_E inmueble = new Inmueble_E();
            inmueble.Id_Inmueble = idInmueble;
            inmueble.tipoPropiedad_E.Id_Tipo_Propiedad = cboTipoPropiedad;
            inmueble.Es_Venta = Convert.ToBoolean(esVenta);
            inmueble.Importe = importe;
            inmueble.Superficie = superficie;
            inmueble.Calle = calle;
            inmueble.Altura = altura;
            inmueble.localidad_E.Id_Localidad = cboLocalidad;
            inmueble.Descripcion = descripcion;
            inmueble.estado_E.Id_Estado = cboEstado;
            inmueble.Cant_Ambientes = cantAmbientes;
            inmueble.Piso = piso;
            inmueble.Depto = depto;
            if (aptoCredito == true)
            {
                inmueble.Apto_Credito = true;
            }
            else
            {
                inmueble.Apto_Credito = false;
            }

            string mensaje = "";
            if (inmueble_BL.ActualizarInmueble(inmueble) == true)
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Inmueble Actualizado'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Error'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }

            return Content(mensaje);
        }
        public ActionResult EliminarInmueble(int idInmueble)
        {
            string mensaje = "";

            if (inmueble_BL.EliminarInmueble(idInmueble))
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Inmueble Eliminado'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }
            else
            {
                mensaje = "<script language = 'javascript' type='text/javascript'>" +
                          "alert('Error'); window.location.href=" +
                          "'/Inmueble/Inicio';</script>";
            }

            return Content(mensaje);
        }
        #endregion

        #region Combos
        public void cboVentaTipoPropiedad()
        {
            List<TipoPropiedad_E> lstTiposPropiedades = new List<TipoPropiedad_E>();
            TipoPropiedad_BL tipoPropiedadBL = new TipoPropiedad_BL();
            lstTiposPropiedades = tipoPropiedadBL.VentaTipoPropiedad();
            ViewBag.ListadoTiposPropiedades = lstTiposPropiedades;
        }
        public void cboAlquilerTipoPropiedad()
        {
            List<TipoPropiedad_E> lstTiposPropiedades = new List<TipoPropiedad_E>();
            TipoPropiedad_BL tipoPropiedadBL = new TipoPropiedad_BL();
            lstTiposPropiedades = tipoPropiedadBL.AlquilerTipoPropiedad();
            ViewBag.ListadoTiposPropiedades = lstTiposPropiedades;
        }
        public void cboLocalidades()
        {
            List<Localidad_E> lstLocalidades = new List<Localidad_E>();
            Localidad_BL localidadBL = new Localidad_BL();
            lstLocalidades = localidadBL.ListadoLocalidad();
            ViewBag.ListadoLocalidades = lstLocalidades;
        }
        public void cboEstados()
        {
            List<Estado_E> lstEstados = new List<Estado_E>();
            Estado_BL estadoBL = new Estado_BL();
            lstEstados = estadoBL.ListadoEstado();
            ViewBag.ListadoEstados = lstEstados;
        }
        #endregion
    }
}