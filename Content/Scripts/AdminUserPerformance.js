
function Admin_UserPicks() { }

Admin_UserPicks.prototype.init = function () {
	$("#selected-user").change($.proxy(this.updateUser, this));
	$("#scUserPerformance").on("change", $.proxy(this.updateChart, this));
	this.currentUser = $("#selected-user").val();
	this.symbol = $("#selected-symbol").val();
}

Admin_UserPicks.prototype.updateUser = function (e) {
	this.currentUser = $("#selected-user").val();

	$.ajax({
		type: "POST",
		url: "/Admin/LoadUserPerformance",
		context: this,
		data: {
			username: this.currentUser
		},
		success: this.handleUserUpdate,
		error: function (result) {
			console.log("ERROR: ", result);
		}
	});
}

Admin_UserPicks.prototype.handleUserUpdate = function (result) {
	console.log("handleUserUpdate", result);

	// swap container
	var sc = $("#scUserPerformance");
	sc.empty();
	sc.append(result.module);

	this.renderPerformanceChart(this.symbol, result.chartData);
}

Admin_UserPicks.prototype.updateChart = function (e) {
	this.currentUser = $("#selected-user").val();
	this.symbol = $("#selected-symbol").val();

	$.ajax({
		type: "POST",
		url: "/Admin/LoadPerformanceChart",
		context:this,
		data: {
			symbol:this.symbol || "AAPL",
			username: this.currentUser
		},
		success: this.handleChartUpdate,
		error: function (result) {
			console.log("ERROR: ", result);
		}
	});
}

Admin_UserPicks.prototype.handleChartUpdate = function () {
	console.log("handleChartUpdate");
	$("#chart-wrapper").empty();
}

Admin_UserPicks.prototype.renderPerformanceChart = function (symbol, data) {
	var chart = new Highcharts.StockChart({
		chart: {
			renderTo: "chart-wrapper",
			width: 800,
			height: 300
		},
		xAxis: {
			type: 'datetime'
		},
		rangeSelector: {
			selected: 1
		},

		title: {
			text: "Performance Chart for " + symbol
		},

		series: [{
			name: symbol,
			data: data,
			tooltip: {
				valueDecimals: 2
			}
		}]
	});
}

$(document).ready(function () {
	var admin = new Admin_UserPicks();
	admin.init();
	$("#scUserPerformance").trigger("change");
});