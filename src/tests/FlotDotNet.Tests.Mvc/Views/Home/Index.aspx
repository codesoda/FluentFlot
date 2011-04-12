<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="CodeSoda.FluentFlot"%>
<%@ import namespace="FlotDotNet.Tests.Mvc.Helpers" %>
<%
	string flot =
		Html.Flot("$('#chart')", chart => {
			chart.AddSeries(
				new Dictionary<DateTime, int> {
					{ DateTime.Parse("2010-02-01"), 1 },
					{ DateTime.Parse("2010-02-02"), 0 },
					{ DateTime.Parse("2010-02-03"), 3 },
					{ DateTime.Parse("2010-02-04"), 4 },
					{ DateTime.Parse("2010-02-05"), 0 },
					{ DateTime.Parse("2010-02-06"), 5 },
					{ DateTime.Parse("2010-02-07"), 2 },
					{ DateTime.Parse("2010-02-08"), 0 },
					{ DateTime.Parse("2010-02-09"), 6 },
					{ DateTime.Parse("2010-02-10"), 1 },
					{ DateTime.Parse("2010-02-11"), 3 },
					{ DateTime.Parse("2010-02-12"), 4 },
					{ DateTime.Parse("2010-02-13"), 0 },
					{ DateTime.Parse("2010-02-14"), 2 }
				},
				p => new FlotPoint(FlotChart.GetJavascriptTimestamp(p.Key), p.Value),
				options => options
					.Label("Orders")
					.Color("#0077CC")
					.Clickable(true)
					.Hoverable(true)
					.Lines(lines => lines
						.Show(true)
						.Fill(true)
						.FillColor("#e6f2fa")
					    .LineWidth(3))
					.Points(points => points
					    .Show(true)
						.Fill(true)
					    .FillColor("#0077CC")
					    .LineWidth(15))
			);
			chart.AddSeries(
				new Dictionary<DateTime, int> {
					{ DateTime.Parse("2010-02-01"), 5 },
					{ DateTime.Parse("2010-02-02"), 5 },
					{ DateTime.Parse("2010-02-03"), 5 },
					{ DateTime.Parse("2010-02-04"), 5 },
					{ DateTime.Parse("2010-02-05"), 5 },
					{ DateTime.Parse("2010-02-06"), 5 },
					{ DateTime.Parse("2010-02-07"), 5 },
					{ DateTime.Parse("2010-02-08"), 5 },
					{ DateTime.Parse("2010-02-09"), 5 },
					{ DateTime.Parse("2010-02-10"), 5 },
					{ DateTime.Parse("2010-02-11"), 5 },
					{ DateTime.Parse("2010-02-12"), 5 },
					{ DateTime.Parse("2010-02-13"), 5 },
					{ DateTime.Parse("2010-02-14"), 5 }
				},
				p => new FlotPoint(FlotChart.GetJavascriptTimestamp(p.Key), p.Value),
				options => options
					.Label("Carts")
					.Color("#ff9933")
					.Clickable(true)
					.Hoverable(true)
					.Lines(lines => lines
						.Show(true)
						//.Fill(true)
						.FillColor("#ff9933")
						.LineWidth(1))
					.Points(points => points
						.Show(true)
						.Fill(true)
						.FillColor("#ff9933")
						.LineWidth(5))
			);
			chart.AddSeries(
				new Dictionary<DateTime, int> {
					{ DateTime.Parse("2010-02-01"), 15 },
					{ DateTime.Parse("2010-02-02"), 15 },
					{ DateTime.Parse("2010-02-03"), 15 },
					{ DateTime.Parse("2010-02-04"), 15 },
					{ DateTime.Parse("2010-02-05"), 15 },
					{ DateTime.Parse("2010-02-06"), 15 },
					{ DateTime.Parse("2010-02-07"), 15 },
					{ DateTime.Parse("2010-02-08"), 15 },
					{ DateTime.Parse("2010-02-09"), 15 },
					{ DateTime.Parse("2010-02-10"), 15 },
					{ DateTime.Parse("2010-02-11"), 15 },
					{ DateTime.Parse("2010-02-12"), 15 },
					{ DateTime.Parse("2010-02-13"), 15 },
					{ DateTime.Parse("2010-02-14"), 15 }
				},
				p => new FlotPoint(FlotChart.GetJavascriptTimestamp(p.Key), p.Value),
				options => options
					.Label("Visits")
					.Color("#DDDDDD")
					.Clickable(true)
					.Hoverable(true)
					.Lines(lines => lines
						.Show(true)
						.LineWidth(1)
					)
					.Points(points => points
						.Show(true)
						.FillColor("#DDDDDD")
						.Fill(true)
						.LineWidth(5)
					)
			);

			chart.Options( options => options
				.Legend( legend => legend
					.Position(LegendPosition.NE)
				)
				.XAxis(xaxis => xaxis
					.Mode(AxisMode.Time)
					.TimeFormat(TimeFormat.MonthNameDay)
				)
			);
		}
	);
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title></title>
	<!--[if IE]><script language="javascript" type="text/javascript" src="/content/excanvas.min.js"></script><![endif]-->
	<script type="text/javascript" src="/content/jquery.min.js"></script>
	<script type="text/javascript" src="/content/jquery.flot.min.js"></script>
	<script type="text/javascript">
		$(function() {
			<% = flot %>
			
			var previousPoint = null;
			$("#chart").bind("plothover", function (event, pos, item) {
				$("#x").text(pos.x.toFixed(2));
				$("#y").text(pos.y.toFixed(2));

				if (item) {
					if (previousPoint != item.datapoint) {
						previousPoint = item.datapoint;

						$("#tooltip").remove();
						var x = item.datapoint[0].toFixed(2),
							y = item.datapoint[1].toFixed(2);

						showTooltip(item.pageX, item.pageY, x + " " + y);
					}
				}
				else {
					$("#tooltip").remove();
					previousPoint = null;
				}
			});

			function showTooltip(x, y, contents) {
				$('<div id="tooltip">' + contents + '</div>').css( {
					position: 'absolute',
					display: 'none',
					top: y + 5,
					left: x + 5,
					border: '1px solid #fdd',
					padding: '2px',
					'background-color': '#fee',
					opacity: 0.80
				}).appendTo("body").fadeIn(200);
			}

		});
	</script>
</head>
<body>
	<div id="chart" style="width:100%;height:300px; border: solid 1px #000;"></div>
</body>
</html>
