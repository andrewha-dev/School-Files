var fs = require('fs');
console.log("This is my first node.js program");

var url = "H:"

fs.readdir(url, function(err, result){
	if (err)
		throw err;
	console.log(result);
})
console.log("I have made the request");