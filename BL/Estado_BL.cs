using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DAL;

namespace BL
{
    public class Estado_BL
    {
        Estado_DAL Estado_DAL = new Estado_DAL();

        public List<Estado_E> ListadoEstado()
        {
            return Estado_DAL.ListadoEstado();
        }
    }
}
