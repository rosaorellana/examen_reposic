using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class conex
    {
        private SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db_parque_vehicular_Orellana_Rosa.mdf;Integrated Security=True");
        private DataSet ds;

        public DataTable Mostrar_Datos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_vehiculos", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tbl_vehiculos");
            conexion.Close();
            return ds.Tables["tbl_vehiculos"];
        }
        public DataTable Buscar(string marca)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM tbl_vehiculos WHERE marca like '%{0}%'", marca), conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tbl_vehiculos");
            conexion.Close();
            return ds.Tables["tbl_vehiculos"];
        }

        public bool Insertar(string id, string marca, string modelo, string year)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO tbl_vehiculos VALUES ({0}, '{1}', '{2}', '{3}')", new string[] {id, marca, modelo, year}), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Eliminar(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM tbl_vehiculos WHERE idVehiculo = {0}", id), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }

        public bool Actualizar(string id, string marca, string modelo, string year)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("UPDATE tbl_vehiculos set marca = '{0}', modelo = '{1}' WHERE idVehiculo = {2}", new string[] {marca, modelo, id}), conexion);
            int filasafectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            if (filasafectadas > 0) return true;
            else return false;
        }
    }
}
