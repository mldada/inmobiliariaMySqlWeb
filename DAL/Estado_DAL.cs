﻿using System;
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
    public class Estado_DAL
    {
        MySqlConnection cn = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        MySqlCommand cmd = new MySqlCommand();

        const string listar = "View_Listar_Estados";

        public List<Estado_E> ListadoEstado()
        {
            List<Estado_E> listado = new List<Estado_E>();

            try
            {
                cn.Open();
                cmd = new MySqlCommand(listar, cn)
                {
                    CommandType = CommandType.TableDirect
                };
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Estado_E estado = new Estado_E
                    {
                        Id_Estado = Convert.ToInt32(dr["id_estado"]),
                        Dc_Estado = dr["dc_estado"].ToString()
                    };
                    listado.Add(estado);
                }
            }
            catch (Exception e)
            {
                
                throw;
            }
            return listado;
        }
    }
}
