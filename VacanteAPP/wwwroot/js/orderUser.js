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


        ]
    });

    return datatable;
}
