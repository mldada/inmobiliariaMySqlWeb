using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class Inmueble_E
    {
        #region Atributos

        private int id_inmueble;
        private int id_tipo_propiedad;
        private bool es_venta;
        private int importe;
        private int superficie;
        private string calle;
        private int altura;
        private int id_localidad;
        private string descripcion;
        private int id_estado;
        private int cant_ambientes;
        private string piso;
        private string depto;
        private bool apto_credito;

        #endregion

        #region Propiedades

        public int Id_Inmueble
        {
            get { return id_inmueble; }
            set { id_inmueble = value; }
        }
        public int Id_Tipo_Propiedad
        {
            get { return id_tipo_propiedad; }
            set { id_tipo_propiedad = value; }
        }
        public bool Es_Venta
        {
            get { return es_venta; }
            set { es_venta = value; }
        }
        public int Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        public int Superficie
        {
            get { return superficie; }
            set { superficie = value; }
        }
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        public int Altura
        {
            get { return altura; }
            set { altura = value; }
        }
        public int Id_Localidad
        {
            get { return id_localidad; }
            set { id_localidad = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int Id_Estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }
        public int Cant_Ambientes
        {
            get { return cant_ambientes; }
            set { cant_ambientes = value; }
        }
        public string Piso
        {
            get { return piso; }
            set { piso = value; }
        }
        public string Depto
        {
            get { return depto; }
            set { depto = value; }
        }
        public bool Apto_Credito
        {
            get { return apto_credito; }
            set { apto_credito = value; }
        }

        public Estado_E estado_E = new Estado_E();
        public Localidad_E localidad_E = new Localidad_E();
        public TipoPropiedad_E tipoPropiedad_E = new TipoPropiedad_E();

        #endregion

    }
}
