using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                InicarLLenadoEmpresa();
                InicarLLenadoDepartamento();
            }
        }
        private void InicarLLenadoEmpresa()
        {
            ddlEmpresa.DataSource = EmpresaLN.getInstance().ListarEmpresa();
            ddlEmpresa.DataTextField = "NombreEmpresa";
            ddlEmpresa.DataValueField = "IdEmpresa";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("[Seleccione Empresa]"));
            int cant = ddlEmpresa.Items.Count;
            ddlEmpresa.Items.Insert(cant, new ListItem("[NUEVA EMPRESA]"));            
        }
        private void InicarLLenadoDepartamento()
        {
            ddlDepartamento.DataSource = DepartamentoLN.getInstance().ListarDepartamento();
            ddlDepartamento.DataTextField = "NombreDepartamento";
            ddlDepartamento.DataValueField = "IdDepartamento";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("[Seleccione Departamento]"));
            int cant = ddlDepartamento.Items.Count;
            ddlDepartamento.Items.Insert(cant, new ListItem("[NUEVO DEPARTAMENTO]"));            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e) {

            Usuario objUsuario = new Usuario();
            objUsuario = GetEntity();           
            bool rut_valido = validarRut(objUsuario);
            if (rut_valido)
            {
                bool response = UsuarioLN.getInstance().RegistrarUsuario(objUsuario);

                if (response == true)
                {
                    Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");
                }
                else
                {
                    Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Rut inválido, por favor intente nuevamente !!!')</script>");
            }
            
        }

        private bool validarRut(Usuario objUser)
        {
            bool validacion = false;
            String rut;
            try
            {
                rut = objUser.Rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));
                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));
                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        private Usuario GetEntity()
        {
            //int NivelAcceso = Convert.ToInt32(rbNivelAcceso.SelectedValue);
            Usuario objUsuario = new Usuario();
            objUsuario.Rut = txtRut.Text;
            objUsuario.User = txtUsuario.Text;
            objUsuario.Pass = txtContrasena.Text;
            objUsuario.Name = txtNombre.Text;
            objUsuario.LastName = txtApellido.Text;
            objUsuario.Rol = Convert.ToInt32(rblPerfil.SelectedValue);
            objUsuario.Mail = txtEmail.Text;            
            objUsuario.Estado = 0;
            objUsuario.Departamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
            objUsuario.Empresa = Convert.ToInt32(ddlEmpresa.SelectedValue);

            /**
            if (NivelAcceso == 1)
            {
                objUsuario.Cliente = "TODOS";
                objUsuario.Contrato = "TODOS";
            }
            if (NivelAcceso == 2)
            {
                objUsuario.Cliente = ddlAcceso.SelectedItem.Text;
                objUsuario.Contrato = "0";
            }
            if (NivelAcceso == 3)
            {
                objUsuario.Cliente = "0";
                objUsuario.Contrato = ddlAcceso.SelectedItem.Text;
            }**/
            return objUsuario;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}