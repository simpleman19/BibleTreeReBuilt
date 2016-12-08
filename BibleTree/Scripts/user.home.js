
function editBadgeGetId() {
    selectBadge();
}

function editBadge(id) {
    var url = '/badges/badgeedit/' + id;

    id_to_change = '.tabbing';
    $(id_to_change).css({ "background-color": "white" });
    id_to_change = '#buttonEditBadge';
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
    $(id_to_change).css({ "background-color": "lightgrey" });
}

function badgeDetail(id) {
    last_selection = 2;
    var url = '/badges/badgeview/' + id;
    id_to_change = '.tabbing';
    $(id_to_change).css({ "background-color": "white" });
    id_to_change = '#buttonListBadges';

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
    $(id_to_change).css({ "background-color": "lightgrey" });
    last_selection = -1;
}

function changeView(url, button) {

    id_to_change = '.tabbing';
    $(id_to_change).css({ "background-color": "white" });

    id_to_change = button;
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
    $(id_to_change).css({ "background-color": "lightgrey" });
}

function createBadge() {
    var button = "#buttonCreateBadge";
    var url = '/badges/badgecreate';
    changeView(url, button);
}

function badgeTree() {
    var button = "#buttonBadgeTree";
    var url = '/badges/badgetree';
    changeView(url, button);
}

function badgeTree(id) {
    var button = "#buttonBadgeTree";
    var url = '/badges/badgetree/'+id;
    changeView(url, button);
}

function listBadges() {
    var button = "#buttonListBadges";
    var url = '/badges/badgelist';
    changeView(url, button);
}

function listStudentBadges() {
    var button = "#buttonListBadges";
    var url = '/badges/studentbadges/1';
    changeView(url, button);
}

function sendBadge() {
    var button = "#buttonSendBadge";
    var url = '/Badges/SendBadge';
    changeView(url, button);
}

function studentList() {
    var button = "#buttonListStudents";
    var url = '/user/studentlist';
    changeView(url, button);
}

function facultyList() {
    var button = "#buttonListFaculty";
    var url = '/user/facultylist';
    changeView(url, button);
}

function studentDetail(id) {
    var button = "#buttonListStudents";
    var url = '/user/studentdetails/'+id;
    changeView(url, button);
}