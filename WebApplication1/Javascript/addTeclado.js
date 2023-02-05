let $mensaje = document.querySelector('#mensaje');

function Enviar() {
    var uri = '/Teclado/addTeclado';
    var teclado = {};
    teclado = cargarTeclado(teclado);
    $.ajax({
        url: uri,
        data: JSON.stringify(teclado),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function cargarTeclado(teclado) {
    teclado.Nombre = document.getElementById("nombre").value;
    teclado.Designer = document.getElementById("designer").value;
    teclado.Switch = document.getElementById("switch").value;
    teclado.Keycaps = document.getElementById("keycaps").value;
    teclado.Precio = document.getElementById("precio").value;
    teclado.Imagen = document.getElementById("imagen").value;
    teclado.Descripcion = document.getElementById("descripcion").value;
    if (document.getElementById('hotswap').checked)
        teclado.Formatouno = document.getElementById("hotswap").value;
    if (document.getElementById('qmk').checked)
        teclado.Formatodos = document.getElementById("qmk").value;
    if (document.getElementById('via').checked)
        teclado.Formatotres = document.getElementById("via").value;
    if (document.getElementById("rgb").checked)
        teclado.Estado = document.getElementById("rgb").value;
    return teclado;
}

function exito(data) {
    $mensaje.textContent = data;
}