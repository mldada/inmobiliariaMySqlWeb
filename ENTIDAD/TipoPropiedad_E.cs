using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class TipoPropiedad_E
    {
        #region Atributos

        private int id_tipo_propiedad;
        private string dc_tipo_propiedad;
        private bool es_venta;

        #endregion

        #region Propiedades
        public int Id_Tipo_Propiedad
        {
            get { return id_tipo_propiedad; }
            set { id_tipo_propiedad = value; }
        }
        public string Dc_Tipo_Propiedad
        {
            get { return dc_tipo_propiedad; }
            set { dc_tipo_propiedad = value; }
        }
        public bool Es_Venta
        {
            get { return es_venta; }
            set { es_venta = value; }
        }

        #endregion

        #region Enumerables

        public enum TipoPropiedad
        {

            Departamento = 1,
            CasaDuplex = 2,
            TipoCasa = 3,
            LocalGalpon = 4,
            LoteTerreno = 5

        }
        public enum TipoOperacion
        {
            Venta = 1,
            Alquiler = 0
        }

        #endregion
    }
}
