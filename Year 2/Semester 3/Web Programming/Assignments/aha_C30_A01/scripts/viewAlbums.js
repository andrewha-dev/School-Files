$(document).ready(function() {
  //Loading the possible genres to choose from
    loadGenre();
    //Everytime an option is selected, it will load the value genre
    $("#genre").on('change', function(e) {
        pageUpdate(e.target.value);
        //For visual effects
        $(".bottomnav").removeClass('navbar-fixed-bottom');
    })
	
	$("#scroll").on('click', function(){
		$('html, body').animate({ scrollTop: 0 }, 'slow');
	})
});

//The function reads in the different genres and adds it as an option to the form
function loadGenre() {
    $.get('./php/files/genres.txt', function(data) {
        var genres = data.split("\n");
        for (var i = 0; i < genres.length; i++) {
            $("#genre select").append("<option value ='" + $.trim((genres[i])) + "'>" + $.trim((genres[i])) + "</option>")
        }
    })
}

//This function updates the page based on the genre selected
function pageUpdate(genrePicked) {
    $.get('./php/getAlbums.php', {
        genre: genrePicked
    }, function(data) {
        getGenres(data);
    });
}

//This function gets all the albums and displays them
function getGenres(albums) {
    $(".albumDisplay").text("");
    var responseGenre = albums;
    var albums = $(responseGenre).find('albums:first-child');
    var genreAlbum = ($(albums[0]).find('album'));
    for (var i = 0; i < genreAlbum.length; i++) {
        var albumName = $(genreAlbum[i]).find("albumName");
        albumName = ($(albumName[0]).text());

        var albumArtist = $(genreAlbum[i]).find("artist");
        //Have to figure out what to do where there are 2 or more artists
        var albumArtistCombined = ""
        //Formatting the artist String if there are more then 1 artist
        //Loops adds a "/" between each artist
        if (albumArtist.length > 1) {
            for (var j = 0; j < albumArtist.length; j++) {
                var albumArtistCombined = albumArtistCombined + ($(albumArtist[j]).text());
                if (j != albumArtist.length - 1) {
                    albumArtistCombined = albumArtistCombined + " / ";
                }
            }
            albumArtist = albumArtistCombined
            //If there is only one artist
        } else {
            albumArtist = ($(albumArtist[0]).text());
        }

        //Finding the value from the company
        var albumCompany = $(genreAlbum[i]).find("company");
        albumCompany = ($(albumCompany[0]).text());
        //Finding the album condition
        var albumCondition = $(genreAlbum[i]).find("condition");
        albumConditionShortHand = ($(albumCondition[0]).text());
        var conditionFull
        //Using a switch statement in order to return the appropriate conditions
        switch (albumConditionShortHand) {
            case "M":
                conditionFull = "Mint";
                break;
            case "VG":
                conditionFull = "Very Good";
                break;
            case "G":
                conditionFull = "Good";
                break;
            case "P":
                conditionFull = "Poor";
                break;
            case "VP":
                conditionFull = "Very Poor";
                break;
            default:
                conditionFull = "Error";
        }

        //Finding the value from the year
        var albumYear = $(genreAlbum[i]).find("year");
        albumYear = ($(albumYear[0]).text());
        //Finding the value from the price tag
        var albumPrice = $(genreAlbum[i]).find("price");
        albumPrice = ($(albumPrice[0]).text());

        //Appending the album divs
        $(".albumDisplay").append("<div class='col-sm-6 col-md-4 col-lg-3 col-xs-offset-0 col-lg-offset-0  albumBlock'><div class='albumArea'><div class='albumArt notMobile'><img src='./images/vinyl" + albumConditionShortHand + ".jpg' alt='Vinyl Mint' width='150' height='150'></div><div class='info'><p>Title: <span class='titleSpan'>" + albumName + "</span></p><p class='artistPara'>Artist: <span class='artistSpan'>" + albumArtist + "</span></p><p>Company:<span class='companySpan'>" + albumCompany + "</span></p><p>Condition:<span class='conditionSpan'>" + conditionFull + "</span></p><p>Year:<span class='yearSpan'>" + albumYear + "</span></p><p>Price:<span class='priceSpan'>" + albumPrice + "</span></p></div></div></div>")

    }
    //Function recalls itself after every 10 seconds
     setTimeout(function() {
         var genre = $("option:selected").text();
         pageUpdate(genre);
     }, 10000);
}
