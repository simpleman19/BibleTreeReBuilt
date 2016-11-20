var last_selection = -1

function changeTo(number) {
    last_selection = number
    var url = '';
    if (number == 0) {
        url = '/badges/badgecreate';
    } else if (number == 1) {
        url = '/badges/badgeedit';
    } else if (number == 2) {
        url = '/badges/badgelist';
    } else if (number == 3) {
        url = '/user/studentlist';
    } else if (number == 4) {
        url = '/user/facultylist';
    }
    for (i = 0; i < 5; i++) {
        id_to_change = '#button' + i;
        $(id_to_change).css({ "background-color": "white" });
    }
    id_to_change = '#button' + number;
    $.ajax({
        type: "GET",
        headers: {
        },
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#partial_view').html(data);
        }
    });
    $(id_to_change).css({"background-color": "grey"});
}

function editBadgeGetId() {
    last_selection = 1;
    selectBadge();
}

function editBadge(id) {
    var url = '/badges/badgeedit/' + id;
    for (i = 0; i < 5; i++) {
        id_to_change = '#button' + i;
        $(id_to_change).css({ "background-color": "white" });
    }
    id_to_change = '#button' + 1;
    $.ajax({
        type: "GET",
        headers: {
        },
        url: url,
        dataType: 'html',
        success: function (data) {
            $('#partial_view').html(data);
        }
    });
    $(id_to_change).css({ "background-color": "grey" });
    last_selection = -1;
}