var hdnPath = $("#hdnAppPath").val();

function OpenAttendeeModal(AttendeeId = 0) {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        url: hdnPath + "Home/_AddEditAttendee",
        cache: false,
        type: "POST",
        data: { Id: AttendeeId },
        success: function (returndata) {
            $("#AddEditModal").html(returndata);
            $("#AddEditModal").modal('show');
        },
        fail: function (xhr, status, error) {
        }
    });
}

function SaveAttendeeForTestDetails() {

    $("#lblValidation").css("display", "none");
    var bFlag = true;
    if ($("#UserId").val() === '') {
        $("#lblValidation").css("display", "block");
        bFlag = false;
        return false;
    }
    if ($("#TestAttributeValue").val() === '') {
        $("#lblValidation").css("display", "block");
        bFlag = false;
        return false;
    }
    if (bFlag) {
        $.ajax({
            xhrFields: {
                withCredentials: true
            },
            url: hdnPath + "/Home/SaveAttendeeForTest",
            cache: false,
            type: "POST",
            data: { Id: $("#hdnAttendeId").val(), AthleteTestId: $("#hdnTestId").val(), UserId: $("#UserId").val(), TestAttributeValue: $("#TestAttributeValue").val(), IsActive: true },
            success: function (returndata) {
                if (returndata) {
                    window.location.href = "https://localhost:44378/Home/TestAttendees?Id=" + $("#hdnTestId").val();
                }
            },
            fail: function (xhr, status, error) {
            }
        });
    }

    //return bFlag;
}

function DeleteAttendeeDetails(Id) {
    if (confirm("Are you Sure you want to delete Attendee ?")) {
        $.ajax({
            url: hdnPath + "Home/DeleteAttendeeDetails",
            cache: false,
            type: "POST",
            data: { Id: Id },
            success: function (returndata) {
                if (returndata) {
                    window.location.href = hdnPath + "Home/TestAttendees?Id=" + $("#hdnTestId").val();
                }
            },
            fail: function (xhr, status, error) {
            }
        });
    }
}
