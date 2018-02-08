var httpRequest = false;
var change = document.getElementById('theSport');

change.addEventListener('change', sportsUpdate, true);


function getRequestObject() {
	try {
		httpRequest = new XMLHttpRequest();
	}
	catch (requestError) {
		window.alert("Your browser does not support AJAX!");
		return false;
	}
	return httpRequest;
}

function sportsUpdate() {
	var sport = document.getElementById("theSport").options[document.getElementById("theSport").selectedIndex].value;
	var url = './php/SportingNews.php?sport='+ sport;
	httpRequest = getRequestObject();
	httpRequest.abort();
	httpRequest.open('GET', url, true)
	httpRequest.send(null);
	httpRequest.onreadystatechange = getSportNews;
	setTimeout(sportsUpdate, 5000);
}

function getSportNews() {
	if (httpRequest.readyState == 4 && httpRequest.status == 200)
	{
		var news = httpRequest.responseXML;
		var newsItems = news.getElementsByTagName("item");
		console.log(newsItems);
		document.getElementById('newsCell').innerHTML = "";
		
		if (newsItems.length > 0)
		{
			for (var i = 0; i < newsItems.length; ++i){
				var curHeadline = newsItems[i].getElementsByTagName("title")[0].childNodes[0].nodeValue;
				var curLink = newsItems[i].getElementsByTagName("link")[0].childNodes[0].nodeValue;
				var curPubDate = newsItems[i].getElementsByTagName("pubDate")[0].childNodes[0].nodeValue;
				var curDesc = newsItems[i].getElementsByTagName("description")[0].childNodes[0].nodeValue;
				var curStory = "<a href='" + curLink + "'>" + curHeadline + "</a><br/>";
				curStory += "<span style = 'color: gray'>" + curPubDate + "</span><br/>";
				curStory += curDesc + "<br/>";
				document.getElementById('newsCell').innerHTML += curStory;
				
			}
			
		}
		else 
				document.getElementById("newsCell").innerHTML = "RSS feed does not contain any items."
	}
}