    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


using CapaEntidades;
using CapaLogicaNegocio;
using CapaAccesoDatos;
using System.Web.Script.Services;

namespace CapaPresentacion
{
    public partial class GestionarLaptop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDDLMarca();
                llenarDDLSO();
                llenarDDLModeloMarcaModal();
            }
            //else
            //{
            //    llenarDDLMarca();
            //    llenarDDLSO();
            //    llenarDDLModeloMarcaModal();

            //}
        }

        private void llenarDDLModelos(int idMarca)
        {
            ddlModelo.DataSource = ModeloLN.getInstance().ListarModelos(idMarca);
            ddlModelo.DataTextField = "Modelo";
            ddlModelo.DataValueField = "IdModelo";
            ddlModelo.DataBind();
            ddlModelo.Items.Insert(0, new ListItem("[Seleccione modelo]"));
            int cant = ddlModelo.Items.Count;
            ddlModelo.Items.Insert(cant, new ListItem("[NUEVO MODELO]"));
        }

        protected void llenarDDLModeloMarcaModal()
        {
            ddlModeloMarcaModal.DataSource = MarcaLN.getInstance().ListarMarcas();
            ddlModeloMarcaModal.DataTextField = "Marca";
            ddlModeloMarcaModal.DataValueField = "IdMarca";
            ddlModeloMarcaModal.DataBind();
            ddlModeloMarcaModal.Items.Insert(0, new ListItem("[Seleccione marca]"));            
        }

        private void llenarDDLMarca()
        {
            ddlMarca.DataSource = MarcaLN.getInstance().ListarMarcas();
            ddlMarca.DataTextField = "Marca";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("[Seleccione marca]"));
            //int cant = ddlMarca.Items.Count;
            //ddlMarca.Items.Insert(cant, new ListItem("[NUEVA MARCA]"));            
        }
       
        private void llenarDDLSO(){
            ddlSO.DataSource = SistemaOperativoLN.getInstance().ListarSistemasOperativos();
            ddlSO.DataTextField = "Nombre"; // Nombre de la columna en la BD.
            ddlSO.DataValueField = "IdSO"; // Nombre de la columna en la BD.
            ddlSO.DataBind();
            ddlSO.Items.Insert(0, new ListItem("[Seleccione Sistema Operativo]"));
            int cant = ddlSO.Items.Count;
            ddlSO.Items.Insert(cant, new ListItem("[NUEVO SISTEMA OPERATIVO]"));
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

        private Laptop GetEntity()
        {    
            Laptop objLaptop = new Laptop();
            objLaptop.Serie = txtSerie.Text;
            objLaptop.IdModelo = Convert.ToInt32(ddlModelo.SelectedValue);
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
            String val = ddlMarca.SelectedValue.ToString();
            objLaptop.IdSistOperativo = Convert.ToInt32(ddlSO.SelectedValue);
            objLaptop.IdMarca = Convert.ToInt32(ddlMarca.SelectedValue);
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

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            String valor = ddlMarca.SelectedItem.Text;
            bool condicion_1 = (valor == "[NUEVA MARCA]");
            bool condicion_2 = (valor == "[Seleccione marca]");
            
            if (condicion_1)
            {
                ddlMarca.AutoPostBack = false;                
                return;
            }
            else if (condicion_2)
            {
                ddlMarca.AutoPostBack = false;
                return;
            }
            else
            {
                int marcaSeleccionada = Convert.ToInt32(ddlMarca.SelectedValue);
                llenarDDLModelos(marcaSeleccionada);
                ddlMarca.AutoPostBack = true;
            }           
        } 

        protected void ddlMarca_TextChanged(object sender, EventArgs e)
        {
            Response.Write("<script>alert('REGISTRO INCORRECTO11111.')</script>");
        }

        //ScriptMethod(ResponseFormat = ResponseFormat.Json,UseHttpGet = true)
        [WebMethod]         
        public static bool AgregarMarca(String marca)
        {
            bool ok = false;                        
            try
            {
                Marca objMarca = new Marca();
                objMarca.marca = marca;
                MarcaLN.getInstance().RegistrarMarca(objMarca);
                ok = true;
                return ok;
            }
            catch (Exception e) {
                throw e;
            }
        }

        [WebMethod]
        public static bool AgregarSistemaOperativo(String nombre, float version, String sp, String suscripcion)
        {
            bool ok = false;

            try
            {
                SistemaOperativo objSistemaOperativo = new SistemaOperativo();
                objSistemaOperativo.NombreSO = nombre;
                objSistemaOperativo.Version = version;
                objSistemaOperativo.ServiPack = sp;
                objSistemaOperativo.Suscripcion = suscripcion;
                SistemaOperativoLN.getInstance().RegistrarSistemaOperativo(objSistemaOperativo);
                ok = true;
                return ok;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static bool AgregarModelo(String modelo, String marca)
        {
            bool ok = false;

            try
            {
                int marca_id = Convert.ToInt32(marca);
                Modelo objModelo = new Modelo();
                objModelo.NombreModelo = modelo;
                objModelo.MarcaId = marca_id;
                ModeloLN.getInstance().RegistrarModelo(objModelo);
                ok = true;
                return ok;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

}