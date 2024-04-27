var tabladata;
$(document).ready(function () {

    tabladata = $('#tbdata').DataTable({

        "ajax": {
            "url": "/Categoria/Obtener",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "id" },
            { "data": "descripcion" },

            {
                "data": "estado", "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success" style="color: black;">Activo</span>'
                    }
                    else {
                        return '<span class="badge badge-warning" style="color: black;">Inactivo</span>'
                    }
                },
            },
            {
                "data": "id", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onClick=' " +
                        "abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i>EDITAR</button>" +
                        "<button class='btn btn-danger btn-sm ml-2'  type='button' onClick=' " +
                        "eliminar(" + data + ")'><i class='fas fa-trash'></i>ELIMINAR</button>"

                },
                "orderable": false,
                "searchable": false,
                "width": "60px"
            }
        ]


    });

})