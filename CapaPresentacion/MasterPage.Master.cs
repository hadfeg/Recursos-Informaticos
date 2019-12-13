using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                String user = Convert.ToString(Session["Usuario"]);
                this.NombreUsuario1.Text = user;
                this.NombreUsuario2.Text = user;
                this.user_image.ImageUrl = Convert.ToString(Session["Image"]);
                this.user_image2.ImageUrl = Convert.ToString(Session["Image"]);
                this.user_image3.ImageUrl = Convert.ToString(Session["Image"]);
                this.user_image4.ImageUrl = Convert.ToString(Session["Image"]);
            }
            else
            {
                Response.Write("<script>alert('Acceso denegado, usted no se ha autenticado !');</script>");
                Response.Redirect("Login.aspx");
            }
        }
        public Label usrName()
        {
            return this.NombreUsuario1;
        }
    }
}