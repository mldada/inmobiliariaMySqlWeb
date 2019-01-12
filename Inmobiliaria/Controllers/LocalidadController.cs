using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BL;
using ENTIDAD;

namespace Inmobiliaria.Controllers
{
    public class LocalidadController : Controller
    {
        // GET: Localidad
        Localidad_BL localidad_BL = new Localidad_BL();

        public ActionResult ListadoLocalidad()
        {
            return View(localidad_BL.ListadoLocalidad());
        }

        

    }
}