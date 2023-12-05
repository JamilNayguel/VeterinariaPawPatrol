using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Ajax.Utilities;
using VeterinariaPP.Models;
using System.Data.Entity;

namespace VeterinariaPP.Logica
{
    public class LogicaUsuario
    {
        public Usuario EncontrarUsuario(string Correo, string contra)
        {
            Usuario objeto = new Usuario();

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-V34R171\\SQLEXPRESS ; Initial Catalog=Veterinaria; Integrated Security=true"))
            {

                string query = "Select * from Usuario where Correo = @pCorreo and Contrasena = @pContrasena";

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@pCorreo", Correo);
                cmd.Parameters.AddWithValue("@pContrasena", contra);
                cmd.CommandType = CommandType.Text;

                conexion.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new Usuario()
                        {
                            IdUsuario = (int)dr["IdUsuario"],
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Celular = (int?)dr["Celular"],
                            Correo = dr["Correo"].ToString(),
                            Contrasena = dr["Contrasena"].ToString(),
                            IdPrivilegio = (int)dr["IdPrivilegio"],
                            IdEstadoUsuario = (int)dr["IdEstadoUsuario"],
                            IdVeterinaria = (int?)dr["IdVeterinaria"],

                        };
                    }

                }

            }
            return (objeto);
        }
        public Usuario EncontrarCuenta(int? Id)
        {
            Usuario objeto = new Usuario();

            using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-V34R171\\SQLEXPRESS ; Initial Catalog=Veterinaria; Integrated Security=true"))
            {

                string query = "Select * from Usuario where IdUsuario=" + Id;

                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.CommandType = CommandType.Text;

                conexion.Open();


                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objeto = new Usuario()
                        {
                            IdUsuario = (int)dr["IdUsuario"],
                            NombreUsuario = dr["NombreUsuario"].ToString(),
                            Celular = (int?)dr["Celular"],
                            Correo = dr["Correo"].ToString(),
                            Contrasena = dr["Contrasena"].ToString(),
                            IdPrivilegio = (int)dr["IdPrivilegio"],
                            IdEstadoUsuario = (int)dr["IdEstadoUsuario"],
                            IdVeterinaria = (int?)dr["IdVeterinaria"],
                        };
                    }

                }

            }
            return (objeto);
        }

    }
}