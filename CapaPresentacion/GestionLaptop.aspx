﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionLaptop.aspx.cs" Inherits="CapaPresentacion.GestionarLaptop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <br/>
        <h2 style="text-align: center">REGISTRO DE EQUIPOS</h2>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>SERIE DEL EQUIPO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtSerie" runat="server" Text="" CssClass="form-control" placeholder=" "></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>MARCA</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID ="ddlMarca" runat="server" Width="580px" Height="30px" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="True" ValidateRequestMode="Enabled" EnableViewState="True"></asp:DropDownList>
                            <!--<asp:TextBox ID="txtMarca" runat="server" Text="" CssClass="form-control" placeholder="Ej: HP"></asp:TextBox>-->
                        </div>
                        <div class="form-group">
                            <label>PROCESADOR</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtProcesador" runat="server" Text="" CssClass="form-control" placeholder="Ej: Intel Core i8"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>HDD</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtHDD" runat="server" Text="" CssClass="form-control" placeholder="EJ: 100 GB (Ingrese solo el numero)"></asp:TextBox>
                        </div>                                   
                         
                        <div class="form-group">
                            <label>SISTEMA OPERATIVO</label>                            
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID ="ddlSO" runat="server" Width="580px" Height="30px"></asp:DropDownList>
                            <!--<asp:TextBox ID="txtSO" runat="server" Text="" CssClass="form-control" placeholder="Ej: Windows 10, macOSx, etc"></asp:TextBox>-->
                        </div>
                        <div class="form-group">
                            <label>ESTADO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEstado" runat="server" Text="" CssClass="form-control" type="text" placeholder="Ej: F6-40-BB-06-5A-67"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>FECHA DE COMPRA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFechaCompra" TextMode="Date" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>FECHA DE ENTREGA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFechaEntrega" TextMode="Date" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                        </div>                                              
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRE DEL EQUIPO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombreEquipo" runat="server" Text="" CssClass="form-control" placeholder="LAPT-YHADFEG"></asp:TextBox>
                        </div>                       
                        <div class="form-group">
                            <label>MODELO</label>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList ID ="ddlModelo" runat="server" Width="580px" Height="30px"></asp:DropDownList>
                            <!--<asp:TextBox ID="txtModelo" runat="server" Text="" CssClass="form-control" type="text" placeholder="Inspiron 5567"></asp:TextBox>-->
                        </div> 
                        <div class="form-group">
                            <label>RAM</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRam" runat="server" Text="" CssClass="form-control" type="text" placeholder="16 GB"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>MAC</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMac" runat="server" Text="" CssClass="form-control" type="text" placeholder="Ej:00:00:00:a1:2b:cc"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>TEAM VIEWER ID</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtTeamViewerID" runat="server" Text="" CssClass="form-control" type="text" placeholder="Ej:1475154154"></asp:TextBox>
                        </div>  
                        <div class="form-group">
                            <label>OPCIONAL</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtOpcional" runat="server" Text="" CssClass="form-control" type="text" placeholder="Ej: Comentarios Opcionales"></asp:TextBox>
                        </div>          

                        <div class="form-group">
                            <label>FECHA DE ULTIMA MANTENCION</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFechaMantencion" TextMode="Date" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                        </div> 
                        <div class="form-group">
                            <label>COMENTARIOS</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtComentario" runat="server" Text="" CssClass="form-control" type="text" placeholder="Ej: Bateria de poca durabilidad,Pantalla trizada,etc."></asp:TextBox>
                        </div>                           
                    </div>
                </div>
            </div>               
        </div>

        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="modal fade" id="modalAgregarMarca" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel" style="text-align: center">AGREGAR MARCA</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-md-4">
                                        <h5><strong>Nombre</strong></h5>
                                        <asp:TextBox ID="txtNombreMarca" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>                                
                                    </div>                                    
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" id="btn_agregar">Agregar</button>
                            <button type="button" class="btn btn-primary" id="btn_volver">Volver</button>
                        </div>
                     </div>
                 </div>
         </div>

    </section>        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="scripts/Laptop.js" type="text/javascript"></script>
</asp:Content>
