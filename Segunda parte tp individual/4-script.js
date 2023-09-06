const endpoint = 'https://cataas.com/';

function actualizarTarjeta(event, numero){

    event.preventDefault();
    let titulo = document.getElementById(`tituloTarjeta${numero}`).value;
    document.getElementById(`cardt${numero}`).innerHTML = titulo;
    document.getElementById(`cardte${numero}`).innerHTML = document.getElementById(`descripcionTarjeta${numero}`).value;
    var titSinEspacios = titulo.split(' ').join('');
    fetch(`${endpoint}cat/says/${titSinEspacios}?json=true`)
    .then(response => response.json())
    .then(data => {
        const { url } = data;
        console.log(url);
        document.getElementById(`img${numero}`).src = `${endpoint}${url}`;
    });
    document.getElementById(`li${numero}`).innerHTML = titulo;
    document.getElementById(`tituloTarjeta${numero}`).value = '';
    document.getElementById(`descripcionTarjeta${numero}`).value = '';
}