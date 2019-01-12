using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD 
{
    public class Estado_E
    {
        #region Atributos

        private int id_estado;
        private string dc_estado;

        #endregion

        #region Propiedades

        public int Id_Estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }
        public string Dc_Estado
        {
            get { return dc_estado; }
            set { dc_estado = value; }
        }
        
        #endregion

        #region Enumerables

        public enum Estado
        {

            Publicado = 1,
            Reservado = 2,
            Eliminar = 3,
            
        }
        
        #endregion
    }
}
