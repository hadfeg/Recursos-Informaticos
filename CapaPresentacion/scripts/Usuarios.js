function templateRow() {
    var template = "<tr>";
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "Jorge Junior" + "</td>");
    template += ("<td>" + "Rodriguez Castillo" + "</td>");
    template += ("<td>" + "123" + "</td>");
    template += ("<td>" + "123" + "</td>");
    return template;
}

function addRow() {
    var template = templateRow();
    for (var i = 0; i < 5; i++) {
        $("#tbl_body_table").append(template);
    }
}

var data, tabla;

function addRowDT(data) {
    tabla = $('#tbl_usuarios').dataTable();    
    for (var i = 0; data.length; i++) {
        tabla.fnAddData([
            data[i].Rut,
            data[i].Name,
            data[i].LastName,
            data[i].Mail,
            data[i].Departamento,
            data[i].Empresa,            
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodalActualizar" data-toggle="modal"><i class="fas fa-check-square"></i></i></button>&nbsp;' +
            '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fas fa-minus-circle"></i></i></button>',
        ]);            
    }
}
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "ListadoUsuario.aspx/ListarUsuario",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            console.log(data);
            addRowDT(data.d);
        }
    });
}
function deleteDataAjax(data) {
    var obj = JSON.stringify({ id: JSON.stringify(data) });
    $.ajax({
        type: "POST",
        url: "ListadoUsuario.aspx/EliminarUsuarioLogico",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response.d) {
                alert("Registro eliminado de manera correcta.");
            } else {
                alert("No se pudo eliminar el registro.");
            }
        }
    });
}
//traducir el dataTable a Español
$(document).ready(function () {
    $("#tbl_usuarios").dataTable({
        "language": {
            "processing": "Procesando...",
            "lengthMenu": "_MENU_ Registros por página",
            "search": " Buscar: ",
            "emptyTable": "Ningún dato disponible en esta tabla",
            "zeroRecords": "No se encontraron resultados",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtered from _MAX_ total records)",
            "infoPostFix": "",
            "url": "",
            "infoThousands": ",",
            "loadingRecords": "Cargando...",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });
});

// cargar datos en el modal
function fillModalData() {
    $("#txtRutModal").val(data[0]);
    $("#txtNombreModal").val(data[1]);
    $("#txtApellidosModal").val(data[2]);    
    $("#txtCorreoModal").val(data[3])
    //$("#txtPassModal").val(data[5]);
}

// evento click para boton actualizar
$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    var row = $(this).parent().parent()[0];
    data = tabla.fnGetData(row);
    fillModalData();
    console.log(data);
});

// evento click para boton eliminar
$(document).on('click', '.btn-delete', function (e) {
    e.preventDefault();
    //primer método: eliminar la fila del datatble
    var row = $(this).parent().parent()[0];
    var dataRow = tabla.fnGetData(row);
    //segundo método: enviar el codigo del usuario al servidor y eliminarlo, renderizar el datatable
    // paso 1: enviar el id al servidor por medio de ajax
    deleteDataAjax(dataRow[0]);
    // paso 2: renderizar el datatable
    deleteDataAjax(data)
});


// Llamando a la funcion de ajax al cargar el documento
sendDataAjax();