function Registration() { }

Registration.prototype.init = function () {
	$("#registrationForm button").click($.proxy(this.submit, this));
}

Registration.prototype.submit = function (e) {
	$.ajax({
		url: "/Home/SaveUserRegistration",
		data: $('#registrationForm').serialize(),
		type: "POST",
		success: function (result) {

			if (result.Status == 1) {
				window.location = "/Home/SignIn";
			} else {
				$("#registrationForm .alert")
					.removeClass("none")
					.addClass("alert-error").html(result.StatusMsg);
			}
		},
		error: function (result) {
			console.log("error", result);
		}
	});

	return e.preventDefault();
	
}

$(document).ready(function () {
	var reg = new Registration();
	reg.init();
});