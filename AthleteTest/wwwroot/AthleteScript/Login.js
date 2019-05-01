function CheckAuthentication() {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        url: $("#hdnAppPath").val() + "Login/Authentications",
        cache: false,
        type: "POST",
        data: { UserName: $("#txtUserName").val(), Password: $("#txtPassword").val() },
        success: function (returndata) {
            if (returndata) {
                window.location.href = "Home";
            }
        },
        fail: function (xhr, status, error) {
        }
    });
}

