using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


using CapaEntidades;
using CapaLogicaNegocio;
using System.Threading;

namespace CapaPresentacion
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                if (!IsPasswordResetLinkValid()) {
                    Response.Write("<script>alert('Estdimad@, el link al que acaba de ingresar expiró, solicite nuevamenet un cambio de contraseña !!')</script>");
                    Response.Redirect("SendEmail.aspx");
                }
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            String password = Login1.Password;
            String GUID = Request.QueryString["uid"];
            bool cambio_contraseña = UsuarioLN.getInstance().ChangePassword(GUID,password);

            if (cambio_contraseña) {                
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                Response.Redirect("./Login.aspx");
                Response.Write("<script>alert('Cambio de contraseña exitoso !!!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Cambio de contraseña inválido, intente nuevamente !')</script>");
            }

        }

        protected bool IsPasswordResetLinkValid()
        {
             String GUID = Request.QueryString["uid"];

             return UsuarioLN.getInstance().IsPasswordResetLinkValid(GUID);
        }

    }
}