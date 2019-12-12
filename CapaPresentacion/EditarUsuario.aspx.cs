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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session != null) {
                this.UsrImg_Update.ImageUrl = Convert.ToString(Session["Image"]);                
            }                                                   
        }
     
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            String pass = Convert.ToString(Session["Contrasena"]);
            String rut = Convert.ToString(Session["id"]);
            int empresa = Int32.Parse(ddlEmpresa.SelectedValue.ToString());
            int depto = Int32.Parse(ddlDepto.SelectedValue.ToString());
            String correo = txtEmail.Text;
            String apellido = txtApellido.Text;
            String nombreUsuario = txtUsuario.Text;
            String contraseña = txtContrasena.Text;
            String contraseña2 = txtContrasena2.Text;

            Usuario objUsuario = new Usuario();
            objUsuario.Rut = rut;
            objUsuario.Name = nombre;
            objUsuario.Pass = pass;
            objUsuario.Mail = correo;
            objUsuario.User = nombreUsuario;
            objUsuario.LastName = apellido;
            objUsuario.Departamento = Convert.ToInt32(depto);
            objUsuario.Empresa = Convert.ToInt32(empresa);
            objUsuario.Pass = contraseña;

            if (UsrImg_Up.PostedFile != null)
            {
                String formato = Path.GetExtension(UsrImg_Up.PostedFile.FileName);
                if (formato != ".jpg" && formato != ".jpeg" && formato != ".png")
                {
                    LabUpdateImg.Text = ("Estimad@, solo se permiten formatos jpg, jpeg y png, intente nuevamente !!");
                    LabUpdateImg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    LabUpdateImg.Text = ("Formato de imagen correcto !!");
                    LabUpdateImg.ForeColor = System.Drawing.Color.Green;
                }

                String img = Path.GetFileName(UsrImg_Up.PostedFile.FileName); // Obtiene el nombre de la imagen que se quiere subir.
                String img_anterior = Convert.ToString(Session["Image"]);    // Obtiene el nombre de la imagen actual, para eliminarla del repositorio.
                UsrImg_Up.SaveAs(Server.MapPath("~/UserImages/") + img);    // Guarda la imagen que el usuario sube en el directorio ~/UserImages/
                objUsuario.UsrImage = "~/UserImages/" + img;               // Actualiza la imagen del usuario, añadiendola a un objeto de tipo Usuario.
                img_anterior = img_anterior.Substring(13); ;              // Obtiene el nombre de la imagen anterior, sin el repositorio. 
                String path = Directory.GetCurrentDirectory();           // Se obtiene el directorio actual de trabajo.
                File.Delete(img_anterior);                              // Finalmente, elimina las imagen anterior del directorio.

                Session["Image"] = "~/UserImages/" + img;
                Session["Usuario"] = objUsuario.User;
            }                        
            bool response = UsuarioLN.getInstance().Actualizar(objUsuario);

            if (response == true)
            {
                Response.Write("<script>alert('ACTUALIZACIÓN CORRECTA.')</script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('ESTIMAD@, HA HABIDO UN FALLO LA ACTUALIZACIÓN DE LOS DATOS .')</script>");
            }

        }

        private Usuario GetEntity()
        {
            //int NivelAcceso = Convert.ToInt32(rbNivelAcceso.SelectedValue);
            Usuario objUsuario = new Usuario();
            objUsuario.User = txtUsuario.Text;
            objUsuario.Name = txtNombre.Text;
            objUsuario.LastName = txtApellido.Text;
            objUsuario.Mail = txtEmail.Text;
            //objUsuario.Rol = Convert.ToInt32(ddlPerfil.SelectedValue);
            objUsuario.Estado = 1; // Se asume que al ingresar usuario esta Activo.
            objUsuario.Pass = txtContrasena.Text;

         
            return objUsuario;
        }

        protected void btn_Cancelar_Click(object sender, EventArgs e)
        {   

            Response.Redirect("PanelGeneral.aspx");
        }

       
    }
}