/**
 * Created by 1435792 on 10/19/2016.
 */
var http = require('http');
var fs = require('fs');
var path = require('path');
var qs = require('querystring');
var url = require('url');
var events = require('events');

const dirname = __dirname;
const PORT = 8080;


http.createServer(function(req,res){
    var body = "";
    if (req.url == "/favicon.ico")
        res.end();
    if (req.method == 'GET')
    {
        fs.open(dirname + "/public/cGetForm.html", 'r', function(err, fd){
            if (!err){
                fs.close(fd);
                fs.readFile(dirname + "/public/cGetForm.html", 'utf-8', function(err, data){
                    if (err)
                        throw err;

                    res.writeHead(200, {"Content-Type": "text/html"});
                    res.end(data);
                })
            }

        })
    }

    if (req.method == 'POST')
    {
     req.on('data', function(chunk){
         body+= chunk;
     });
        req.on('end', function(){
            var dataFile = dirname + "/cData.txt";
            var dataObject = qs.parse(body);
            var firstName = (dataObject.firstName);
            var lastName = dataObject.lastName;
            var email = dataObject.emailAddress;

            var postString = firstName + ","+lastName +","+ email + ",\r\n";
            fs.appendFile(dataFile, postString, function(err){
                if (err) {
                    res.end("Error writing file");
                    throw err;
                }
                res.writeHead(200,{"Content-Type":"text/html"});
                res.end("<h1>Successful write</h1>");
            })



        })
    }

}).listen(PORT);