/**
 * Created by 1435792 on 10/21/2016.
 */
var fs = require('fs');
var http = require('http');
var path = require('path');
var url = require('url');
var qs = require('querystring');
var parseXML = require('xml2js').parseString;
var userObject = require('./userObject');

const DIRNAME = __dirname;
const PUBLIC_FOLDER = "/../ahaC30A02root/public/";
const ERROR_FOLDER = "/../ahaC30A02root/errorpages/";
const BIN_FOLDER = PUBLIC_FOLDER + "/bin/";
const DATA_FOLDER = "/../ahaC30A02data/xml/";
const LOGS_FOLDER = "/../ahaC30A02data/logs/"

//Constant for all the extensions and their mime-types
const EXTENSIONS = {
    ".html": "text/html",
    ".css": "text/css",
    ".js": "application/javascript",
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




const PORT = 9000;
var server = http.createServer(function(req, res){

    //Logging the url request
    // console.log(req.url)
    fs.appendFile(DIRNAME + LOGS_FOLDER + "web.log", req.url + "\r\n", function(err){
        if (err)
            throw err;
    })

    //If a post request has occured
    if (req.method == 'POST')
    {
        //Getting the post data
        var bodyData= "";
        req.on('data', function(chunk){
            bodyData += chunk;
        })
        req.on('end', function(){
            var postObjectData = qs.parse(bodyData);

            var postResponse = userObject.returnObject(postObjectData);


            var firstName = postResponse.getFirstName();
            var lastName = postResponse.getLastName();
            var userName = postResponse.getUsername();
            var emailAddress = postResponse.getEmailAddress();
            var phone = postResponse.getPhoneNumber();

            var postString = firstName + ", " + lastName + ", " + userName + ", " + emailAddress +
                ", " + phone + "," + "\r\n";

            fs.appendFile(DIRNAME + LOGS_FOLDER + "users.txt", postString, function(err){
                if (err){
                    //If there is a file reading error
                    getFile(DIRNAME + ERROR_FOLDER + "520.html", EXTENSIONS[".html"], res)
                }

            })
            res.writeHead(200, {"Content-Type": "text/html"});
            res.end("<!DOCTYPE html><html lang=en><meta charset=UTF-8><title>Your Post Result</title><link href=styles/postResults.css rel=stylesheet><div><h1>Your Post Results</h1><p>First Name: <span id='spanFirstName'>" + firstName + "</span></p><p>Last Name: <span id='spanLastName'>" + lastName + "</span></p><p>Username: <span id='spanUsername'>" + userName + "</span></p><p>Email Address: <span id='spanEmailAddress'>" + emailAddress + "</span></p><p>Phone Number: <span id='spanPhoneNumber'>" + phone + "</span></p></div>");
        })
    }
    //Declaring a variable that creates the directory to go to
    var directory = "";
    //Returning the index when just only localhost:9000 is entered
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

            //Checking to see if the path 'bin' was put in
            //If the extension does not exist then return 415 error page
            if (checkForSlash != "/" && path.dirname(req.url) != "/bin") {
                fs.open(DIRNAME + ERROR_FOLDER + "415.html", 'r', function (err, fd) {
                    if (!err)
                        fs.close(fd);
                    //Reading in the file
                    getFile(DIRNAME + ERROR_FOLDER + "415.html", EXTENSIONS[".html"], res)

                })
            }//IF()
        }

        if (path.dirname(req.url) == "/bin")
        {
            //Checking to make sure that the extension is XML

            //Have to run check to see if there is a query string first
            var xmlFileName = url.parse(req.url);
            xmlFileName = (path.basename(xmlFileName.pathname));

            //If the path extension is not XML
            if (path.extname(xmlFileName) != ".xml")
            {
                //Returning the 400 page error if the extension is not XML
                fs.open(DIRNAME + ERROR_FOLDER + "400.html", 'r', function(err, fd){
                    if (!err)
                        fs.close(fd);
                    getFile(DIRNAME + ERROR_FOLDER + "400.html", EXTENSIONS[".html"], res)
                })
            }
            //If the path extension is XML
            if (path.extname(xmlFileName) == ".xml")
            {
                //Checking to make sure that the file exists in the data/xml folder
                fs.open(DIRNAME + DATA_FOLDER + xmlFileName, 'r', function(err, fd) {
                    if (err) {
                        //If the file doesn't exist in the data/xml folder
                        getFile(DIRNAME + ERROR_FOLDER + "404.html", EXTENSIONS[".html"], res);
                    }
                    //If the file does exist in the data/xml folder
                    if (!err)
                    {
                        //Checking to see if there is a query string
                        var query = url.parse(req.url);
                        //If the query is empty
                        if(query.query == "")
                        {
                            //If there is no query string then return the 406 Error page
                            fs.open(DIRNAME + ERROR_FOLDER + "406.html", 'r', function(err, fd){
                                if (err)
                                    throw err;
                                if (!err)
                                    fs.close(fd);
                                getFile(DIRNAME + ERROR_FOLDER + "406.html", EXTENSIONS[".html"], res)
                            })
                        }//If
                        //If the query string is not empty
                        else {
                            //Parsing the query string
                            var queryString = url.parse(req.url, true);
                            var queryStringObject = queryString.query;

                            //Opening the XML file
                            fs.open(DIRNAME + DATA_FOLDER + xmlFileName, 'r', function(err, fd){
                                if (err)
                                    throw err;
                                fs.close(fd);
                                fs.readFile(DIRNAME + DATA_FOLDER + xmlFileName, function(err, data){
                                    //Converting the XML object into a JSON object
                                    var xmlToJsonObject = parseXML(data, function(err, result){
                                        //Looping through all the parameters in the object
										
                                        //Boolean variable if the object is found
                                        var objectFound = false;
                                        for(var firstChildKey in result) {
                                            var firstChildResults = result[firstChildKey];
                                            for (var secondChildName in firstChildResults)
                                            {
                                                var secondChildResults = firstChildResults[secondChildName]
                                                for (var thirdChildName in secondChildResults)
                                                {
                                                    var thirdChildResults = secondChildResults[thirdChildName];
                                                    //After getting to the actual elements in the XML document
                                                    //Compare the query string keys to the key pair values in the XML document
                                                    for (var searchKeys in queryStringObject)
                                                    {
                                                        var attributesMatch = true;
                                                        //Looping through the the search key and objects and comparing it to
                                                        //Each XML element entries.
														
                                                        if (queryStringObject[searchKeys] != thirdChildResults[searchKeys])
                                                        {
                                                            attributesMatch = false;
                                                        }
                                                    }
                                                    //If a match has been found in the XML file
                                                    if (attributesMatch == true)
                                                    {
                                                        //If a match has been found
                                                        objectFound = true;
                                                        //Getting the key names of the found match for formatting purposes
                                                        var objectKeys = (Object.keys(thirdChildResults));
														console.log(thirdChildResults);
                                                        //Creating an HTML stringfor formatting
                                                        var toHtml = "<!DOCTYPE html><html lang=en><meta charset=UTF-8><title>Search Results</title><link href=styles/searchResults.css rel=stylesheet><h1>Match Found!</h1>";
                                                        for (var i = 0; i < objectKeys.length; i++) {
                                                            var name = objectKeys[i];
                                                            //Testing to see if there is an object inside that key



                                                            if (Object.keys(thirdChildResults[name]) != 0)
                                                            {
                                                                var moreKeys = Object.keys(thirdChildResults[name]);
                                                                for (var i = 0; i < moreKeys.length; i++) {

                                                                    toHtml += ("<p>" + moreKeys[i] +  ": <span>" + thirdChildResults[name][moreKeys[i]]+ "</span></p>");
                                                                }
                                                                // Formatting the specific object

                                                            }
                                                            else {

                                                                if (thirdChildResults[name][0]._ != undefined)
                                                                {
                                                                    toHtml  += ("<p>" + name + ": <span>" + thirdChildResults[name][0]._ + "</span></p>");
                                                                }
                                                                    if (thirdChildResults[name][0].$ != undefined)
                                                                    {
                                                                        var theKey = (Object.keys(thirdChildResults[name][0].$));
                                                                        toHtml += ("<p>"+theKey[0] + ": <span>" + thirdChildResults[name][0].$.scale+ "</span></p>");
                                                                    }
                                                                //If there are no other keys inside the object
                                                                else if (Object.keys(thirdChildResults[name][0].$ > 1))
                                                                {
                                                                    toHtml += ("<p>" + name + ": <span>" + thirdChildResults[name][0]+ "</span></p>");
                                                                }
                                                            }

                                                        }
                                                        console.log("To HTML" + toHtml);
                                                        res.writeHead(200, {"Content-Type":"text/html"});
                                                        res.end(toHtml);


                                                    }
                                                }

                                            }
                                            //If a match hasn't been found in the XML file
                                            if (objectFound == false)
                                            {
                                                fs.open(DIRNAME + ERROR_FOLDER + "416.html", 'r', function(err, fd){
                                                    if (err)
                                                        throw err;
                                                    if (!err)
                                                        fs.close(fd);
                                                    getFile(DIRNAME + ERROR_FOLDER + "416.html", EXTENSIONS[".html"], res)
                                                })
                                            }
                                        }
                                    })
                                })
                            })
                        }
                    }
                })
            }//If
        }

        //If there are no errors then display the page
        if (noError == true && path.dirname(req.url) != "/bin")
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
                res.end();
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


