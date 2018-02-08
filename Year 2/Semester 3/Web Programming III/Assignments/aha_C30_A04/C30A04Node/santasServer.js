/**
 * Created by 1435792 on 12/1/2016.
 */
/**
 *
 */
var fs = require('fs');
var http = require('http');
var path = require('path');
var url = require('url');
var qs = require('querystring');
var rq = require('./node_modules/request');

const DIRNAME = __dirname;
const PUBLIC_FOLDER = "/public/";
const ERROR_FOLDER = "/private/";
const GETLISTINFO = "http://csdev.cegep-heritage.qc.ca/students/1435792/aha_C30_A04/C30A04PHP/getListInfo.php";
const GETPERSONALINFO = "http://csdev.cegep-heritage.qc.ca/students/1435792/aha_C30_A04/C30A04PHP/getDetailInfo.php";

//Constant for all the extensions and their mime-types
const EXTENSIONS = {
    ".html": "text/html",
    ".htm": "text/html",
    ".css": "text/css",
    ".js": "application/scripts",
    ".png": "image/png",
    ".jpg": "image/jpeg",
    ".jpeg": "image/jpeg",
    ".gif": "image/gif",
    ".pdf": "application/pdf",
    ".svg": "image/svg+xml",
    ".xml": "text/xml",
    ".txt": "text/plain",
    ".ico": "image/x-icon"
};

const PORT = 7546;
var server = http.createServer(function(req, res){


    //If a post request has occured
    if (req.method == 'GET')
    {
        //Getting the post data
        var queryString = url.parse(req.url, true);
        var queryStringObject = queryString.query;

            //If santa is requesting just for the list
            if (Object.keys(queryStringObject)['which'] != "")
            {
                var getListInfoWithQuery = "";
                var theListDecided = queryStringObject['which'];

                getListInfoWithQuery = GETLISTINFO + "?which="+theListDecided;

                var options = {
                    url: GETLISTINFO,
                    method: 'GET',
                    qs: {'which': theListDecided }
                }

                rq(options, function (error, response, body) {
                    if (!error && response.statusCode == 200) {
                        // Print out the response body
                        var theResponseFromINFO = body;
                        res.setHeader("Content-Type","application/json");
                        res.end(JSON.stringify(body));
                    }
                })

            }
        //If santa is requesting for a specific person
        if (Object.keys(queryStringObject)['id'] != "")
        {
            var getPersonInfoWithQuery = "";
            var thePersonDecided = queryStringObject['id'];

            getListInfoWithQuery = GETPERSONALINFO + "?id="+thePersonDecided;

            var personalOptions = {
                url: GETPERSONALINFO,
                method: 'GET',
                qs: {'id': thePersonDecided }
            }

            rq(personalOptions, function (error, response, body) {
                if (!error && response.statusCode == 200) {
                    // Print out the response body
                    var theResponseFromINFO = body;
                    res.setHeader("Content-Type","text/json");
                    res.end(JSON.stringify(body));
                }
            })

        }






    }
    //Declaring a variable that creates the directory to go to
    var directory = "";
    //Returning the index when just only localhost:7546 is entered
    if (req.url == "/")
    {

        //Piecing together the directory
        directory = PUBLIC_FOLDER;
        //Opening the index.html file
        fs.open(DIRNAME + PUBLIC_FOLDER + "index.html", 'r', function(err, fd){
            if (!err)
                fs.close(fd);
            //Reading in the index.html
            fs.readFile(DIRNAME + PUBLIC_FOLDER + "index.html", 'utf-8', function(err, data){
                if (err)
                    throw err;
                //Sending the index.html page back to the server
                res.writeHead(200, {"Content-Type":"text/html"});
                res.end(data);
            })
        })
    }//If()

    //Returning files from any path in the subfolder
    if (req.url != "/")
    {   //Creating the directory again
        directory = PUBLIC_FOLDER;
        //Boolean to make sure that the files are valid
        var noError = true;
        var errorCode;
        var fileName = path.basename(req.url);
        //Checking the file extension
        var extension = (path.extname(fileName));

        //Based on the extension, give a subfolder
        //If the extension is an image then redirect to the images page
        if (extension == ".gif" || extension == ".png" || extension == ".jpg"
            || extension == ".jpeg" || extension == ".svg")
        {
            fileName = "/images/" + fileName;
        }
        //If the extension is the type css then redirect it to the styles folder
        if (extension == ".css")
        {
            fileName = "styles/" + fileName;
        }

        //If the extension is type scripts then redirect it to the scripts folder
        if (extension == ".js")
        {
            fileName = "/scripts/" + fileName;
        }



        //If an acceptable extension hasn't been entered
        if (EXTENSIONS[extension] == undefined) {
            noError = false;

            //If the extension name is undefined, but the user entered in a / and there is
            //no basename as well
            var checkPath = req.url;
            var checkForSlash = checkPath.charAt(checkPath.length - 1);
            if (checkForSlash == "/")
            {
                //Returning index.html
                fs.open(DIRNAME + PUBLIC_FOLDER + "index.html", 'r', function(err, fd){
                    if (!err)
                        fs.close(fd);
                    //Reading in the file
                    getFile(DIRNAME + PUBLIC_FOLDER + "index.html", EXTENSIONS[extension], res)

                })

            }//IF()

            //If the extension does not exist and there is no query string being requested
            // then return 415 error page
            var queryString = url.parse(req.url, true);
          if (checkForSlash != "/" && Object.keys(queryString.query).length == 0) {
                fs.open(DIRNAME + ERROR_FOLDER + "415.html", 'r', function (err, fd) {
                    if (!err)
                        fs.close(fd);
                    //Reading in the file
                    getFile(DIRNAME + ERROR_FOLDER + "415.html", EXTENSIONS[".html"], res);
                })
            }//IF()
        }

        //If there are no errors then display the page
        if (noError == true)
        {
            fs.open(DIRNAME + PUBLIC_FOLDER + fileName, 'r', function(err, fd){
                if (!err)
                    fs.close(fd);
                //Reading in the file
                getFile(DIRNAME + PUBLIC_FOLDER + fileName, EXTENSIONS[extension], res)
            })
        }

    }//If
}).listen(PORT);

//Method to read the file
function getFile(_path, _extensionType, res)
{
    //Reading the file
    fs.readFile(_path, function(err, data){
        if (!err)
        {
            res.writeHead(200, {"Content-Type":_extensionType});
            res.end(data);
        }
        else{
            //Handling the request for a missing favicon
            //Checking to see if the file is a favicon
            if (path.basename(_path) == "favicon.ico")
            {
                res.writeHead(404, {"Content-Type":_extensionType});
                getFile();
            }
            //Handling the error for a non-existent file
            if (err.code == "ENOENT")
            {
                fs.open(DIRNAME + ERROR_FOLDER + "404.html", 'r', function(err, fd){
                    if (!err)
                        fs.close(fd);
                    //Reading in the 404 file - Calling itself but using the page 404
                    getFile(DIRNAME + ERROR_FOLDER + "404.html", EXTENSIONS[".html"], res)

                })
            }
            else {
                fs.open(DIRNAME + ERROR_FOLDER + "500.html", 'r', function(err, fd){
                    if (!err)
                        fs.close(fd);
                    //Reading in the 404 file - Calling itself but using the page 500
                    getFile(DIRNAME + ERROR_FOLDER + "500.html", EXTENSIONS[".html"], res)

                });
            }//Else
        }

    });
}

