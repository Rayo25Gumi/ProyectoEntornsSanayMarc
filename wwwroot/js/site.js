window.onload = function () {
    RightClicado(); // Activa el sonido al hacer clic derecho
    let boton = document.querySelector("#instruciones"); // Busca el botón de instrucciones
    boton.addEventListener('click', generarInstruciones); // Si se hace clic, genera las instrucciones
};

function RightClicado() {
    let audio = new Audio('/attachments/miau.mp3'); // Carga el audio del maullido

    document.addEventListener('contextmenu', function(event) {
        event.preventDefault(); // Evita que se abra el menú del clic derecho
        audio.play(); // Reproduce el maullido
    });
}

function generarInstruciones() {
    var button = document.getElementById("instruciones"); // Busca el botón
    button.disabled = true; // Desactiva el botón después de clicarlo

    let contenedorTarjeta = document.querySelector('#container'); // Busca el contenedor lateral

    let tarjeta = document.createElement('div'); // Crea un nuevo div
    tarjeta.classList.add('nota'); // Le aplica la clase con fondo de nota
    contenedorTarjeta.append(tarjeta); // Lo mete dentro del contenedor

    let hint = document.createElement('p'); // Crea un párrafo
    hint.classList.add('textnota'); // Le aplica estilo
    hint.id = 'hint'; // Le pone un ID
    hint.innerHTML = `Right click to meow!`; // Le pone el texto
    tarjeta.append(hint); // Añade el texto a la nota
}