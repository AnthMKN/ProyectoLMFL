let t = 0.0;
let $carro = document.querySelector('#carro');
let $t = document.querySelector('#t');
let carro;

if (localStorage.carrito !== undefined)
    carro = JSON.parse(localStorage.carrito);
if (carro === undefined)
    carro = []
else {
    renderizarCarro(carro);
    calcularT(carro);
}

function calcularT(carro) {
    t = 0;
    for (let miItem of carro) {
        t = t + parseFloat(miItem[0]['Precio']);
    }
    $t.textContent = t.toFixed(2);
}


function renderizarCarro(carro) {
    $carro.textContent = '';
    var indice = 0;
    for (let miItem of carro) {
        let miNodo = document.createElement('li');
        miNodo.classList.add('list-group-item', 'text-right');
        miNodo.textContent = `${miItem[0]['Nombre']} - ${miItem[0]['Precio']}€`
        let miBoton = document.createElement('button');
        miBoton.classList.add('btn', 'btn-danger', 'mx-5');
        miBoton.textContent = 'X';
        miBoton.setAttribute('posicion', indice);
        indice = indice + 1;
        miBoton.addEventListener('click', borrarItemCarro);
        miNodo.appendChild(miBoton);
        $carro.appendChild(miNodo);
    }
}

function borrarItemCarro() {
    carro.splice(this.getAttribute('posicion'), 1);
    localStorage.removeItem("carrito");
    localStorage.carrito = JSON.stringify(carro);
    renderizarCarro(carro);
    calcularT(carro);
}