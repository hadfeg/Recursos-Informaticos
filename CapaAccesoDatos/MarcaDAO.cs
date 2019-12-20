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
    public class MarcaDAO
    {

        #region "PATRON SINGLETON"
        private static MarcaDAO daoMarca = null;
        private MarcaDAO() { }
        public static MarcaDAO getInstance()
        {
            if (daoMarca == null)
            {
                daoMarca = new MarcaDAO();
            }
            return daoMarca;
        }
        #endregion

        public bool RegistrarMarca(Marca objMarca )
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarMarca", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmMarca", objMarca.marca);               
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
        public List<Marca> ListarMarcas()
        {
            List<Marca> Lista = new List<Marca>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarMarcas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Crear objetos de tipo Usuario
                    Marca objMarca = new Marca();
                    objMarca.IdMarca = Convert.ToInt32(dr["IdMarca"].ToString());
                    objMarca.marca = dr["Marca"].ToString();                    
                    Lista.Add(objMarca);
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

        public DataSet ListarMarcas()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter da = null;
            string sql = "SELECT * FROM Marca ";
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
