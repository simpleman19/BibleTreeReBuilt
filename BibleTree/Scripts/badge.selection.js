badge_selection = 0;
badge_name = "";
var badge_table;


function initBadgeTable() {
    badge_table = $('#badge_table').DataTable({
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
            searchPlaceholder: "Search Badges"
        }
    });
    $('#badge_table tbody').on('click', 'tr', function () {
        var data = badge_table.row(this).data();
        badge_selection = data[0];
        badge_name = data[1];
        $('#badge_modal').modal('hide');
        finishedBadgeSelection();
    });
    badge_table.columns.adjust().draw();
}

function selectBadge() {
    var url = '/Modal/BadgeSearch';
    $.ajax({
        type: "GET",
        headers: {
        },
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#modal').html(data);
            initBadgeTable();
        }
    });
}