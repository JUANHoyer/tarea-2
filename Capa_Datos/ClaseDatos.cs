using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;
using System.IO;


namespace Capa_Datos
{
    public class ClaseDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable listar_E()
        {
            SqlCommand cmd = new SqlCommand("listar_Datos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Buscar_E(ClaseEntidad obje) 
        {
            SqlCommand cmd = new SqlCommand("Buscar_Emple", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreC", obje.NombreC);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public string Mantenimiento_E(ClaseEntidad obje) 
        {
            string Accion = "";
            SqlCommand cmd = new SqlCommand("Mantenimiento_Emple", cn);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cc", obje.CC);
            cmd.Parameters.AddWithValue("@NombreC", obje.NombreC);
            cmd.Parameters.AddWithValue("@NuEmpresarial", obje.NuEmpresarial);
            cmd.Parameters.AddWithValue("@NuOficina", obje.NuOficina);
            cmd.Parameters.AddWithValue("@Cargo", obje.Cargo);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar,50).Value = obje.Accion;
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            cn.Close();
            return Accion;
        }
    }
}
