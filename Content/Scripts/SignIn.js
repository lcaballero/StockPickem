function SignIn() { }

SignIn.prototype.init = function () {
	$("#submitBtn").click($.proxy(this.submit, this));
}

SignIn.prototype.submit = function (e) {
	console.log("e");
	$.ajax({
		url: "/Home/CheckLoginCredentials",
		data: $('#loginForm').serialize(),
		type: "POST",
		success: function (result) {
			console.log("result", result);
			if (result.Status == 1) {
				window.location = "/Home";
			} else {
				$("#loginForm .alert")
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
	var s = new SignIn();
	s.init();
});