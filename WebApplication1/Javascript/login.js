function Login() {
    var uri = '/Inicio/Login';
    var sesion = {};
    sesion = cargarSesion(sesion);
    $.ajax({
        url: uri,
        data: JSON.stringify(sesion),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function cargarSesion(sesion) {
    sesion.Nick = document.getElementById("exampleInputEmail2").value;
    sesion.Pass = document.getElementById("exampleInputPassword2").value;
    return sesion;
}

function exito() {
    window.location.replace("/Inicio/Inicio");
}