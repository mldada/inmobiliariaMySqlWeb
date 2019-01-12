using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DAL;

namespace BL
{
    public class TipoPropiedad_BL
    {
        TipoPropiedad_DAL tipoPropiedad_DAL = new TipoPropiedad_DAL();

        public List<TipoPropiedad_E> VentaTipoPropiedad()
        {
            return tipoPropiedad_DAL.ListadoTipoPropiedad(Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Venta));
        }

        public List<TipoPropiedad_E> AlquilerTipoPropiedad()
        {
            return tipoPropiedad_DAL.ListadoTipoPropiedad(Convert.ToBoolean(TipoPropiedad_E.TipoOperacion.Alquiler));
        }

    }
}
