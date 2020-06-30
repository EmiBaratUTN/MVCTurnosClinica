using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ABMCTurnosClinica.Models;

namespace ABMCTurnosClinica.AccesoDatos
{
    public class Gestor
    {
        public List<Prestacion> listarPrestaciones()
        {
            var sql = "select * from prestaciones";
            List<Prestacion> lista = new List<Prestacion>();

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conexion.Open();

            SqlCommand cmd = new SqlCommand(sql, conexion);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Prestacion p = new Prestacion();
                p.Id = (int)dr["id"];
                p.Descripcion = (string)dr["descripcion"];
                p.Monto = (double)dr["monto"];

                lista.Add(p);

            }

            dr.Close();
            conexion.Close();
            return lista;

        }

        internal List<DTOListadoTurnos> listarTurnos()
        {
            var lista = new List<DTOListadoTurnos>();

            var sql = @"select t.id, t.nombrePaciente, t.edad, t.fecha,p.descripcion, p.monto 
	                        from turno t
	                        inner join Prestaciones p on p.id = t.idPrestacion";

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOListadoTurnos turnos = new DTOListadoTurnos();

                turnos.Id = (int)dr["id"];
                turnos.NombrePaciente= (string)dr["nombrePaciente"];
                turnos.Edad = (int)dr["edad"];
                turnos.Fecha= (string)dr["fecha"];
                turnos.Descripcion = (string)dr["descripcion"];
                turnos.Monto = (double)dr["monto"];
                


                lista.Add(turnos);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        internal void InsertarTurno(Turno turno)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            try
            {
                var sql = @"insert into turno values (@nombre, @edad, @fecha, @idPrestacion)";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@nombre", turno.NombrePaciente);
                cmd.Parameters.AddWithValue("@edad", turno.Edad);
                cmd.Parameters.AddWithValue("@fecha", turno.Fecha);
                cmd.Parameters.AddWithValue("@idPrestacion", turno.IdPrestacion);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {

            }
            finally
            {
                conexion.Close();
            }


        }

        internal List<DTOCantPorPrestacion> cantPorPrestacion()
        {
            var lista = new List<DTOCantPorPrestacion>();

            var sql = @"select p.id, p.descripcion, count(*) as cantidad
	                        from turno t
	                        inner join Prestaciones p on p.id = t.idPrestacion
	                        where t.fecha like '%2020'
	                        group by p.id, p.descripcion";

            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOCantPorPrestacion cant = new DTOCantPorPrestacion();

                cant.Id = (int)dr["id"];
                cant.Descripcion = (string)dr["descripcion"];
                cant.Cantidad = (int)dr["cantidad"];
                



                lista.Add(cant);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }


    }
}