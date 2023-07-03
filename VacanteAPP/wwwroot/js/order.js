$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#tableData').DataTable({
        "ajax": {
            "url": '/Admin/VacanteStandard/GetAll',
        },
        "columns": [
            { "data": "vacantaId", "width": "15%" },
            { "data": "nameLastMinute", "width": "15%" },
            { "data": "displayOrder", "width": "15%" },
            { "data": "lastMinuteDate", "width": "15%" },
            { "data": "oras", "width": "15%" },
            { "data": "pret", "width": "15%" },
            { "data": "descriere", "width": "15%" },
            { "data": "countries.countryName", "width": "15%" },
            { "data": "url", "width": "15%" },
            {
                "data": null,
                "width": "15%",
                "render": function (data, type, row) {
                    var deleteUrl = '/Admin/VacanteStandard/Delete?VacantaId=' + data.vacantaId;
                    var editUrl = '/Admin/VacanteStandard/Edit?VacantaId=' + data.vacantaId;
                    return '<button type="button" class="btn btn-danger mt-2 mb-2">' +
                        '<a href="' + deleteUrl + '" class="text-light">Sterge</a>' +
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
