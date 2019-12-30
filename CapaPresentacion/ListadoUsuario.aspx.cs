using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CapaLogicaNegocio;
using CapaEntidades;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
//using CapaPresentacion.custom;
 
namespace CapaPresentacion
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InicarLLenadoEmpresaModal();
            InicarLLenadoDepartamentoModal();
            InicarLLenadoPerfilModal();
        }
        [WebMethod]
        public static List<UsuarioAJAX> ListarUsuario()
        {
            List<UsuarioAJAX> Lista = null;
            try
            {
                Lista = UsuarioLN.getInstance().ListarUsuario();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }

        [WebMethod]
        public static bool EliminarUsuarioLogico(String rut)
        {
            //Int32 Rut = Convert.ToInt32(rut);
            bool ok = UsuarioLN.getInstance().Eliminar(rut);            
            return ok;
        }

        [WebMethod]
        public static bool ActualizarDatosUsuario(String rut, String correo, String nombres, String apellidos, String pass, String idEmpresa, String idDepartamento, String rol)
        {
            Usuario objUsuario = new Usuario()
            {
                //rut = Convert.ToInt32(rut),
                Rut = rut,
                Mail = correo,
                Name = nombres,
                LastName = apellidos,
                Pass = pass,
                Empresa = Convert.ToInt32(idEmpresa),
                Departamento = Convert.ToInt32(idDepartamento),
                Rol = Convert.ToInt32(rol)

            };
            bool ok = UsuarioLN.getInstance().ActualizarDatosUsuario(objUsuario);
            return ok;
        }

        public void InicarLLenadoEmpresaModal()
        {
            ddlEmpresaModal.DataSource = EmpresaLN.getInstance().ListarEmpresa();
            ddlEmpresaModal.DataTextField = "NombreEmpresa";
            ddlEmpresaModal.DataValueField = "IdEmpresa";
            ddlEmpresaModal.DataBind();                        
            LlenarDatosDLLModal();
        }

        private void InicarLLenadoDepartamentoModal()
        {
            ddlDeptoModal.DataSource = DepartamentoLN.getInstance().ListarDepartamento();
            ddlDeptoModal.DataTextField = "NombreDepartamento";
            ddlDeptoModal.DataValueField = "IdDepartamento";
            ddlDeptoModal.DataBind();                       
            LlenarDatosDLLModal();
        }

        private void InicarLLenadoPerfilModal()
        {
            ddlPerfilModal.DataSource = PerfilLN.getInstance().ListarPerfil();
            ddlPerfilModal.DataTextField = "Descripcion";
            ddlPerfilModal.DataValueField = "IdPerfil";
            ddlPerfilModal.DataBind();            
            LlenarDatosDLLModal();
        }

        [WebMethod]
        private void LlenarDatosDLLModal()
        {
            String rut = Session["id"].ToString();
            Usuario usuario_actual = UsuarioLN.getInstance().SeleccionarUsuario(rut);          
            /* Llenado de los valores actuales del usuario logeado (Dropdown List Empresa y Dropdown List Departamento)*/
            ddlDeptoModal.SelectedValue = usuario_actual.Departamento.ToString();
            ddlEmpresaModal.SelectedValue = usuario_actual.Empresa.ToString();
            ddlPerfilModal.SelectedValue = usuario_actual.Rol.ToString();
        }

        [WebMethod]
        public static String SeleccionarDepartamento(String rut) {

            String departamento = "";

            try
            {
                departamento = UsuarioLN.getInstance().SeleccionarDepartamento(rut);
            }
            catch (Exception e)
            {            
                throw e;
            } 

            return departamento;            
                        
        }

        [WebMethod]
        public static String SeleccionarEmpresa(String rut)
        {

            String departamento = "";

            try
            {
                departamento = UsuarioLN.getInstance().SeleccionarEmpresa(rut);
            }
            catch (Exception e)
            {
                throw e;
            }

            return departamento;

        }

        [WebMethod]
        public static int SeleccionarPerfil(String rut)
        {

            int perfil;

            try
            {
                perfil = UsuarioLN.getInstance().SeleccionarPerfil(rut);
            }
            catch (Exception e)
            {
                throw e;
            }

            return perfil;

        }

    }
}