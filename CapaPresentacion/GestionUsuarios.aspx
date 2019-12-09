<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="CapaPresentacion.GestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <br />
        <h2 style="text-align: center">REGISTRO DE USUARIOS</h2>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <label>RUT</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRut" onkeydown="FormatoRut(this,event)" runat="server" Text="" CssClass="form-control" placeholder="Ej: 12.345.678-9"></asp:TextBox>
                            <asp:CustomValidator ID="validadorRut" runat="server" ForeColor="Red" ClientValidationFunction="validarRut" ControlToValidate="txtRut" Display="Dynamic" ErrorMessage="RUT/RUN incorrecto, ingrese nuevamente !!!!" SetFocusOnError="True"></asp:CustomValidator>
                        </div>

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
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="box box-primary">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="form-group">
                                <label>EMPRESA</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlEmpresa" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>DEPARTAMENTO</label>
                            </div>
                            <div class="form-group">
                                <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <label>USUARIO</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUsuario" runat="server" Text="" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>CONTRASEÑA</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtContrasena" runat="server" Text="" CssClass="form-control" type="password" placeholder="Password"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="box-body">
                    <div class="box ">
                        <div class="form-group" align="center">
                            <label>PERFIL</label>
                        </div>
                        <div class="form-group">
                            <asp:RadioButtonList ID="rblPerfil" runat="server" RepeatDirection="Horizontal" align="center" CellPadding="8">
                                <asp:ListItem Value="1" Selected="True">Usuario</asp:ListItem>
                                <asp:ListItem Value="2">Gerencial</asp:ListItem>
                                <asp:ListItem Value="3">Administradores de Áreas</asp:ListItem>
                                <asp:ListItem Value="4">Administrador General</asp:ListItem>
                            </asp:RadioButtonList>
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
        <br />

        <script language="javascript">

            function validarRut(source,arguments) {

                 var valor = document.getElementById("<%= txtRut.ClientID %>").value;
                 //var valor = arguments.value;
                 //window.alert(valor);
                 valor = valor.replace('.','');
                 valor = valor.replace('.','');
                 valor = valor.replace('-',''); 
		
                 var suma = 0;
                 var iterador =2;
                 var index = 0;
                 var cuerpo = valor.slice(0,-1);             
                 var digito_verificador = valor.slice(-1);        

                 for( i = (cuerpo.length - 1); i >= 0; i-- ) {

                       index = iterador*cuerpo[i];
                       suma = suma + index;
                       iterador++;

                       if(iterador > 7){
                          iterador = 2;
                       }
                  }
				
                  //window.alert(suma);
                  dvEsperado = 11 - (suma % 11);
              
                  if(digito_verificador == "K"){
              
              		    resto = 10;
              
                  }else if (digito_verificador == 0){
              
              		    resto = 11;
              
                  }else{
              
              		    resto = digito_verificador;
                  }
              
			      //window.alert(dvEsperado);
              
                  if(dvEsperado != resto) {                                                                   
                      //window.alert("Rut malo bro :/");
                      arguments.IsValid = false;
                  }else{
                      //window.alert("Rut válido amigazoooooooooooooo");
                      arguments.IsValid = true;
                  }


            }     
	           
              function FormatoRut(rut,event){
                      
                         var valor = rut.value.replace('.','');
                              valor = valor.replace('.','');
                              valor = valor.replace('-',''); // rut sin puntos ni guion.
                      
                              var cuerpo = valor.slice(0,-1);
                              var digito_verificador = valor.slice(-1);

                              var primera_parte;
                              var segunda_parte;
                              var tercera_parte;
                              var rut_salida;

                              if (valor.length == 9) {

                                  primera_parte = valor.substring(0,2);
                                  segunda_parte = valor.substring(2,5);
                                  tercera_parte = valor.substring(5,8);

                              }else if(valor.length == 8){

                                   primera_parte = valor.substring(0,1);
                                   segunda_parte = valor.substring(1,4);
                                   tercera_parte = valor.substring(4,7);

                              }

                              rut_salida = primera_parte + '.' + segunda_parte + '.' + tercera_parte + '-' + digito_verificador;

                              if(event.keyCode == 9){          
                          
                                    if(rut_salida.length == 11 || rut_salida.length == 12){

                                            rut.value = rut_salida;
                                            /*var valido = validarRut();

                                            if(!valido){

                                               Window.alert('Estimado@, ha ingresado un rut inválido, por favor intente nuevamente !!!!');

                                            }
                                            */
                                    }
                              }
              }
    
    </script>
</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
