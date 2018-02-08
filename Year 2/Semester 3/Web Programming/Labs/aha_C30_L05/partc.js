var myModule = require('./cModules.js')

myModule.areaCircle(3, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})

myModule.areaRect(4,6, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})

myModule.perimRect(4,6, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})
myModule.isTriangle(3,4,5, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})
myModule.isTriangle(3,4,8, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})
myModule.areaRect(2,3, function(err, result){
	if (err)
		throw err;
	
	myModule.areaCircle(result, function(err, result){
	if (err)
		throw err;
	
	console.log(result);
})
	
})