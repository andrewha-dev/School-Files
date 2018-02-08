var http = require('http');

var server = http.createServer(function(req, res) {
  res.writeHead(404);
  res.end('Hello Http via node.js');
});
server.listen(3002);
console.log('Server started on port 3002');