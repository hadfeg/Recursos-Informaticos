using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
                       
            
        }

        [WebMethod]
        public static void EnviarCorreo(String correo) {
            
            UsuarioLN.getInstance().ResetPassword(correo);

        }

        [WebMethod]
        public static void ExisteCorreo(String correo) {

            UsuarioLN.getInstance().ExisteCorreo(correo);

        }




    }
}