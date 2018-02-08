$(document).ready(function() {
    // $('.moreDetails69').hide();
  //Loading in the good list by default
    pageUpdate("nice");
    //Everytime an option is selected, it will load the value genre
    $("#list").on('change', function(e) {
        pageUpdate(e.target.value);
        //For visual effects


    })

	$("#scroll").on('click', function(){
		$('html, body').animate({ scrollTop: 0 }, 'slow');
	})


    $(document).on('click', '.hint' , function() {
        var idRequested = ($(this).parent().parent().attr("id"));
        var selectedClass = ".moreDetails" + idRequested;
        if (($(selectedClass).is(':hidden')))
        moreDetails(idRequested);
        else {
            $(selectedClass).toggle(1000);
        }
    });

    setInterval(function(){
        pageUpdate($("option:selected").val());
    }, 30000);

});



//This function updates the page based on the list selected
function pageUpdate(listPicked) {
    $.get('/', {
        which: listPicked
    }, function(data) {
        getList(data);
    });
}

//This function will retrieve the specific details based off of the description
function moreDetails(idPicked){
    $.get('/', {
        id: idPicked
    }, function(data) {
        expandDetails(data, idPicked);
    });

}




//This function gets all the albums and displays them
function getList(list) {
    //Adding the json brackets in front of the result
    list = "{ \"person\": [" + list;

    list = list + "]}";
    // $('.listDisplay').text("");
    $("#theHeaderTitle").text("");

    //Code for changing the headers for the name;
    var titles = {"nice": "Good", "naughty":"Naughty",
        "unknown": "Unknown", "limbo":"Limbo"};
    var theTitle = $("#list option:selected").text();
    $('#theHeaderTitle').append('<h1 class="listTitle">The ' + theTitle +' List</h1>');

    //Changing the background color
    animateBackground();


    $(".listDisplay").text("");

    var jsonObject = JSON.parse(list);
    for (var i = 0; i < jsonObject['person'].length; i++) {
        var personID = jsonObject['person'][i]['-id'];
        var city = jsonObject['person'][i]['city'];
        var firstName = jsonObject['person'][i]['firstName'];
        var lastName = jsonObject['person'][i]['lastName'];
        var dateUpdated = jsonObject['person'][i]['dateUpdated'];

        var individualClassString = "moreDetails" + personID;

        var myvar = '<br><div class="container-fluid childrenBlock col-sm-10 col-sm-offset-1" id='+personID+'>'+
            '                <div class="container-fluid listID">#'+
                                       personID +
            '                </div>'+
            '                <div class="container-fluid col-sm-10 col-md-10 col-lg-12 listName">'+
            '                <p class="listNameData">'+firstName + ' ' + lastName +'</p>'+
            '                    <p class="listCityData">City:</p><span>'+city+'</span>'+
            '                    <p class="listLastUpdated"> Last Modified: '+dateUpdated+'</p>'+
            '                </div>'+
            '                <div class="container-fluid">'+
            '                    <a class="hint">More Details</a>'+
            '                </div>'+
            '            </div>'+
            '            <div class="container-fluid moreDetailsDiv col-sm-10 col-md-10 col-lg-10 col-sm-offset-1 '+individualClassString+'">'+

             '            </div>';


        //Hiding the div when loading it in because it will be blank
        $("." + individualClassString).hide();
        individualClassString = "." + individualClassString;


        $(".listDisplay").append(myvar);
        $(individualClassString).hide();

    }

}

function expandDetails(details, idPicked)
{
    var listLetter = {'N': "Naughty", 'G': "Good", 'L':"Limbo", 'U':"Unknown"}
    //Recreating the result back into a json object
    details = "{ \"person\": [" + details;
    details = details + "]}";
    //Parsing the recreated json object into a json object
    var jsonObject = JSON.parse(details);
    //Each template will get an extra class in order to access it
    var selectedClass = ".moreDetails" + idPicked;
    //Loading in each attribute from the JSON object
    var personID = jsonObject['person'][0]['-id'];
    var combinedName = jsonObject['person'][0]['firstName'] + " " + jsonObject['person'][0]['lastName'];
    var age = jsonObject['person'][0]['age'];
    var currentList = jsonObject['person'][0]['curList']
    var currentListToWord = listLetter[currentList];
    var city = jsonObject['person'][0]['city'];
    var details = jsonObject['person'][0]['details'];
    var lastModified = jsonObject['person'][0]['dateUpdated'];


    if ($(selectedClass).is(':hidden')) {
        var detailsTemplate = '                   <dl class="dl-horizontal moreDetailsListAlign">'+
        '                   <dt>'+
        '                       ID:'+
        '                   </dt>'+
        '                       <dd>'+
        '                           '+personID+
        '                       </dd>'+
        ''+
        '                   <dt>'+
        '                       Name:'+
        '                   </dt>'+
        '                       <dd>'+
                                    combinedName+
        '                       </dd>'+
        ''+
        '                   <dt>'+
        '                       Age:'+
        '                   </dt>'+
        '                       <dd>'+
                                age+
        '                       </dd>'+
        '                   <dt>'+
        '                       Current List:'+
        '                   </dt>'+
        '                       <dd>'+
                    currentListToWord+
        '                       </dd>'+
        '                   <dt>'+
        '                       City:'+
        '                   </dt>'+
        '                       <dd>'+
                                    city +
        '                       </dd>'+
        '                   <dt>'+
        '                       Details:'+
        '                   </dt>'+
        '                   <dd>'+
                                details+
        '                   </dd>'+
        '                   <dt>'+
        '                       Last Updated:'+
        '                   </dt>'+
        '                   <dd>'+
                        lastModified+
        '                   </dd>'+
        '               </dl>'
        $(selectedClass).text("")
        $(selectedClass).append(detailsTemplate);
        // $(".bottomnav").removeClass('navbar-fixed-bottom');

        $(selectedClass).toggle(1000);
    }
    //After loading all the data then it will expand.
    // $(selectedClass).toggle(1000);





}

function animateBackground(){

    //Gets the color to use based off of the selected title
    var titles = {"Good": "#A49B7F", "Naughty":"#B993BE",
        "Unknown": "#6E79A4", "Limbo":"#D2D8F1"};

    //Gets the text from the dropdown box
    var selectedValue = $("#list option:selected").text();
    //Puts it into the associative array and gets the color to use
    var colorToChange = titles[selectedValue];

    //Animating the color over the lapse of two seconds
    $("body").animate({
        backgroundColor: colorToChange
    }, 2000)



}