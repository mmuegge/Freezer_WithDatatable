var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/foods/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": true,
                "searchable": true,
            },
            {
                "targets": [1],
                "visible": true,
                "searchable": false,
            },
            {
                "targets": [2],
                "visible": true,
                "searchable": true,
                "render": function (data) {
                    return moment(data).format('DD.MM.YYYY')
                },
            },
            {
                "targets": [3],
                "visible": true,
                "searchable": true,
                "render": function (data) {
                    return moment(data).format('DD.MM.YYYY')
                },
            },
             {
                "targets": [4],
                "visible": true,
                "searchable": true,
            }, {
                "targets": [5],
                "visible": true,
                "searchable": true,
            },
        ],
        "columns": [
            { "data": "name", "width": "12%", "title": "Was" },
            { "data": "amount", "width": "3%", "title": "Menge"},
            { "data": "dateIn", "width": "3%", "title": "Wann"},
            { "data": "bestBeforeDate", "width": "3%", "title": "Haltbar"},
            { "data": "foodGroup.name", "width": "6%", "title": "Gruppe"},
            { "data": "foodSupplier.name", "width": "3%", "title": "Gekauft"},
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Foods/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                            Ändern
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;'
                            onclick=Delete('/foods/Delete?id='+${data})>
                            Löschen
                        </a>
                        </div>`;
                }, "width":"16%"
            }
        ],
        "language": {
            "info": "Datensatz _START_ - _END_ von _TOTAL_ Datensätze",
            "infoEmpty": "Anzeige 0 - 0 von 0 Einträgen",
            "lengthMenu": "Anzeige _MENU_ Datensätze",
            "emptyTable": "keine Daten gefunden",
            "loadingRecords": "Laden...",
            "search": "Suchen",
            "paginate": {
                "first": "Erster",
                "last": "Letzter",
                "next": "-->",
                "previous": "<--"
             }
        },
        "width": "100%"
    })
}

function Delete(url) {
    swal({
        title: "Sind Sie sicher?",
        text: "Löschen kann nicht rückgängig gemacht werden!",
        icon: "warning",
        buttons: true,
        buttons: ['Abbrechen', 'Löschen'],
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
     });
}



