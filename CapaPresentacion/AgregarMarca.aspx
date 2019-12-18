<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Inherits="CapaPresentacion.AgregarMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <section>
        <br/>
        <h2 style="text-align: center">AGREGAR MARCA DE PC</h2>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group">
                            <label>NOMBRE MARCA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtMarca" runat="server" Text="" CssClass="form-control" placeholder="Ej: María"></asp:TextBox> 
                        </div>

                        <div align="center">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Agregar" OnClick="btnActualizar_Click" OnClientClick ="botonConfirmar()"/>
                                    </td>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btn_Cancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Volver" OnClick="btn_Cancelar_Click" OnClientClick ="botonConfirmar()" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                                           
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script>
         function botonConfirmar(){
             return confirm("¿Quiere confirmar la accion anterior?")
         }
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
