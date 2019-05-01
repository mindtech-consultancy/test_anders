var hdnPath = $("#hdnAppPath").val();

function OpenTestModal(TestId) {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        url: hdnPath + "Home/_AddEditTest",
        cache: false,
        type: "POST",
        data: { Id: TestId !== undefined ? TestId : 0 },
        success: function (returndata) {
            $("#AddEditModal").html(returndata);
            $("#AddEditModal").modal('show');
        },
        fail: function (xhr, status, error) {
        }
    });
}

function SaveTestDetails() {
    $("#lblValidation").css("display", "none");
    var bFlag = true;
    if ($("#TestTypeId").val() === '') {
        $("#lblValidation").css("display", "block");
        bFlag = false;
        return false;
    }
    if ($("#TestDate").val() === '') {
        $("#lblValidation").css("display", "block");
        bFlag = false;
        return false;
    }
    if (bFlag) {
        $.ajax({
            url: hdnPath + "Home/SaveTest",
            cache: false,
            type: "POST",
            data: { Id: $("#hdnTestId").val(), TestTypeId: $("#TestTypeId").val(), TestDate: $("#TestDate").val(), IsActive: true },
            success: function (returndata) {
                if (returndata) {
                    window.location.href = hdnPath + "Home";
                }
            },
            fail: function (xhr, status, error) {
            }
        });
    }
}

function DeteleTest(Id) {
    if (confirm("Are you Sure you want to delete test ?")) {
        $.ajax({
            url: hdnPath + "Home/DeleteTestDetails",
            cache: false,
            type: "POST",
            data: { Id: Id },
            success: function (returndata) {
                if (returndata) {
                    window.location.href = hdnPath + "Home";
                }
            },
            fail: function (xhr, status, error) {
            }
        });
    }
}
