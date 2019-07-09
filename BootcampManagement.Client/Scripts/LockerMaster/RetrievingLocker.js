$(document).ready(function () {
    $('#table').DataTable({
        "ajax": LoadIndexLocker()
    })
})

function LoadIndexLocker() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Lockers/LoadLocker/",
        dateType: "json",
        success: function (data) {
            var html = '';
            var i = 1;
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + i + '</td>';
                html += '<td>' + val.LockerNumber + '</td>';
                html += '<td> <a href="#" class="fa fa-pencil" onclick="return GetById(' + val.Id + ')"></a>';
                html += ' | <a href="#" class="fa fa-trash" onclick="return Delete(' + val.Id + ')"></a></td>';
                html += '</tr>';
                i++;
            });
            $('.tbody').html(html);
        }
    });
}

function Save() {
    debugger;
    var locker = new Object();
    locker.LockerNumber = $('#LockerNumber').val();
    $.ajax({
        url: '/Lockers/InsertOrUpdate/',
        data: locker,
        success: function (result) {
            console.log(result);
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexLocker();
            ClearScreen();
        }
    });
}

function Edit() {
    var department = new Object();
    department.id = $('#LockerNumber').val();
    department.LockerName = $('#LockerNumber').val();
    $.ajax({
        url: '/Lockers/InsertOrUpdate/',
        data: LockerVM,
        type: "PUT",
        success: function (result) {
            swal({
                title: "Saved!",
                text: "That data has been save!",
                type: "success"
            },
                function () {
                    $('#myModal').modal('hide');
                });
            LoadIndexLocker();
            ClearScreen();
        }
    });
}

function GetById(Id) {
    debugger;
    $.ajax({
        url: '/Lockers/GetById/',
        data: { id: Id },
        type: "GET",
        dataType: "json",
        success: function (result) {
            console.log(result);
            $('#LockerNumber').val(result.LockerNumber);
			$('#Id').val(result.Id);

            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    })
}

function Delete(Id) {
    swal({
        title: "Are you sure?",
        text: "You will not be able to recover this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: '/Lockers/Delete/',
            data: { id: Id },
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                    function () {
                        LoadIndexLocker();
                    });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the server!", "error");
            }
        });
    });
}

function ClearScreen() {
    $('#LockerName').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}

function Validate() {
    debugger;
    if ($('#LockerName').val() == "" || $('#LockerName').val() == " ") {
        swal("Oops", "Please Insert LockerName", "error")
    } else if ($('#Id').val() == "") {
        Save();
    } else {
        Edit();
    }
}