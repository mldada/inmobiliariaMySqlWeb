using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DAL;

namespace BL
{
    public class Inmueble_BL
    {
        Inmueble_DAL inmueble_DAL = new Inmueble_DAL();

        #region Metodos
        public Inmueble_E BuscarInmuebleId(int idInmueble)
        {
            return inmueble_DAL.BuscarInmuebleId(idInmueble);
        }
        public List<Inmueble_E> BuscarInmuebles(int idTipoPropiedad, bool esVenta)
        {
            return inmueble_DAL.BuscarInmuebles(idTipoPropiedad, esVenta);
        }
        public bool ActualizarInmueble(Inmueble_E inmueble)
        {
            return inmueble_DAL.ActualizarInmueble(inmueble);
        }
        public bool AgregarInmueble(Inmueble_E inmueble)
        {
            return inmueble_DAL.AgregarInmueble(inmueble);
        }
        public bool EliminarInmueble(int idInmueble)
        {
            return inmueble_DAL.EliminarInmueble(idInmueble);
        }
        #endregion
    }
}
