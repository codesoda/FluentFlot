<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="CodeSoda.FluentFlot"%>

<%
	var data1 = new Dictionary<DateTime,int>();
	var r = new Random();
	for(int i=0,len=50; i<len; i++) {
		data1[DateTime.Now.AddDays(i)] = r.Next(100);
	}
	
	var chart = new FlotChart("$('chart')");
	chart.AddSeries(data1, x=> new FlotPoint(FlotChart.GetJavascriptTimestamp(x.Key), x.Value), null );
	var flot = chart.ToJson();
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
	<title></title>
	<!--[if IE]><script language="javascript" type="text/javascript" src="content/excanvas.min.js"></script><![endif]-->
	<script type="text/javascript" src="content/jquery.min.js"></script>
	<script type="text/javascript" src="content/jquery.flot.min.js"></script>
	<script type="text/javascript">
		$(function() {
			$.plot($('chart'), [[1,1],[2,2],[3,3],[4,4],[5,5]]);  //<% = flot %>;
		});
	</script>
</head>
<body>
	<div id="chart" style="width:100%;height:300px; border: solid 1px #000;"></div>
</body>
</html>
