$("#ContentPlaceHolder1_ddlEmpresa").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlEmpresa option:selected").text();

	if (value == "[NUEVA EMPRESA]") {
		e.preventDefault();
		$("#modalAgregarEmpresa").modal('show');
	}else {
		$("#modalAgregarEmpresa").modal('hide');
	}

});

$("#ContentPlaceHolder1_ddlDepartamento").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlDepartamento option:selected").text();

	if (value == "[NUEVO DEPARTAMENTO]") {
		e.preventDefault();
		$("#modalAgregarDepartamento").modal('show');
	} else {
		$("#modalAgregarDepartamento").modal('hide');
	}
});

$("#btn_agregarEmpresaModal").click(function (e){

	añadirEmpresa();

});

function añadirEmpresa() {

	var res = validarEmpresa();
	if (res == false) { alert("Estimad@, por favor rellene los campos solicitados !!!"); return false; }
	var obj = JSON.stringify({ nombreEmpresa: $("#ContentPlaceHolder1_txtNombreEmpresaModal").val()});

	$.ajax({
		type: "POST",
		url: "GestionUsuarios.aspx/AgregarEmpresa",
		contentType: "application/json;charset=utf-8",
		data: obj,
		dataType: "json",
		success: function (response) {
			alert("Registro insertado de manera correcta.");
			window.location.reload();
		},
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
		} 
	});
}

function validarEmpresa() {

	var nombre = $("#ContentPlaceHolder1_txtNombreEmpresaModal").val();
	if (nombre.trim() != "") {	
		return true;
	}
	alert("Estimad@, llene el formulario por favor !!!!");
	return false;
}

$("#btn_agregarDepartamentoModal").click(function (e) {

	añadirDepartamento();

});

function añadirDepartamento() {

	var res = validarDepartamento();
	if (res == false) { alert("Estimad@, por favor rellene los campos solicitados !!!"); return false; }
	var obj = JSON.stringify({ nombreDepartamento: $("#ContentPlaceHolder1_txtNombreDepartamentoModal").val() });

	$.ajax({
		type: "POST",
		url: "GestionUsuarios.aspx/AgregarDepartamento",
		contentType: "application/json;charset=utf-8",
		data: obj,
		dataType: "json",
		success: function (response) {
			alert("Registro insertado de manera correcta.");
			window.location.reload();
		},
		error: function (xhr, ajaxOptions, thrownError) {
			console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
		}
	});
}

function validarDepartamento() {

	var nombre = $("#ContentPlaceHolder1_txtNombreDepartamentoModal").val();
	if (nombre.trim() != "") {
		return true;
	}
	alert("Estimad@, llene el formulario por favor !!!!");
	return false;
}