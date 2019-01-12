using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace DAL
{
    public class Inmueble_DAL
    {
        #region Conexion

        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        MySqlCommand cmd  = new MySqlCommand();

        #endregion

        #region SP
        const string buscarInmuebleId = "Sp_Buscar_Inmueble_Id";
        const string buscarInmuebles = "Sp_Buscar_Inmuebles";
        const string actualizarInmuebleId = "Sp_Actualizar_Inmueble_Id";
        const string agregarInmueble = "Sp_Agregar_Inmueble";
        const string eliminarInmuebleId = "Sp_Eliminar_Inmueble_Id";
        #endregion

        #region Metodos
        public Inmueble_E BuscarInmuebleId(int idInmueble)
        {
            Inmueble_E inmueble = new Inmueble_E();
            try
            {
                cn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(buscarInmuebleId, cn);
                cmd = mySqlCommand;
                cmd.CommandType = CommandType.StoredProcedure;               
       
                MySqlParameter param_id_inmueble = new MySqlParameter
                {
                    ParameterName = "p_id_inmueble",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = idInmueble
                };
               
                cmd.Parameters.Add(param_id_inmueble);

                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    inmueble.Id_Inmueble = Convert.ToInt32(dr["id_inmueble"]);
                    inmueble.tipoPropiedad_E.Id_Tipo_Propiedad = Convert.ToInt32(dr["id_tipo_propiedad"]);
                    inmueble.Es_Venta = Convert.ToBoolean(dr["es_venta"]);
                    inmueble.Importe = Convert.ToInt32(dr["importe"]);
                    inmueble.Superficie = Convert.ToInt32(dr["superficie"]);
                    inmueble.Calle = dr["calle"].ToString();
                    inmueble.Altura = Convert.ToInt32(dr["altura"]);
                    inmueble.localidad_E.Id_Localidad = Convert.ToInt32(dr["id_localidad"]);
                    inmueble.Descripcion = dr["descripcion"].ToString();
                    inmueble.estado_E.Id_Estado = Convert.ToInt32(dr["id_estado"]);
                    inmueble.Cant_Ambientes = Convert.ToInt32(dr["cant_ambientes"]);
                    inmueble.Piso = dr["piso"].ToString();
                    inmueble.Depto = dr["depto"].ToString();
                    inmueble.Apto_Credito = Convert.ToBoolean(dr["apto_credito"]);
                }
            }
            catch (Exception e)
            {
                throw ;
            }
            return inmueble;
        }
        public List<Inmueble_E> BuscarInmuebles(int idTipoPropiedad, bool esVenta)
        {
            List<Inmueble_E> listado = new List<Inmueble_E>();
            try
            {
                cn.Open();
                cmd = new MySqlCommand(buscarInmuebles, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };              

                MySqlParameter param_id_tipo_propiedad = new MySqlParameter
                {
                    ParameterName = "p_id_tipo_propiedad",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = idTipoPropiedad
                };

                MySqlParameter param_es_venta = new MySqlParameter
                {
                    ParameterName = "p_es_venta",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = esVenta
                };

                cmd.Parameters.Add(param_id_tipo_propiedad);
                cmd.Parameters.Add(param_es_venta);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Inmueble_E inmueble = new Inmueble_E
                    {
                        Id_Inmueble = Convert.ToInt32(dr["id_inmueble"]),
                        Id_Tipo_Propiedad = Convert.ToInt32(dr["id_tipo_propiedad"])
                    };
                    inmueble.tipoPropiedad_E.Dc_Tipo_Propiedad = dr["dc_tipo_propiedad"].ToString();
                    inmueble.Es_Venta = Convert.ToBoolean(dr["es_venta"]);
                    inmueble.Importe = Convert.ToInt32(dr["importe"]);
                    inmueble.Superficie = Convert.ToInt32(dr["superficie"]);
                    inmueble.Calle = dr["calle"].ToString();
                    inmueble.Altura = Convert.ToInt32(dr["altura"]);
                    inmueble.Id_Localidad = Convert.ToInt32(dr["id_localidad"]);
                    inmueble.localidad_E.Dc_Localidad = dr["dc_localidad"].ToString();
                    inmueble.Descripcion = dr["descripcion"].ToString();
                    inmueble.Id_Estado = Convert.ToInt32(dr["id_estado"]);
                    inmueble.estado_E.Dc_Estado = dr["dc_estado"].ToString();
                    inmueble.Cant_Ambientes = Convert.ToInt32(dr["cant_ambientes"]);
                    inmueble.Piso = dr["piso"].ToString();
                    inmueble.Depto = dr["depto"].ToString();
                    inmueble.Apto_Credito = Convert.ToBoolean(dr["apto_credito"]);
                    listado.Add(inmueble);
                }
            }
            catch (Exception e)
            {
               throw;
            }
           
            return listado;
        }
        public bool ActualizarInmueble(Inmueble_E inmueble)
        {
            bool resultado = false;

            try
            {
                cn.Open();
                cmd = new MySqlCommand(actualizarInmuebleId, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                MySqlParameter param_id_inmueble = new MySqlParameter
                {
                    ParameterName = "p_id_inmueble",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Id_Inmueble
                };

                MySqlParameter param_id_tipo_propiedad = new MySqlParameter
                {
                    ParameterName = "p_id_tipo_propiedad",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.tipoPropiedad_E.Id_Tipo_Propiedad
                };

                MySqlParameter param_es_venta = new MySqlParameter
                {
                    ParameterName = "p_es_venta",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = inmueble.Es_Venta
                };

                MySqlParameter param_importe = new MySqlParameter
                {
                    ParameterName = "p_importe",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Importe
                };

                MySqlParameter param_superficie = new MySqlParameter
                {
                    ParameterName = "p_superficie",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Superficie
                };

                MySqlParameter param_calle = new MySqlParameter
                {
                    ParameterName = "p_calle",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 50,
                    Value = inmueble.Calle
                };

                MySqlParameter param_altura = new MySqlParameter
                {
                    ParameterName = "p_altura",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Altura
                };

                MySqlParameter param_id_localidad = new MySqlParameter
                {
                    ParameterName = "p_id_localidad",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.localidad_E.Id_Localidad
                };

                MySqlParameter param_descripcion = new MySqlParameter
                {
                    ParameterName = "p_descripcion",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 1000,
                    Value = inmueble.Descripcion
                };

                MySqlParameter param_id_estado = new MySqlParameter
                {
                    ParameterName = "p_id_estado",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.estado_E.Id_Estado
                };

                MySqlParameter param_cant_ambientes = new MySqlParameter
                {
                    ParameterName = "p_cant_ambientes",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Cant_Ambientes
                };

                MySqlParameter param_piso = new MySqlParameter
                {
                    ParameterName = "p_piso",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 2,
                    Value = inmueble.Piso
                };

                MySqlParameter param_depto = new MySqlParameter
                {
                    ParameterName = "p_depto",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 5,
                    Value = inmueble.Depto
                };

                MySqlParameter param_apto_credito = new MySqlParameter
                {
                    ParameterName = "p_apto_credito",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = inmueble.Apto_Credito
                };

                cmd.Parameters.Add(param_id_inmueble);
                cmd.Parameters.Add(param_id_tipo_propiedad);
                cmd.Parameters.Add(param_es_venta);
                cmd.Parameters.Add(param_importe);
                cmd.Parameters.Add(param_superficie);
                cmd.Parameters.Add(param_calle);
                cmd.Parameters.Add(param_altura);
                cmd.Parameters.Add(param_id_localidad);
                cmd.Parameters.Add(param_descripcion);
                cmd.Parameters.Add(param_id_estado);
                cmd.Parameters.Add(param_cant_ambientes);
                cmd.Parameters.Add(param_piso);
                cmd.Parameters.Add(param_depto);
                cmd.Parameters.Add(param_apto_credito);

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e)
            {

                throw;
            }
            return resultado;
        }
        public bool AgregarInmueble(Inmueble_E inmueble)
        {
            bool resultado = false;

            try
            {
                cn.Open();
                cmd = new MySqlCommand(agregarInmueble, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };             

                MySqlParameter param_id_tipo_propiedad = new MySqlParameter
                {
                    ParameterName = "p_id_tipo_propiedad",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.tipoPropiedad_E.Id_Tipo_Propiedad
                };

                MySqlParameter param_es_venta = new MySqlParameter
                {
                    ParameterName = "p_es_venta",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = inmueble.Es_Venta
                };

                MySqlParameter param_importe = new MySqlParameter
                {
                    ParameterName = "p_importe",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Importe
                };

                MySqlParameter param_superficie = new MySqlParameter
                {
                    ParameterName = "p_superficie",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Superficie
                };

                MySqlParameter param_calle = new MySqlParameter
                {
                    ParameterName = "p_calle",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 50,
                    Value = inmueble.Calle
                };

                MySqlParameter param_altura = new MySqlParameter
                {
                    ParameterName = "p_altura",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Altura
                };

                MySqlParameter param_id_localidad = new MySqlParameter
                {
                    ParameterName = "p_id_localidad",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.localidad_E.Id_Localidad
                };

                MySqlParameter param_descripcion = new MySqlParameter
                {
                    ParameterName = "p_descripcion",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 1000,
                    Value = inmueble.Descripcion
                };

                MySqlParameter param_id_estado = new MySqlParameter
                {
                    ParameterName = "p_id_estado",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.estado_E.Id_Estado
                };

                MySqlParameter param_cant_ambientes = new MySqlParameter
                {
                    ParameterName = "p_cant_ambientes",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = inmueble.Cant_Ambientes
                };

                MySqlParameter param_piso = new MySqlParameter
                {
                    ParameterName = "p_piso",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 2,
                    Value = inmueble.Piso
                };

                MySqlParameter param_depto = new MySqlParameter
                {
                    ParameterName = "p_depto",
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 5,
                    Value = inmueble.Depto
                };

                MySqlParameter param_apto_credito = new MySqlParameter
                {
                    ParameterName = "p_apto_credito",
                    MySqlDbType = MySqlDbType.Bit,
                    Value = inmueble.Apto_Credito
                };

                cmd.Parameters.Add(param_id_tipo_propiedad);
                cmd.Parameters.Add(param_es_venta);
                cmd.Parameters.Add(param_importe);
                cmd.Parameters.Add(param_superficie);
                cmd.Parameters.Add(param_calle);
                cmd.Parameters.Add(param_altura);
                cmd.Parameters.Add(param_id_localidad);
                cmd.Parameters.Add(param_descripcion);
                cmd.Parameters.Add(param_id_estado);
                cmd.Parameters.Add(param_cant_ambientes);
                cmd.Parameters.Add(param_piso);
                cmd.Parameters.Add(param_depto);
                cmd.Parameters.Add(param_apto_credito);

                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception e)
            {

                throw;
            }
            return resultado;
        }
        public bool EliminarInmueble (int idInmueble)
        {
            bool eliminado = false;

            try
            {
                cn.Open();
                cmd = new MySqlCommand(eliminarInmuebleId, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                MySqlParameter param_id_inmueble = new MySqlParameter
                {
                    ParameterName = "p_id_inmueble",
                    MySqlDbType = MySqlDbType.Int32,
                    Value = idInmueble
                };

                cmd.Parameters.Add(param_id_inmueble);

                cmd.ExecuteNonQuery();
                eliminado = true;
            }
            catch (Exception e)
            {

                throw;
            }

            return eliminado;
        }
        #endregion
    }
}
