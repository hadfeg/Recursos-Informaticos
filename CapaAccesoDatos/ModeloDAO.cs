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
    public class ModeloDAO
    {
        #region "PATRON SINGLETON"
        private static ModeloDAO daoModelo = null;
        private ModeloDAO() { }
        public static ModeloDAO getInstance()
        {
            if (daoModelo == null)
            {
                daoModelo = new ModeloDAO();
            }
            return daoModelo;
        }
        #endregion
        public bool RegistrarModelo(Modelo objModelo)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarModelo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombreModelo", objModelo.NombreModelo);
                cmd.Parameters.AddWithValue("@prmMarcaId", objModelo.MarcaId);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public DataSet ListarModelos(int idMarca)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            
            string sql = "SELECT * FROM Modelo WHERE IdMarca = @prmIdMarca";            
            try
            {   
                con = Conexion.getInstance().ConexionBD();
                con.Open();
                cmd = new SqlCommand(sql, con);                
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                //Parametro 'prmIdMarca' de la consulta declarada en la variable sql.
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@prmIdMarca";
                param.Value = idMarca;
                cmd.Parameters.Add(param);
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

        public DataSet ListarModelos()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            string sql = "SELECT m.Modelo FROM Modelo m";
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
