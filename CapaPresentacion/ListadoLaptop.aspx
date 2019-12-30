<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoLaptop.aspx.cs" Inherits="CapaPresentacion.ListadoLaptop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section>
        <br />
        <h2 style="text-align: center">LISTADO DE LAPTOPS</h2>
    </section>
    <!-- Main content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-body">
                        <table id="tbl_laptops" class="table table-bordered table-striped">
                            <thead>
                                <tr>
                                    <th>SERIE</th>
                                    <th>MAC</th>
                                    <th>MARCA Y MODELO</th>
                                    <th>ID TEAMVIEWER</th>
                                    <th>NOMBRE LAPTOP</th>
                                    <th>Email</th>
                                    <th>Departamento</th>
                                    <th>Empresa</th>                                    
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">
                                <!-- DATA POR MEDIO DE AJAX-->
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>RUT</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Email</th>
                                    <th>Departamento</th>
                                    <th>Empresa</th>                                    
                                    <th>Acciones</th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <!-- End Datatable -->  
    </section>

    <!--MODAL-->
    <div class="modal fade" id="imodalActualizar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="myModalLabel" style="text-align: center">ACTUALIZAR REGISTROS DE USUARIO</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-4">
                                <h5><strong>Rut</strong></h5>
                                <asp:TextBox ID="txtRutModal" runat="server" Text="" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-8">
                                <h5><strong>Correo Electrónico</strong></h5>
                                <asp:TextBox ID="txtCorreoModal" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <h5><strong>Nombres</strong></h5>
                                <asp:TextBox ID="txtNombreModal" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <h5><strong>Apellidos</strong></h5>
                                <asp:TextBox ID="txtApellidosModal" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <h5><strong>Empresa</strong></h5>
                                <asp:DropDownList ID="ddlEmpresaModal" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <h5><strong>Departamento</strong></h5>
                                <asp:DropDownList ID="ddlDeptoModal" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-md-6">
                                <h5><strong>Contraseña</strong></h5>
                                <asp:TextBox ID="txtContrasenaModal" runat="server" Text="" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <h5><strong>Perfil</strong></h5>
                                <asp:DropDownList ID="ddlPerfilModal" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnactualizar">Actualizar</button>
                </div>
            </div>
        </div>
    </div>  

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
