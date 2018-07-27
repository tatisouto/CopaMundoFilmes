//$(document).ready(function () {

//    $('input[name="ckfilme"]').click(function () {
//        selecionado('ckfilme');
//    });
//    var selecionado = function (grupo) {
//        var result = $('input[name="' + grupo + '"]:checked');
//        if (result.length > 0) {
//            var contador = result.length + " selecionado(s)<br/>";
//            result.each(function () {
//                contador += $(this).val() + " "
//            });
//            $('#divFiltros').html(contador);
//        }
//        else {
//            $('#divFiltros').html("Nenhum selecionado");
//        }
//    };
//});

$('input[type=checkbox]').on('change', function () {
    var total = $('input[type=checkbox]:checked').length;

    if (total <= 32) {
        $('#divFiltros').html(total + " de 32");
        return true;
    }
    
           
});



$('#btnGerar').on('click', function () {
    lstIdFilmes = [];
    $("input[type='checkbox']:checked").each(function () {
        lstIdFilmes.push($(this).prop('id'));
    });
    console.log(lstIdFilmes.join(', '));
    
    $.ajax({
        type: "POST",
        url: "Home/GerarCampeonato",
        data: { 'lstIdFilmes': lstIdFilmes },
        success: function (data) {
            console.log(data);
        }
        
    });
});