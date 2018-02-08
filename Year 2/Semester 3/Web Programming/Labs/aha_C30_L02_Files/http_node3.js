var http = require("http");

const PORT=3005; 

var server = http.createServer(function(request, response) {
  response.writeHead(200, {"Content-Type": "text/html", "HeaderStuff": "Fuzzy Caterpillar"});
  response.write("<!DOCTYPE 'html'>");
  response.write("<html>");
  response.write("<head>");
  response.write("<title>Node Hello World Page</title>");
  response.write("</head>");
  response.write("<body>");
  response.write("<h1>Header from Node!</h1>");
  response.write("<p>Hello World from node!</p>");
  response.write("</body>");
  response.write("</html>");
  response.end();
});

server.listen(PORT);
console.log("Server is listening on port: %s", PORT);