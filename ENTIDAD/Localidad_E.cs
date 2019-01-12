using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Localidad_E
    {
        #region Atributos

        private int id_localidad;
        private string dc_localidad;
        private bool es_activa;

        #endregion

        #region Propiedades

        public int Id_Localidad
        {
            get { return id_localidad; }
            set { id_localidad = value; }
        }
        public string Dc_Localidad
        {
            get { return dc_localidad; }
            set { dc_localidad = value; }
        }
        public bool Es_Activa
        {
            get { return es_activa; }
            set { es_activa = value; }
        }

        #endregion
    }
}
