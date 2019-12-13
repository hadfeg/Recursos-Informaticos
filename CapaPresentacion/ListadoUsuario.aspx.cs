using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using CapaLogicaNegocio;
using CapaEntidades;
//using CapaPresentacion.Custom;

namespace CapaPresentacion
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InicarLLenadoEmpresaModal();
            InicarLLenadoDepartamentoModal();
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
        public void InicarLLenadoEmpresaModal()
        {
            ddlEmpresaModal.DataSource = EmpresaLN.getInstance().ListarEmpresa();
            ddlEmpresaModal.DataTextField = "NombreEmpresa";
            ddlEmpresaModal.DataValueField = "IdEmpresa";
            ddlEmpresaModal.DataBind();
            ddlEmpresaModal.Items.Insert(0, new ListItem("[Seleccione Empresa]"));
            int cant = ddlEmpresaModal.Items.Count;
            ddlEmpresaModal.Items.Insert(cant, new ListItem("[NUEVA EMPRESA]"));
            LlenarDatosDLLModal();
        }
        private void InicarLLenadoDepartamentoModal()
        {
            ddlDeptoModal.DataSource = DepartamentoLN.getInstance().ListarDepartamento();
            ddlDeptoModal.DataTextField = "NombreDepartamento";
            ddlDeptoModal.DataValueField = "IdDepartamento";
            ddlDeptoModal.DataBind();
            ddlDeptoModal.Items.Insert(0, new ListItem("[Seleccione Departamento]"));
            int cant = ddlDeptoModal.Items.Count;
            ddlDeptoModal.Items.Insert(cant, new ListItem("[NUEVO DEPARTAMENTO]"));
            LlenarDatosDLLModal();
        }
        private void LlenarDatosDLLModal()
        {
            String rut = Session["id"].ToString();
            Usuario usuario_actual = UsuarioLN.getInstance().SeleccionarUsuario(rut);          
            /* Llenado de los valores actuales del usuario logeado (Dropdown List Empresa y Dropdown List Departamento)*/
            ddlDeptoModal.SelectedValue = usuario_actual.Departamento.ToString();
            ddlEmpresaModal.SelectedValue = usuario_actual.Empresa.ToString();
        }
    }
}