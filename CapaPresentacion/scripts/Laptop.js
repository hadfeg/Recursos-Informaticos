
$(document).ready(function(){

	$(".<%= ddlMarca.ClientID %>").on("change",function(e) {
		
		var valor = $(".<%= ddlMarca.ClientID %> option:selected").text();

		if (valor == "[NUEVA MARCA]")
		{	
			$('#modalAgregarMarca').modal('show');
		}

		e.preventDefault();
	});	
});

