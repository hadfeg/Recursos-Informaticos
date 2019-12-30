using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace CapaAccesoDatos
{
    public class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO daoUsuario = null;
        private UsuarioDAO() { }
        public static UsuarioDAO getInstance()
        {
            if (daoUsuario == null)
            {
                daoUsuario = new UsuarioDAO();
            }
            return daoUsuario;
        }
        #endregion

        public Usuario AccesoSistema(String user, String pass)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spAccesoSistema", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUser", user);
                cmd.Parameters.AddWithValue("@prmPass", pass);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.User = dr["Usuario"].ToString();
                    objUsuario.Pass = dr["Contrasena"].ToString();
                    objUsuario.UsrImage = dr["UsrImg"].ToString();
                    objUsuario.Rut = dr["Rut"].ToString();
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;
        }

        public bool RegistrarUsuario(Usuario objUsuario)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmUser", objUsuario.User);
                cmd.Parameters.AddWithValue("@prmPass", objUsuario.Pass);
                cmd.Parameters.AddWithValue("@prmName", objUsuario.Name);
                cmd.Parameters.AddWithValue("@prmLastName", objUsuario.LastName);
                cmd.Parameters.AddWithValue("@prmRol", objUsuario.Rol);
                cmd.Parameters.AddWithValue("@prmEmail", objUsuario.Mail);
                cmd.Parameters.AddWithValue("@prmState", objUsuario.Estado);
                cmd.Parameters.AddWithValue("@prmRut", objUsuario.Rut);
                cmd.Parameters.AddWithValue("@prmEmpresa", objUsuario.Empresa);
                cmd.Parameters.AddWithValue("@prmDepartamento", objUsuario.Departamento);
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

        public List<UsuarioAJAX> ListarUsuario()
        {
            List<UsuarioAJAX> Lista = new List<UsuarioAJAX>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // Crear objetos de tipo Usuario
                    UsuarioAJAX objUsuario = new UsuarioAJAX();
                    objUsuario.Rut = dr["Rut"].ToString();
                    objUsuario.Name = dr["Nombre"].ToString();
                    objUsuario.LastName = dr["Apellido"].ToString();
                    objUsuario.Mail = dr["Email"].ToString();
                    objUsuario.Empresa = dr["NombreEmpresa"].ToString();
                    objUsuario.Departamento = dr["NombreDepartamento"].ToString();
                    //objUsuario.Estado = Convert.ToInt32(dr["Estado"].ToString());

                    // añadir a la lista de objetos
                    Lista.Add(objUsuario);
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
        }

        public Usuario SeleccionarUsuario(String rut)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEncontrarUsuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut",rut);     
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.User = dr["Usuario"].ToString();
                    objUsuario.Pass = dr["Contrasena"].ToString();
                    objUsuario.UsrImage = dr["UsrImg"].ToString();
                    objUsuario.Rut = dr["Rut"].ToString();
                    objUsuario.Empresa = Convert.ToInt32(dr["IdEmpresa"].ToString());
                    objUsuario.Departamento = Convert.ToInt32(dr["IdDepartamento"].ToString());
                    objUsuario.Estado = Convert.ToInt32(dr["Estado"].ToString());
                    objUsuario.Rol = Convert.ToInt32(dr["Rol"].ToString());
                    objUsuario.LastName = dr["Apellido"].ToString();
                    objUsuario.Mail = dr["Email"].ToString();
                    objUsuario.Name = dr["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;

        }        

        public bool ActualizarDatosUsuario(Usuario objUsuario)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarDatosUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut", objUsuario.Rut);                
                cmd.Parameters.AddWithValue("@prmPassword", objUsuario.Pass);
                cmd.Parameters.AddWithValue("@prmName", objUsuario.Name);
                cmd.Parameters.AddWithValue("@prmLastName", objUsuario.LastName);
                cmd.Parameters.AddWithValue("@prmCorreo", objUsuario.Mail);
                cmd.Parameters.AddWithValue("@prmDepartamento", objUsuario.Departamento);
                cmd.Parameters.AddWithValue("@prmEmpresa", objUsuario.Empresa);
                cmd.Parameters.AddWithValue("@prmRol", objUsuario.Rol);
                conexion.Open();
                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool Actualizar(Usuario objUsuario)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;  

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spActualizarUsuarioLogeado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut", objUsuario.Rut);
                cmd.Parameters.AddWithValue("@prmUser", objUsuario.User);
                cmd.Parameters.AddWithValue("@prmPassword", objUsuario.Pass);
                cmd.Parameters.AddWithValue("@prmName", objUsuario.Name);
                cmd.Parameters.AddWithValue("@prmLastName", objUsuario.LastName);
                cmd.Parameters.AddWithValue("@prmCorreo", objUsuario.Mail);
                cmd.Parameters.AddWithValue("@prmDepartamento", objUsuario.Departamento);
                cmd.Parameters.AddWithValue("@prmEmpresa", objUsuario.Empresa);
                cmd.Parameters.AddWithValue("@prmUserimg", objUsuario.UsrImage);
                conexion.Open();
                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public bool Eliminar(String Rut)
        {
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            bool ok = false;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarUsuarioLogico", conexion);
                cmd.Parameters.AddWithValue("@prmRut", Rut);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

        public String SeleccionarDepartamento(String rut) {

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            String departamento = "";

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spSeleccionarDepartamento", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut", rut);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {                    
                    departamento = dr["NombreDepartamento"].ToString();                   
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return departamento;

        }

        public String SeleccionarEmpresa(String rut)
        {

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            String departamento = "";

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spSeleccionarEmpresa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut", rut);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    departamento = dr["NombreEmpresa"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return departamento;

        }

        public int SeleccionarPerfil(String rut)
        {

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            int perfil = 0;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spSeleccionarPerfil", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut", rut);
                conexion.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    perfil = Convert.ToInt32(dr["Rol"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return perfil;

        }

        public Usuario EncontrarUsuarioEmail(String correo)
        {

            SqlConnection conexion = null;
            SqlCommand cmd = null;
            Usuario objUsuario = null;
            SqlDataReader dr = null;
            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEncontrarUsuarioCorreo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmRut",correo);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario();
                    objUsuario.User = dr["Usuario"].ToString();
                    objUsuario.Pass = dr["Contrasena"].ToString();
                    objUsuario.UsrImage = dr["UsrImg"].ToString();
                    objUsuario.Rut = dr["Rut"].ToString();
                    objUsuario.Empresa = Convert.ToInt32(dr["IdEmpresa"].ToString());
                    objUsuario.Departamento = Convert.ToInt32(dr["IdDepartamento"].ToString());
                    objUsuario.Estado = Convert.ToInt32(dr["Estado"].ToString());
                    objUsuario.Rol = Convert.ToInt32(dr["Rol"].ToString());
                    objUsuario.LastName = dr["Apellido"].ToString();
                    objUsuario.Mail = dr["Email"].ToString();
                    objUsuario.Name = dr["Nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return objUsuario;            

        }

        public bool ResetPassword(String correo) {

            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
                {
                    conexion = Conexion.getInstance().ConexionBD();
                    cmd = new SqlCommand("spResetPassword", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmEmail", correo);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {

                        if (Convert.ToBoolean(dr["ReturnCode"]))
                        {
                            String nombreUsuario = dr["UserName"].ToString();
                            String idUnico = dr["UniqueId"].ToString();

                            SendPasswordResetEmail(correo,nombreUsuario,idUnico);                                                
                        }
                        else
                        {
                            return ok;
                        }

                    }
                    
                    ok = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexion.Close();
                }
                return ok;                                  
        }

        private void SendPasswordResetEmail(String ToEmail, String UserName, String UniqueId)
        {
            MailMessage mailMessage = new MailMessage("inversionesfarias.mailmanager@gmail.com", ToEmail);

            StringBuilder sbEmailBody = new StringBuilder();
            sbEmailBody.Append("Estimad@ " + UserName + ",<br/><br/>");
            sbEmailBody.Append("Usted ha solicitado un cambio de contraseña, haga click en el siguiente link para realizar el proceso: <br/><br/>");
            sbEmailBody.Append("http://localhost:1563/ResetPassword.aspx?uid=" + UniqueId + "<br/><br/>");
            sbEmailBody.Append("<b><i>Inversiones Farías - Departamento TI y Contraloría.</i></b>");
            mailMessage.IsBodyHtml = true;

            mailMessage.Body = sbEmailBody.ToString();
            mailMessage.Subject = "Reestablecer Contraseña";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);

            smtpClient.Credentials = new System.Net.NetworkCredential("inversionesfarias.mailmanager@gmail.com", "3192yahima");          

            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);

        }

        /*Funcion que retorna un tipo de dato bool, que verifica si el link para reestablecer la contraseña es valido.*/
        public bool IsPasswordResetLinkValid(String GUID) {

                bool ok = false;
                SqlConnection conexion = null;
                SqlCommand cmd = null;
                SqlDataReader dr = null;

                try
                {
                    conexion = Conexion.getInstance().ConexionBD();
                    cmd = new SqlCommand("spIsPasswordResetLinkValid", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmGUID", GUID);
                    conexion.Open();
                    cmd.ExecuteScalar();

                    dr = cmd.ExecuteReader();

                    if (dr.Read()) {     

                        if (Convert.ToBoolean(dr["IsValidPasswordResetLink"]))
                        {
                            ok = true;
                        }
                    }

                }
                catch (Exception ex)
                {                   
                    throw ex;
                }
                finally
                {
                    conexion.Close();
                }
                return ok;            
        }

        public bool ChangePassword(String GUID, String Password) {

            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spChangePassword", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmGUID", GUID);
                cmd.Parameters.AddWithValue("@prmPassword", Password);
                conexion.Open();
                cmd.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;

        }

        public bool ExisteCorreo(String correo)
        {
            bool ok = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                conexion = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spExisteCorreo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmCorreo", correo);
                conexion.Open();
                int filas = Convert.ToInt32(cmd.ExecuteScalar());

                if (filas > 0) { ok = true; }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return ok;
        }

    }    

}
