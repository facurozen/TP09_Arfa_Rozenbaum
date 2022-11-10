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
                    $("#CantidadLikes_"+IdP).html("&nbsp;"+response);
                }
        }
    )
}

function escribirComentario(IdP){
    $("#IdPelicula").val(IdP);
}

function mostrarComentario(IdP) {
    $.ajax(
        {
            type: 'POST',
            dataType: 'JSON',
            url: '/Home/mostrarComentario',
            data: { IdPelicula: IdP },
            success:
                function (response) {
                    response.forEach(element => {
                        $("#Texto")+="<p>"+(element.texto)+"</p>";
                    });
                }
        }
    )
}

