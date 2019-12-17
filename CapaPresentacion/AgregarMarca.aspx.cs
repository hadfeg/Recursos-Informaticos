using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using CapaEntidades;
using CapaLogicaNegocio;


namespace CapaPresentacion
{
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Marca objMarca = GetEntity();
            bool response = MarcaLN.getInstance().RegistrarMarca(objMarca); ;

            if (response == true)
            {
                Response.Write("<script>alert('INGRESO CORRECTO.')</script>");
                Response.Redirect("GestionLaptop.aspx");
            }
            else
            {
                Response.Write("<script>alert('ESTIMAD@, HA HABIDO UN FALLO LA AGREGACIÓN DE LOS DATOS .')</script>");
            }

        }

        private Marca GetEntity()
        {
            Marca objMarca = new Marca();
            objMarca.marca = txtMarca.Text;
            return objMarca;
        }
    }
}