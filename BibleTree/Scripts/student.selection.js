student_selection = 0;
var student_table;


function initTable() {
    student_table = $('#student_table').DataTable({
        "dom": '<"pull-left"f><"pull-right"l>tip',
        "paging": false,
        "columnDefs": [
            {
                "targets": [ 0 ],
                "visible": false,
                "searchable": false
            }
        ],
        language: {
            searchPlaceholder: "Search Students"
        }
    });
    $('#student_table tbody').on('click', 'tr', function () {
        var data = student_table.row(this).data();
        student_selection = data[0];
        $('#student_modal').modal('hide');
        finishedStudentSelection();
    });
    student_table.columns.adjust().draw();
}

function selectStudent() {
    var url = '/Modal/StudentSearch';
    $.ajax({
        type: "GET",
        headers: {
        },
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#modal').html(data);
            initTable();
        }
    });
}