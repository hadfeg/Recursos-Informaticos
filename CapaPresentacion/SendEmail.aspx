<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="CapaPresentacion.SendEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AdminLTE 2 | Password Recovery</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.7 -->
    <link rel="stylesheet" href="AdminLTE-2.4.0/bower_components/bootstrap/dist/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="AdminLTE-2.4.0/bower_components/font-awesome/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="AdminLTE-2.4.0/bower_components/Ionicons/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="AdminLTE-2.4.0/dist/css/AdminLTE.min.css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="AdminLTE-2.4.0/plugins/iCheck/square/blue.css" />
    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

</head>
<body class="hold-transition login-page">
    <div class="login-box">
        <div class="login-logo">
            <a>Farias <b>Recursos TI</b></a>
        </div>
        <!-- /.login-logo -->
        <div class="login-box-body">
            <p class="login-box-msg">Reestablecer Contraseña</p>
            <form id="form1" runat="server">
                <div class="form-group has-feedback">
                    <asp:Login ID="Login1" runat="server" EnableViewState="false" Width="100%">
                        <LayoutTemplate>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="Correo Electrónico"></asp:TextBox>
                                <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                <asp:RegularExpressionValidator runat="server" ID="validadorCorreo1" ControlToValidate="UserName" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ErrorMessage="Correo inválido"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" ForeColor="Red" Display="Dynamic" ErrorMessage="Campo Obligatorio"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="Password" runat="server" class="form-control" placeholder="Confirme Correo Electrónico"></asp:TextBox>
                                <span class="glyphicon glyphicon-user form-control-feedback"></span>
                                <asp:RegularExpressionValidator runat="server" ID="validadorCorreo2" ControlToValidate="Password" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ErrorMessage="Correo inválido"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" ForeColor="Red" Display="Dynamic" ErrorMessage="Campo Obligatorio"></asp:RequiredFieldValidator>
                            </div>                  
                            <br />
                            <div class="row">
                                <div class = "col-sm-8"></div>

                                <div class="col-xs-4">
                                    <asp:Button ID="btnIngresar" runat="server" Text="Enviar" OnclientClick ="btnIngresar_Click " OnClick="btnIngresar_Click" class="btn btn-primary btn-block btn-flat" />
                                </div>
                            </div>                     
                        </LayoutTemplate>
                    </asp:Login>
                </div>
            </form>
        </div>
        <!-- /.login-box-body -->
    </div>

    <div class="modal fade" id="modalMensaje" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">

                    <h3 class='col-12 modal-title text-center'>            
                         <img src="./PageImages/Isotipo.png" alt="Alternate Text" / style="width:40px;height:40px">                        
                    </h3>
                    
                    <button id="btnCruzCerrar" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>

                <div class="modal-body">
                    Estimad@, se ha enviado un hipervínculo a su correo electrónico, por favor ingrese al sitio e ingrese su nueva contraseña.
                </div>

                <div class="modal-footer">
                    <button id="btnCerrarModalMensaje" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalMensaje2" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">

                    <h3 class='col-12 modal-title text-center'>            
                         <img src="./PageImages/Isotipo.png" alt="Alternate Text" / style="width:40px;height:40px">                        
                    </h3>
                    
                    <button id="btnCruzCerrar2" type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>

                </div>

                <div class="modal-body">
                    Estimad@, el correo que ha ingresado no se encuentra registrado en nuestra base de datos, verifique por favor !!.
                </div>

                <div class="modal-footer">
                    <button id="btnCerrarModalMensaje2" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalError" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h3 class='col-12 modal-title text-center'>            
                         <img src="./PageImages/Cuadrado.png" alt="Alternate Text" / style="width:40px;height:40px">
                    </h3>                                       
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    Estimad@, los correos ingresados no coinciden, verifique antes de presionar el botón de envío.
                </div>

                <div class="modal-footer">
                    <button id="btnCerrarModalError" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- /.login-box -->
    <!-- jQuery 3 -->
    <script src="AdminLTE-2.4.0/bower_components/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap 3.3.7 -->
    <script src="AdminLTE-2.4.0/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="AdminLTE-2.4.0/plugins/iCheck/icheck.min.js"></script>
    <script>

        function mostrarModalError(e) {
            e.preventDefault();
            $("#modalError").modal('show');
        }

        function mostralModalMensaje(e) {
            e.preventDefault();
            $("#modalMensaje").modal('show');
        }

        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });

        function existeCorreo(varcorreo) {

            var obj = JSON.stringify({ correo: varcorreo });

            return $.ajax({
		        type: "POST",
                async: false,
		        url: "SendEmail.aspx/ExisteCorreo",
                contentType: "application/json;charset=utf-8",
                data: obj,
                dataType: "json",

		        success: function (data) {
                    return data;
                    //window.location.reload();
                },

		        error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                    return data;
		        }
	        });

        }

        function enviarCorreo(varcorreo) {
 
            var obj = JSON.stringify({ correo: varcorreo });

            $.ajax({

		        type: "POST",
		        url: "SendEmail.aspx/EnviarCorreo",
                contentType: "application/json;charset=utf-8",
                data: obj,
                dataType: "json",

		        success: function (response) {
                    //alert("Envio de correo exitoso.");
                    //window.location.reload();
                },

		        error: function (xhr, ajaxOptions, thrownError) {
			        console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
                }

	        }); 

        }

        $("#Login1_btnIngresar").click(function (e) {

            var correo = $("#Login1_UserName").val();
            var confirmacion_correo = $("#Login1_Password").val();
            var correo_expresion_regular = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;
            var correo1_valido = correo_expresion_regular.test(correo); // valida si los correos cumplen con el patrón establecido arriba.
            var correo2_valido = correo_expresion_regular.test(confirmacion_correo); // valida si los correos cumplen con el patrón establecido arriba.
            var correos_validos = correo1_valido && correo2_valido;
            var correoExiste = (existeCorreo(correo).responseJSON.d);

            //console.log(correoExiste);

            if (correo == confirmacion_correo) {
                if (correos_validos) { // Si el correo cumple con el 
                    if (correoExiste) { // Si el correo esta registrado en la base de datos
                        e.preventDefault();
                        $("#modalMensaje").modal('show');
                        enviarCorreo(correo);
                    } else {

                        e.preventDefault();
                        $("#modalMensaje2").modal('show');

                    }
                }

            } else {

                e.preventDefault();
                $("#modalError").modal('show');

            }           
        });
        
        //$("#modalMensaje").on('hide.bs.modal',function () {

        //    window.location.href = "./ResetPassword.aspx";

        //});
        
    </script>
</body>
</html>

