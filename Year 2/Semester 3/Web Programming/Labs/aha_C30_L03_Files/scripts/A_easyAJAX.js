// JavaScript Document
var firstName = document.getElementById('firstName');
firstName.addEventListener('change', getXMLHttpRequest, false);
lastName.addEventListener('change', getXMLHttpRequest, false);
var request = false;


function checkReadyValue() {
	if ((request.readyState == 4) && (request.status == 200))
	{
		var response = request.responseText;
		return response;
	}
}

function getXMLHttpRequest() {
	
	try {
		
		request = new XMLHttpRequest();
		request.open('GET', "./php/servertime.php", true);
		request.onreadystatechange = function()
		{ 
			var time = document.getElementById('time');
			
			time.innerHTML = checkReadyValue();
		}
		
		request.send(null);
		
		
		
	}
	catch (e) {
	console.log("ERROR");
	}
	return request;
}

