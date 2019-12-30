<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CapaPresentacion.ResetPassword" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AdminLTE 2 | Log in</title>
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
                                <asp:TextBox ID="UserName" runat="server" type="password" class="form-control" placeholder="Contraseña Nueva"></asp:TextBox>
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                            <div class="form-group has-feedback">
                                <asp:TextBox ID="Password" runat="server" type="password" class="form-control" placeholder="Confirme Contraseña Nueva"></asp:TextBox>
                                <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                            </div>
                            <div class="row">  
                                
                                <div class="col-xs-8">
                                    <a data-toggle ="modal" href ="#modalInformacion">Más Información</a>
                                </div>

                                <div class="col-xs-4">
                                    <asp:Button ID="btnActualizar" runat="server" Text="Solicitar" class="btn btn-primary btn-block btn-flat" OnClick="btnActualizar_Click" />
                                </div>
                                <!-- /.col -->
                            </div>
                            
                        </LayoutTemplate>
                    </asp:Login>
                </div>
            </form>
        </div>
        <!-- /.login-box-body -->
    </div>

                    <div class="modal fade" id="modalError" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">

                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h3 class='col-12 modal-title text-center'>            
                                                 <img src="./PageImages/Isotipo.png" alt="Alternate Text" / style="width:40px;height:40px">                        
                                            </h3>                                       
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>

                                        <div class="modal-body">
                                                Estimad@, las contraseñas ingresadas <i><strong>no</strong></i> coinciden, intente nuevamente.
                                        </div>

                                        <div class="modal-footer">
                                            <button id="btnCerrarModalError" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>  
                        </div>  


    <div class="modal fade" id="modalInformacion" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">

                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h3 class='col-12 modal-title text-center'>            
                                                 <img src="./PageImages/Isotipo.png" alt="Alternate Text" / style="width:40px;height:40px">                        
                                            </h3>                                       
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>

                                        <div class="modal-body">
                                            <ul>
                                                <li>Contraseña Nueva: Este campo corresponse a su nueva contraseña para iniciar sesión.</li>
                                                <br/>
                                                <li>Confirme Contraseña Nueva: Este campo corresponde a la <strong><i>nueva contraseña</i></strong> ingresada en el cuadro anterior <strong><i> esta sera su nueva contraseña </i></strong> para iniciar sesión.</li>                                                  
                                            </ul>
                                        </div>

                                        <div class="modal-footer">
                                            <button id="btnCerrarModalInformacion" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div>
                                </div>  
                           </div> 


        <div class="modal fade" id="modalMensaje" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">

                                <div class="modal-dialog modal-dialog-centered" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h3 class='col-12 modal-title text-center'>            
                                                 <img src="./PageImages/Isotipo.png" alt="Alternate Text" / style="width:40px;height:40px">                        
                                            </h3>                                       
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>

                                        <div class="modal-body">
                                            Estimad@, su contraseña se ha actualizado con éxito, por favor ingrese a la plataforma para comprobar su contraseña !!                                                                                        
                                        </div>

                                        <div class="modal-footer">
                                            <button id="btnCerrarModalMensaje" type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
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

        function cambiarContraseña() {

            $.ajax

        }


        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' /* optional */
            });
        });

        $("#Login1_btnActualizar").click(function (e) {

            var contraseña = $("#Login1_UserName").val();
            var confirmacion_contraseña = $("#Login1_Password").val();

            if (contraseña == confirmacion_contraseña) {

            } else {

                $("#modalError").modal('show');
            }           
        });

        $("#modalMensaje").on('hide.bs.modal',function () {

            window.location.href = "./Login.aspx";

        });
        
    </script>

</body>
</html>

