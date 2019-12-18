
           //$(document).ready(function(e){
          //	$("#ddlMarca").change(function () {
         //		var value = $('#ddlMarca option:selected').val();
        //		console.log(value);
       //		console.log(("#ddlMarca").val());
      //		var valor = $("ddlMarca").text();
     //		if (valor == "[NUEVA MARCA]") {
    //			$('#modalAgregarMarca').modal('show');
   //		}
  //	});
 //	e.preventDefault;		
//});

$("#ContentPlaceHolder1_ddlMarca").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlMarca option:selected").text();
	(value == "[NUEVA MARCA]") ? $("#modalAgregarMarca").modal('show') : $("#modalAgregarMarca").modal('hide')
			
});

$("#ContentPlaceHolder1_ddlSO").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlSO option:selected").text();
	(value == "[NUEVO SISTEMA OPERATIVO]") ? $("#modalAgregarSistemaOperativo").modal('show') : $("#modalAgregarSistemaOperativo").modal('hide')

});

$("#ContentPlaceHolder1_ddlModelo").change(function (e) {

	var value = $("#ContentPlaceHolder1_ddlModelo option:selected").text();
	(value == "[NUEVO MODELO]") ? $("#modalAgregarModelo").modal('show') : $("#modalAgregarModelo").modal('hide')

});


$(document).on('click', '.btn_agregarMarca', function (e) {
	e.preventDefault();
	var row = $(this).parent().parent()[0];
	data = tabla.fnGetData(row);
	fillModalData();
	console.log(data);
});