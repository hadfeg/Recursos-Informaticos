
//$("#ContentPlaceHolder1_ddlMarca").change(function (e) {

//	var value = $("#ContentPlaceHolder1_ddlMarca option:selected").text();
//	(value == "[NUEVA MARCA]") ? $("#modalAgregarMarca").modal('show') : $("#modalAgregarMarca").modal('hide')
			
//});

$("#ContentPlaceHolder1_ddlSO").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlSO option:selected").text();
	(value == "[NUEVO SISTEMA OPERATIVO]") ? $("#modalAgregarSistemaOperativo").modal('show') : $("#modalAgregarSistemaOperativo").modal('hide')
	
});

$("#ContentPlaceHolder1_ddlModelo").change(function(e){

	var value = $("#ContentPlaceHolder1_ddlModelo option:selected").text();
	(value == "[NUEVO MODELO]") ? $("#modalAgregarModelo").modal('show') : $("#modalAgregarModelo").modal('hide')

});

$("#btn_agregarMarca").click(function (){

	añadirMarca();
	//console.log(nombre);
});

$("#btn_agregarSO").click(function () {

	añadirSistemaOperativo();
	//console.log(nombre);
});

$("#btn_agregarModelo").click(function () {

	añadirModelo();
	//console.log(nombre);
});

$("#btn_nuevaMarca").click(function (e) {

	e.preventDefault();
	$('#modalAgregarMarca').modal('show');

});


//$(document).on('click','.btn_nuevaMarca',function(e) {
//	e.preventDefault();
//	$('#modalAgregarMarca').modal('show');
//});

function añadirMarca() {

	var res = validate();
	if (res == false) { return false; }

	var obj = JSON.stringify({ marca: $("#ContentPlaceHolder1_txtNombreMarca").val() });
	
	$.ajax({
		type: "POST",
		url: "GestionLaptop.aspx/AgregarMarca",
		contentType: "application/json;charset=utf-8",
		data: obj,
		dataType:"json",
		success: function (response) {
			alert("Registro insertado de manera correcta.");
			//window.location.reload();
		},
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
		}
	}); 
}

function añadirSistemaOperativo() {

	var res = validateOS();
	if (res == false) { alert("Estimad@, por favor rellene los campos solicitados !!!");return false; }

	var obj = JSON.stringify({ nombre: $("#ContentPlaceHolder1_txtNombreSistOpModal").val(), version: $("#ContentPlaceHolder1_txtVersionModal").val(), sp: $("#ContentPlaceHolder1_txtServicePackModal").val(), suscripcion: $("#ContentPlaceHolder1_txtSuscripcion").val()});

	$.ajax({
		type: "POST",
		url: "GestionLaptop.aspx/AgregarSistemaOperativo",
		contentType: "application/json;charset=utf-8",
		data: obj,
		dataType: "json",
		success: function (response) {
			alert("Registro insertado de manera correcta.");
			
		},
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
		}
	});
}

//function llenarSistemasOperativos(){

//	$.ajax({
//		type: "POST",
//		url: "GestionLaptop.aspx/ListarSistemasOperativosWeb",
//		contentType: "application/json;charset=utf-8",
//		success: function (response) {
//			alert("yes bruh.");

//		},
//		error: function (xhr, ajaxOptions, thrownError) {
//			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
//		}
//	});

//}

function añadirModelo() {

	var res = validateModel();
	if (res == false) { alert("Estimad@, por favor rellene los campos solicitados !!!"); return false; }

	var obj = JSON.stringify({ modelo: $("#ContentPlaceHolder1_txtNombreModeloModal").val(), marca:$("#ContentPlaceHolder1_ddlModeloMarcaModal option:selected").val() });

	$.ajax({
		type: "POST",
		url: "GestionLaptop.aspx/AgregarModelo",
		contentType: "application/json;charset=utf-8",
		data: obj,
		dataType: "json",
		success: function (response) {
			alert("Registro insertado de manera correcta.");
			//window.location.reload();
		},
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
		}
	});
}

function validate() {
	var isValid = true;
	if ($("#ContentPlaceHolder1_txtNombreMarca").val().trim() == "") {
		isValid = false;
	}
	return isValid;
} 

function validateModel() {
	var isValid = true;
	if ($("#ContentPlaceHolder1_txtNombreModeloModal").val().trim() == "" || $("#ContentPlaceHolder1_ddlModeloMarcaModal option:selected").text() == "" ) {
		isValid = false;
	}
	return isValid;
}  

function validateOS() {
	var isValid = true;
	if ($("#ContentPlaceHolder1_txtNombreSistOpModal").val().trim() == "" || $("#ContentPlaceHolder1_txtVersionModal").val().trim() == "") {
		isValid = false;
	}
	return isValid;
}  