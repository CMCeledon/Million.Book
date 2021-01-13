// ***********************************************************************
// Assembly         : 
// Author           : cmceledon (Carlos Mario Celedón Rodelo)
// Created          : 08-16-2019
//
// Last Modified By : cmceledon (Carlos Mario Celedón Rodelo)
// Last Modified On : 08-18-2019
// ***********************************************************************
// <copyright file="" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
$(document).ready(function () {
    consultarEditoriales();
    consultarEditorialesDapper();
});

function consultarEditoriales() {
    var resultInsertEditorial = $("#resultInsertEditorial");
    resultInsertEditorial.hide();
    $.ajax({
        url: 'Editorial/ConsultarEditoriales',
        success: function (respuesta) {
            var listaEditorial = $("#carga-editoriales");
            $.each(respuesta.info, function (index, jsonData) {
                listaEditorial.append(
                    '<tr><th scope="row">' + jsonData.idEditorial + '</th><td>' + jsonData.nombre + '</td><td>' + jsonData.sede + '</td></tr>'
                );
            });
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}
function consultarEditorialesDapper() {
    var resultInsertEditorial = $("#resultInsertEditorial");
    resultInsertEditorial.hide();
    $.ajax({
        url: 'Editorial/ConsultarEditorialesByDapper',
        success: function (respuesta) {
            var listaEditorial = $("#carga-editoriales-dapper");
            var listaEditorialSelect = $("#idEditorialParam");
            $.each(respuesta.info, function (index, jsonData) {
                listaEditorial.append(
                    '<tr><th scope="row">' + jsonData.idEditorial + '</th><td>' + jsonData.nombre + '</td><td>' + jsonData.sede + '</td></tr>'
                );
                listaEditorialSelect.append(
                    '<option value=' + jsonData.idEditorial + '>' + jsonData.nombre + '</option>'
                );
            });
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}
function insertarEditorial() {
    var nombreEditorialParam = $("#nombreEditorialParam").val();
    var sedeParam = $("#sedeParam").val();
    $.ajax({
        type: "POST",
        url: 'Editorial/InsertarEditorial?nombreParam=' + nombreEditorialParam + '&sedeParam=' + sedeParam + '',
        success: function (respuesta) {
            var resultInsertEditorial = $("#resultInsertEditorial");
            resultInsertEditorial.html(
                "Inserción: " + respuesta.message
            );
            location.reload(true);
          //  consultarEditorialesDapper();
            //consultarEditoriales();
        },
        error: function () {
            console.log("No se ha podido guadar la información");
        }
    });
}