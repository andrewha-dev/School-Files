var button = document.getElementById('button');
button.addEventListener('click', function(e){
callButton(e);
}, false)
var request
var interval;

generateTable();

function callButton(e){
	
	e.preventDefault();
			
	
	if (button.value == "unclicked")
	{
	interval = setInterval(function(){
	sendFile(e);
	}, 3000)
	button.innerHTML = "Stop";
	button.value = "clicked";
	return;
		
	}		
	if (button.value == "clicked") {
	clearInterval(interval);
	button.innerHTML = "Start";
	button.value = "unclicked";
	return;
	}


}

function sendFile(e){
	try {
		request = new XMLHttpRequest();
		request.open('GET','./php/random.php', true)
		request.onreadystatechange = getNames;
		request.send(null);
		

		
	
	}
	catch(e) {
		console.log("Error opening request")
	}
}
function getNames(){
	if ((request.readyState == 4) && (request.status == 200))
	{
		
		var name = request.responseText
		var array = document.getElementsByTagName("span")
		
		console.log(name);
		
		updateCount(name);
		
		
		
		
	}
}

var namesRequest;
var myArray;
function generateTable()
{
	try {
	namesRequest = new XMLHttpRequest();
	namesRequest.open('GET', "./php/files/class.txt", true)
	namesRequest.send();
	
	var names = document.getElementById('info')
	
	
	namesRequest.onreadystatechange = function(){
		if (this.readyState == 4 && this.status == 200)
		{
			var allNames = this.responseText;
			myArray = allNames.split("\n");
			
			for (var i = 0; i < myArray.length; i++)
			{
				names.innerHTML += "<p>" +  myArray[i] + " - " + "<span class=\"" + myArray[i] + "\">0</span></p>"
				
				
			}
		}
	
	
	}
	
}
	catch(e)
	{
		console.log("Error");
	}
	
}
function updateCount(_name)
{
	var mySpanArray = document.getElementsByTagName("SPAN");
	var name = _name
	for (var a = 0; a < myArray.length; a++)
	{
		
		if (name.trim() == myArray[a].trim())
		{
			
			mySpanArray[a].innerHTML = parseInt(mySpanArray[a].innerHTML) + 1;
			return;
			
		}
	}
	
	
		
	
}






























