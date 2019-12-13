using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class PerfilDAO
    {
        #region "PATRON SINGLETON"
        private static PerfilDAO objPerfil= null;
        private PerfilDAO() { }
        public static PerfilDAO getInstance()
        {
            if (objPerfil == null)
            {
                objPerfil = new PerfilDAO();
            }
            return objPerfil;
        }
        #endregion
        public DataSet ListarPerfil()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            string sql = "SELECT * FROM Perfil";
            try
            {
                con = Conexion.getInstance().ConexionBD();
                con.Open();
                cmd = new SqlCommand(sql, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
    }
}
