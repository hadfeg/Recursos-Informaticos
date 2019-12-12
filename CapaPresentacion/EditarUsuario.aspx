<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <section>
        <br/>
        <h2 style="text-align: center">ACTUALIZACIÓN DE DATOS</h2>
    </section>
    <section class="content">

        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>NOMBRES</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNombre" runat="server" Text="" CssClass="form-control" placeholder="Ej: María"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>APELLIDOS</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtApellido" runat="server" Text="" CssClass="form-control" placeholder="Ej: Fernández"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>E-MAIL</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" placeholder="Ej: nombre@gmail.cl"></asp:TextBox>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ErrorMessage="Correo inválido"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" ErrorMessage="Campo Obligatorio"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                                <label>EMPRESA</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="form-control">

                                    <asp:ListItem Text="Sin Empresa" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Inversiones Farias" Value="2"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>DEPARTAMENTO</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlDepto" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Contraloría" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Recursos Humanos" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Finanzas" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Contabilidad" Value="4"></asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        
                            <div>
                                <label>NOMBRE DE USUARIO</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtUsuario" runat="server" Text="" CssClass="form-control" placeholder="Ej: AFARIAS"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>CONTRASEÑA</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtContrasena" runat="server" Text="" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>CONFIRMAR CONTRASEÑA</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtContrasena2" runat="server" Text="" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                            </div>  
                            
                            <asp:CustomValidator ID="validadorContrasenas" runat="server" ForeColor="Red" ClientValidationFunction="validarContrasenas" ControlToValidate="txtContrasena2" Display="Dynamic" ErrorMessage="Estimad@, las contraseñas no coinciden, intente nuevamente!!!!" SetFocusOnError="True"></asp:CustomValidator>
                        <br />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">

                        <div class="form-group" align = "center">
                            <label>IMAGEN</label>
                        </div>
                        <div class="form-group" align ="center">
                            <asp:Image ID="UsrImg_Update" runat="server" Height="450px" Width="300px" ImageAlign="Middle" Text="" CssClass="form-control"></asp:Image>
                        </div>
                        <div class="form-group" align ="center">
                            <asp:FileUpload ID="UsrImg_Up" Text="Cambiar Imagen" runat="server" width="400px" CssClass ="form-control"/>
                        </div>    
                        <asp:Label ID ="LabUpdateImg" runat="server"></asp:Label>

                     </div>
                 </div>
               </div>               
           </div>

        <div align="center">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Actualizar" OnClick="btnActualizar_Click" OnClientClick ="botonConfirmar()"/>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btn_Cancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" OnClick="btn_Cancelar_Click" OnClientClick ="botonConfirmar()" />
                    </td>
                </tr>
            </table>
        </div>
    
        <script>

                function validarContrasenas(source,arguments){

                    var contrasena1 = document.getElementById("<%= txtContrasena.ClientID %>").value;
                    var contrasena2 = document.getElementById("<%= txtContrasena2.ClientID %>").value;
                    
                    if(contrasena2 != contrasena1){                            
                            arguments.IsValid = false;
                    }else{
                            arguments.IsValid = true;
                    }
                }

                function botonConfirmar(){
                    return confirm("¿Quiere confirmar la accion anterior?")
                }
        </script>
        
    </section>        

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
