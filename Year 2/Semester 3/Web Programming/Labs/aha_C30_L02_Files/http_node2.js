//Lets require/import the HTTP module
var http = require('http');

//Lets define a port we want to listen to
const PORT1=3003; 
const PORT2=3004; 

//We need a function which handles requests and send response
function handleRequest1(request, response){
	response.writeHead(200);
    response.end('It Works on server1. Path Hit: ' + request.url);
}

function handleRequest2(request, response){
	response.writeHead(200);
    response.end('It also works on server2. Path Hit: ' + request.url);
}

//Create a server
var server1 = http.createServer(handleRequest1);
var server2 = http.createServer(handleRequest2);

//Lets start our server
server1.listen(PORT1, function(){
    //Callback triggered when server is successfully listening. Hurray!
    console.log("Server1 listening on: http://localhost:%s", PORT1);
});

server2.listen(PORT2, function(){
    //Callback triggered when server is successfully listening. Hurray!
    console.log("Server2 listening on: http://localhost:%s", PORT2);
});


