function changeTo(number) {
    var url = '';
    if (number == 0) {
        url = '/badges/badgetree';
    } else if (number == 1) {
        url = '/badges/badgecreate';
    } else if (number == 2) {
        url = '/badges/badgelist';
    } else if (number == 3) {
        url = '/users/userlist';
    }
    for (i = 0; i < 4; i++) {
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