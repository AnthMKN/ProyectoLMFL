let $items = document.querySelector('#items');
let total = 0.0;
let $carrito = document.querySelector('#carrito');
let $total = document.querySelector('#total');
let $mensaje = document.querySelector('#mensaje');
let carrito;

if (localStorage.carrito !== undefined)
    carrito = JSON.parse(localStorage.carrito);

if (carrito === undefined)
    carrito = []
else {
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function success(data) {
    anyadirCarrito(data);
    localStorage.carrito = JSON.stringify(carrito);//Revisar
}

function anyadirCarrito(dato) {
    var encontrado = false;
    if (carrito.length == 0) {
        dato[0].Cantidad = 1;
        carrito.push(dato);
    } else {
        carrito.forEach(function (element, index) {
            var codTeclado = carrito[index][0].CodTeclado;
            if (codTeclado == dato[0].CodTeclado) {
                carrito[index][0].Cantidad++;
                encontrado = true;
            }
        });
        if (!encontrado) {
            dato[0].Cantidad = 1;
            carrito.push(dato);
        }
    }
    calcularTotal(carrito);
    renderizarCarrito(carrito);
}

function calcularTotal(carrito) {
    total = 0;
    for (let miItem of carrito) {
        var cantidad = parseInt(miItem[0].Cantidad);
        total = total + parseFloat(miItem[0]['Precio'] * cantidad);
    }
    $total.textContent = total.toFixed(2);

    carro = carrito;
    calcularT(carro)
    renderizarCarro(carro);
}

function renderizarCarrito(carrito) {
    $carrito.textContent = '';
    var indice = 0;
    for (let miItem of carrito) {
        let miNodo = document.createElement('li');
        miNodo.classList.add('list-group-item', 'text-right');
        miNodo.textContent = `${miItem[0]['Cantidad']} - ${miItem[0]['Nombre']} - ${miItem[0]['Precio']}€`
        let miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger', 'mx-5');
        miBoton.textContent = 'X';
        miBoton.setAttribute('posicion', indice);
        indice = indice + 1;
        miBoton.addEventListener('click', borrarItemCarrito);
        miNodo.appendChild(miBoton);
        $carrito.appendChild(miNodo);
    }
}

function borrarItemCarrito() {
    carrito.splice(this.getAttribute('posicion'), 1);
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carrito);
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function comprar() {
    var uri = '/Teclado/comprar';
    var lineas = lineasFactura(carrito);
    $.ajax({
        url: uri,
        data: JSON.stringify(lineas),
        type: 'POST',
        success: exito,
        contentType: 'application/json'
    });
}

function vaciarCarrito() {
    //carrito = carrito.splice(0, carrito.length); Funciona
    carrito.length = 0;//borramos el carrito
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carrito);
    renderizarCarrito(carrito);
    calcularTotal(carrito);
}

function exito(data) {
    $mensaje.textContent = data;
    vaciarCarrito();
    localStorage.removeItem("carrito");
}

function lineasFactura(carrito) {
    var lineas = [];
    var lf = {};
    for (let miItem of carrito) {
        lf = {};
        lf.Teclado = miItem[0].CodTeclado;
        lf.Cantidad = miItem[0].Cantidad;
        lf.Total = miItem[0].Precio * lf.Cantidad;
        lineas.push(lf);
    }
    return lineas;
}