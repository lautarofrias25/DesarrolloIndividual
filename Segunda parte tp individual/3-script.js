
function realizarAlerta() {
    //prevent the default behavior of the form on sumbit
    let nombre = document.getElementById('name').value;
    let apellido = document.getElementById('lastname').value;
    alert(`Usted ingreso a la persona:\nNombre: ${nombre}\nApellido: ${apellido}`);
    }

