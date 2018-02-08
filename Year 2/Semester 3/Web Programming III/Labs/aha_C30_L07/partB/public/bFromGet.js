/**
 * Created by 1435792 on 10/19/2016.
 */
var http = require('http');
var fs = require('fs');
var path = require('path');
var query = require('querystring');
var urlParse = require('url');

const PORT = 8000;
const WEBROOT = './public';

http.createServer(function(req, res){
    var queryString = query.parse(req.url);
    //If they just enter localhost and a port or if there is no queryString
    if (req.url =="/favicon.ico")
    {
        res.end();
    }
    if (req.url == "/")
    {
    fs.open("../" + WEBROOT + "/bGetForm.html",'r', function(err, fd){
        if (!err)
            fs.close(fd);
            fs.readFile("../" + WEBROOT + "/bGetForm.html", 'utf-8', function(err, data){
                if (err)
                    throw err;

                res.writeHead(200, {"Content-Type": "text/html"});
                res.end(data);
            })
    })
    }
    if (req.url != "/")
    {

        var queryStringObject = (urlParse.parse((req.url)));
        var queriedObjects = query.parse(queryStringObject.query)

        res.writeHead(200,{"Content-Type": "text/html"});
        res.end("<h2> Username: " + queriedObjects.username + "</h2>" + "<h3> Phone Number: "+queriedObjects.phoneNum+"</h3>" + "<h3>School: "+queriedObjects.school+ "</h3>")

    }



}).listen(PORT);