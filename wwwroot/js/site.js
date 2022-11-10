// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function darLike(IdP) {
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/DarLike',
            data: { IdPelicula: IdP },
            success:
                function (response) {
                    $("#CantidadLikes_" + IdP).html("&nbsp;" + response);
                }
        }
    )
}

function escribirComentario(IdP) {
    $.ajax({
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/escribirComentario',
            data: $('#FormEnviarComentario').serialize(),
            success:
                function(){
                    alert('Comentario enviado');
                }
        }
    )
}

function mostrarComentario(IdP) {
    $("#Texto").empty();
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/mostrarComentario',
            data: { IdPelicula: IdP },
            success:
                function (response) {
                    response.forEach(element => {
                        $("#Texto").append("<p>" + (element.texto) + "</p>");
                    });
                }
        }
    )
}

function setearIdPelicula(IdP){
    $("#iIdPelicula").val(IdP);
}

