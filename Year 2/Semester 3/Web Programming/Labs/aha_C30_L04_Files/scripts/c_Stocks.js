$(document).ready(function(){
	$("input[type='radio']").click(function(){
		stocksUpdate($(this).val());
	});
})

function stocksUpdate(stockGroup)
{	
	$.get("StockCheck.php",
	{checkQuote: stockGroup},
	function(data){fillStocksInfo(data);
	}).done(function(){
		alert("Request has completed - DONE");
	}).fail(function(){
		alert("There has been an error processing the request - FAIL");
	}).always(function(){
		alert("Always called") ; 
	})
}

function fillStocksInfo(stocks){
	$("#stocks").text("");
	console.log(stocks.childNodes[0])
	var stockItems = stocks.getElementsByTagName("quote")
	console.log(stockItems);
	for (var i=0; i < stockItems.length; i++)
	{
	var ticker = stockItems[i].getElementsByTagName("ticker")[0].childNodes[0].nodeValue;
	var lastTrade = stockItems[i].getElementsByTagName("lastTrade")[0].childNodes[0].nodeValue;
	var lastTradeDate = stockItems[i].getElementsByTagName("lastTradeDate")[0].childNodes[0].nodeValue;
	var lastTradeTime = stockItems[i].getElementsByTagName("lastTradeTime")[0].childNodes[0].nodeValue;
	var change = stockItems[i].getElementsByTagName("change")[0].childNodes[0].nodeValue;
	var _open = stockItems[i].getElementsByTagName("open")[0].childNodes[0].nodeValue;
	var rangeHigh = stockItems[i].getElementsByTagName("rangeHigh")[0].childNodes[0].nodeValue;
	var rangeLow = stockItems[i].getElementsByTagName("rangeLow")[0].childNodes[0].nodeValue;
	var volume = stockItems[i].getElementsByTagName("volume")[0].childNodes[0].nodeValue;
	var chart = stockItems[i].getElementsByTagName("chart")[0].childNodes[0].nodeValue;
	
	$("#stocks").append("<p>Ticker: <span>"+ticker+"</span></p>")
	$("#stocks").append("<p>Last Trade: <span>"+lastTrade+"</span></p>")
	$("#stocks").append("<p>Last Trade Date: <span>"+lastTradeDate+"</span></p>")
	$("#stocks").append("<p>Last Trade Time: <span>"+lastTradeTime+"</span></p>")
	$("#stocks").append("<p>Change: <span>"+change+"</span></p>")
	$("#stocks").append("<p>Open: <span>"+_open+"</span></p>")
	$("#stocks").append("<p>Range High: <span>"+rangeHigh+"</span></p>")
	$("#stocks").append("<p>Range Low: <span>"+rangeLow+"</span></p>")
	$("#stocks").append("<p>Volume: <span>"+volume+"</span></p>")
	$("#stocks").append("<img src="+chart+"></img>")
	}
}