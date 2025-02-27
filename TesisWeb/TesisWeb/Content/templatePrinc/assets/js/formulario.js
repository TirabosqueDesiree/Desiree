﻿const formulario = documento.getElementById('formulario');
const inputs = document.querySelectorAll('#formulario input');

const expresiones = {
    usuario: / ^ [ a-zA-Z0-9 \ _ \ - ] { 4,16 } $ /,  // Letras, numeros, guion y guion_bajo
    nombre: / ^ [ a-zA-ZÀ-ÿ \ s ] { 1,40 } $ /,  // Letras y espacios, pueden llevar acentos.
    contraseña: / ^ . { 4,12 } $ /,  // 4 a 12 dígitos.
    correo: / ^ [ a-zA-Z0-9 _. + - ] + @ [ a-zA-Z0-9- ] + \. [ a-zA-Z0-9-. ] + $ /,
    telefono: / ^ \ d { 7,14 } $ /  // 7 a 14 numeros.
}