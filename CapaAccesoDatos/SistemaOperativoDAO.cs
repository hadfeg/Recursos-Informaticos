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
    public class SistemaOperativoDAO
    {

        #region "PATRON SINGLETON"
        private static SistemaOperativoDAO daoSistemaOperativo = null;
        private SistemaOperativoDAO() { }
        public static SistemaOperativoDAO getInstance()
        {
            if (daoSistemaOperativo == null)
            {
                daoSistemaOperativo = new SistemaOperativoDAO();
            }
            return daoSistemaOperativo;
        }
        #endregion

        public bool RegistrarSO(SistemaOperativo objSO)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarSistemaOperativo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmMarca", objSO);
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
        /*
        public List<SistemaOperativo> ListarSistemasOperativos()
        {
            List<SistemaOperativo> Lista = new List<SistemaOperativo>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarSistemasOperativos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {                  
                    SistemaOperativo objSO = new SistemaOperativo();
                    objSO.IdSistemaOperativo = Convert.ToInt32(dr["IdSO"].ToString());
                    objSO.SO = dr["Nombre"].ToString();
                    objSO.Version = float.Parse((dr["Version"].ToString()));
                    objSO.ServiPack  = dr["Service_Pack"].ToString();
                    objSO.Suscripcion= dr["Suscripcion"].ToString();                    
                    Lista.Add(objSO);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }*/

        public DataSet ListarSistemasOperativos()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            string sql = "SELECT * FROM SO";
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
