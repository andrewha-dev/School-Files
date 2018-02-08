console.log("HI");
var form = document.getElementById("form1")
form.addEventListener('submit', function(e){
	checkThis(e)
	}, false);


function checkThis(e){
	var isEmpty = true;
	if(document.getElementById("firstName").value == "")
	isEmpty = false;
	if(document.getElementById("myAge").value == "")
	isEmpty = false;
	if(document.getElementById("emailAddr").value == "")
	isEmpty = false;
	
	if (isEmpty == false)
	{
		e.preventDefault();
		alert("Please fill in all the fields")
		changeColor();	
	}
		
	return isEmpty;
	
}

var changeColor = function() {
	document.body.style.backgroundColor = "#ccc"
}