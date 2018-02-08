/**
 * Created by 1435792 on 10/5/2016.
 */
var http = require('http');
var url = require('url');
var fs = require('fs');
var path1 = require('path');
const PORT = 3456;
var thePath = __dirname + "/webbase/index.html";
var theOtherPath


http.createServer(function(request, response){
    response.setHeader("Cache-Control","no-cache");
    response.setHeader("Date",new Date());
    response.setHeader("Warning","99 Problems and Allan isn't one");


    console.log(request.url);

    // fs.open(thePath,'r',function(err, fd){
    //     if (err) {
    //         if (err.code === "ENOENT") {
    //             response.writeHead(404)
    //             response.end("File Not Found");
    //         }
    //
    //     }
    //     response.writeHead(200,{
    //         "Content-Type":"text/html",
    //         "Andrew": "Ha"
    //     });
    //     fs.close(fd);
    //     fs.readFile(thePath, function(err, data){
    //         if (err)
    //             throw err;
    //         response.end(data);
    //     })
    // })

    var dirname = (path1.dirname(request.url));
    var basename = (path1.basename(request.url));

    if (basename == "")
        basename = "/index.html";
    var extension = path1.extname(basename);
    var wholename = dirname + "/" + basename;
    var localpath = __dirname;
    console.log("Dirname" + __dirname)
    console.log(wholename);
    console.log(localpath);
    var fullpath = localpath + "" + "/webbase" + wholename;
    console.log(fullpath);
    var contentType;
    if (extension == ".html")
        contentType = "text/html";
    if (extension == ".txt")
        contentType = "text/plain";
    else
        extension = "text/html";


    fs.open(fullpath,'r',function(err, fd) {
        if (!err) {
            fs.close(fd);
            fs.readFile(fullpath, 'utf-8', function (err, data) {
                if (err)
                    throw err;

                response.writeHead(200,{"Content-Type": contentType})
                response.end(data);

            })
        }
        else if (err) {
            if (err.code == "ENOENT") {
                response.writeHead(404, {"Content-Type": "text"});
                response.end("File Not Found");
            }

            else {
                response.writeHead(500,{"Content-Type": "text"});
                response.end("Unknown Server Error");
            }
        }


    })



}).listen(PORT);
