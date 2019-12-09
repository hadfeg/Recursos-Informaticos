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

        }
        [WebMethod]
        public static List<Usuario> ListarUsuario()
        {
            List<Usuario> Lista = null;
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
    }
}