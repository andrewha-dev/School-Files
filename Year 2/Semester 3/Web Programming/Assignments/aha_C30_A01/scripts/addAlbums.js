$(document).ready(function() {
    //Hiding the successful added message
    $(".message").hide();
    //Loading possible genres into the form
    loadGenre();
    //Adding Event listener for the clear button
    $("#clear").on('click', clearForm);
    //Starting jQuery validation for the form
    $("#genreForm").validate({
        rules: {
            genre: {
                isBlank: true,
            },
            albumName: {
                isBlank: true
            },
            artist: {
                isBlank: true
            },
            company: {
                isBlank: true
            },
            condition: {
                isBlank: true
            },
            year: {
                isBlank: true,
                yearCheck: true,
            },
            price: {
                isBlank: true,
                priceFormat: true,
            }

        },
        messages: {
            genre: "Proper Genre Must Be Selected",
            albumName: "This Field Is Required",
            artist: "This Field Is Required",
            company: "This Field Is Required",
            condition: "Please Select A Valid Condition",
            year: "Please Enter A Valid Year",
            price: "Please Enter A Valid Price - Format is: X.XX | X | $X.XX | $X"
        },
        submitHandler: function(form) {
            form.submit();
        }
    })

    //Checking to make sure that there is at least any character
    $.validator.addMethod("isBlank", function(value) {
        return /[A-Za-z0-9-]+[ 0-9A-Za-z#$%=@!{},`~&*()'<>?.:;_|^/+\t\r\n\[\]"-]*/.test(value);
    }, "This field is required");

    //Checking the price formatting
    //Price format must be $X.XX or $X
    $.validator.addMethod("priceFormat", function(value) {
        return /^\$?\d+(?:\.\d{2})?$/.test(value);
    }, "This field is required");

    $.validator.addMethod("yearCheck", function(value) {
        if ((isNaN(value)) == false)
            return true;
    }, "Please enter a valid year");



    $("#add").on('click', function() {
        //If the form passes all the form validation
        if ($("#genreForm").valid()) {
            var genrePicked = $("#genre").val();
            var albumNamePicked = $("#albumName").val();
            var albumPicked = $("#artist").val();
            var companyPicked = $("#company").val();
            var conditionPicked = $("#condition").val();
            var yearPicked = $("#year").val();
            var pricePicked = $("#price").val();
			
			if ((pricePicked).indexOf(0) != "$")
				pricePicked = "$" + pricePicked;

            $.post('./php/addAlbum.php', {
                genre: genrePicked,
                albumName: albumNamePicked,
                artist: albumNamePicked,
                company: companyPicked,
                condition: conditionPicked,
                year: yearPicked,
                price: pricePicked
            }).done(function(data) {
                //Callback Function
                $(".message").show();
                $('#genreForm').find('input, textarea, button, select').attr('disabled', 'disabled');
                setTimeout(function() {
                    clearForm();
                }, 3000)
            }).fail(function() {
                //Function Failed
            }).always(function() {
                //Always Does this
            })

        }
    })
	
	$("#scroll").on('click', function(){
		$('html, body').animate({ scrollTop: 0 }, 'slow');
	})


});

//Reads in from genres.txt in order to load the possible genres from the form
function loadGenre() {
    $.get('./php/files/genres.txt', function(data) {
        var genres = data.split("\n");
        for (var i = 0; i < genres.length; i++) {
            $("#genre").append("<option value ='" + $.trim((genres[i])) + "'>" + $.trim((genres[i])) + "<span></span></option>")
        }
    })
}

//Clears the form and removes all the error messages
function clearForm() {
    $(".message").hide();
    $("#genre").val("");
    $("#albumName").val("");
    $("#artist").val("");
    $("#company").val("");
    $("#condition").val("");
    $("#year").val("");
    $("#price").val("");
    $("#genreForm").data('validator').resetForm();
    $('#genreForm').find('input, textarea, button, select').attr('disabled', false);
}
