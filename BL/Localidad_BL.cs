using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DAL;

namespace BL
{
    public class Localidad_BL
    {
        Localidad_DAL localidad_DAL = new Localidad_DAL();

        public List<Localidad_E> ListadoLocalidad()
        {
            return localidad_DAL.ListadoLocalidad();
        }

    }
}
