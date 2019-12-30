<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CambiarContraseña.aspx.cs" Inherits="CapaPresentacion.CambiarContaseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <br />
        <h2 style="text-align: center">CAMBIO DE CONTRASEÑA</h2>
    </section>
    <section class="content">
        <div class="row" style="width:600px" >
            <div class="col-md-6">
                <div class="box box-primary border border-dark rounded">
                    <div class="box-body">
            
                        <div class="form-group">
                            
                            <div class="form-group">
                                <label>CONTRASEÑA ACTUAL</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtContrasenaActual" runat="server" Text="" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            </div> 
                            <div>
                                <label>NUEVA CONTRASEÑA</label>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtContrasenaNueva" runat="server" Text="" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>CONFIRME NUEVA CONTRASEÑA</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtConfirmacionContrasena" runat="server" Text="" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        
        </div>
        
        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnCambiarContrasena" runat="server" CssClass="btn btn-primary" Width="200px" Text="Cambiar Contraseña" OnClientClick ="botonConfirmar()"/>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClientClick ="botonConfirmar()" />
                    </td>
                </tr>
            </table>
        </div>

        <script language="javascript">

                        
    
    </script>
</section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
