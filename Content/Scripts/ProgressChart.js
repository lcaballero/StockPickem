$(document).ready(function () {

	$.getJSON('http://www.highcharts.com/samples/data/jsonp.php?filename=aapl-c.json&callback=?', function (data) {


		console.log(data);
		// Create the chart
		window.chart = new Highcharts.StockChart({
			chart: {
				renderTo: 'stock-chart',
				width: 800,
				height:300
			},

			rangeSelector: {
				selected: 1
			},

			title: {
				text: 'AAPL Stock Price'
			},

			series: [{
				name: 'AAPL',
				data: data,
				tooltip: {
					valueDecimals: 2
				}
			}]
		});
	});

});