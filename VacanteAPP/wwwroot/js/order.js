$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tableData').DataTable({
        "ajax": {
            "url": '/Admin/Order/GetAll',
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "paymentStatus", "width": "15%" },
            { "data": "trackingNumber", "width": "15%" },
            { "data": "carrier", "width": "15%" },
            { "data": "telefon", "width": "15%" },
            { "data": "adresa", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "state", "width": "15%" },
            { "data": "codPostal", "width": "15%" },
            { "data": "name", "width": "15%" },
            {
                "data": null,
                "width": "15%",
                "render": function (data, type, row) {
                    var deleteUrl = '/Admin/Order/Delete?ID=' + data.id;
                    var editUrl = '/Admin/Order/Details?ID=' + data.id;
                    return '<button type="button" class="btn btn-danger mt-2 mb-2">' +
                        '<a asp-action="Details"' + deleteUrl + '" class="text-light">Sterge</a>' +
                        '</button>' +
                        '<button type="button" class="btn btn-secondary mt-2 mb-2">' +
                        '<a href="' + editUrl + '" class="text-light">Editeaza</a>' +
                        '</button>';
                }


            }
        ]
    });

    return datatable;
}
