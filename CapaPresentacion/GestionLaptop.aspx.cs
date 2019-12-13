using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class GestionarLaptop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Laptop objLaptop = new Laptop();
            objLaptop = this.GetEntity();
            bool response = LaptopLN.getInstance().RegistrarLaptop(objLaptop);

            if (response == true)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");
            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }

        private Laptop GetEntity() {

            //int NivelAcceso = Convert.ToInt32(rbNivelAcceso.SelectedValue);
            Laptop objLaptop = new Laptop();
           
            objLaptop.Serie = txtSerie.Text;
            objLaptop.IdMarca = Convert.ToInt32(txtMarca.Text);
            objLaptop.Modelo = txtModelo.Text;
            objLaptop.Ram = txtRam.Text;
            objLaptop.NombreLaptop = txtNombreEquipo.Text;
            objLaptop.Procesador = txtProcesador.Text;
            objLaptop.MAC = txtMac.Text;
            objLaptop.IDTeamviewer = Convert.ToInt32(txtTeamViewerID.Text);
            objLaptop.FechaCompra = Convert.ToDateTime(txtFechaCompra.Text);
            objLaptop.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            objLaptop.FechaUltimaMantencion = Convert.ToDateTime(txtFechaMantencion.Text);
            objLaptop.Estado = txtEstado.Text;
            objLaptop.Opcional = txtOpcional.Text;
            objLaptop.Comentario = txtComentario.Text;            
            objLaptop.IdSistOperativo = Convert.ToInt32(txtSO.Text);
            objLaptop.HDD = Convert.ToInt32(txtHDD.Text);

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
            return objLaptop;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {



        }

        private void llenarDDLMarca()
        {
           // ddlSO.DataSource = MarcaLN.getInstance().ListarDepartamento();
            ddlSO.DataTextField = "Marca";
            ddlSO.DataValueField = "IdMarca";
            ddlSO.DataBind();
            ddlSO.Items.Insert(0, new ListItem("[Seleccione Departamento]"));
            int cant = ddlSO.Items.Count;
            ddlSO.Items.Insert(cant, new ListItem("[NUEVO DEPARTAMENTO]"));

        }

        private void llenarDDLSO()
        {
           //ddlSO.DataSource = SistemaOperativoLN.getInstance().ListarDepartamento();
            ddlSO.DataTextField = "Marca";
            ddlSO.DataValueField = "IdMarca";
            ddlSO.DataBind();
            ddlSO.Items.Insert(0, new ListItem("[Seleccione Departamento]"));
            int cant = ddlSO.Items.Count;
            ddlSO.Items.Insert(cant, new ListItem("[NUEVO DEPARTAMENTO]"));

        }

    }

}