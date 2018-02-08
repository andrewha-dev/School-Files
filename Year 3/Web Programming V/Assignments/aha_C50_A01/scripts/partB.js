//GLOBAL VARIABLES
var SCROLL_TOP = 0;
var SCROLL_TOP_PREV = 0;
var TIMEOUT;
var MAX_RECORDS = 0;

var SR = 1;
var C = 50;

$(document).ready(function() {
  //Looking for max records
  setMaxCount();
  //Load the first 50 records
  $.ajax({
      url: './PartB/getUsers.php',
      type: 'GET',
      data: {
        sr: SR,
        c: C
      }
    })
    .done(function(data) {
      //Loading the data onto the page
      console.log(data);
      let users = $(data).find('user');
      displayRecordsFirst(users);
    })
    .fail(function(e) {
      console.log("Error loading data:" + e);
    });

  $(window).scroll(function() {
    clearTimeout(TIMEOUT);
    TIMEOUT = setTimeout(function() {
      if ($(window).scrollTop() + $(window).height() == $(document).height()) {
        scrollMoreBottom();
      } else {
        //We need to know if we are scrolling upwards or downwards
        SCROLL_TOP_PREV = SCROLL_TOP;
        SCROLL_TOP = $(window).scrollTop();
        if (SCROLL_TOP_PREV >= SCROLL_TOP) {
          if ($(window).scrollTop() <= $(window).height() * 2) {
            {
              scrollMoreTop()
            }
          }
        }
      }
    }, 50)

  });

});

var displayRecordsFirst = (records) => {
  $("#second").html('');
  let stringHtml = "";
  for (var i = 0; i < records.length; i++) {

    let firstName = $(records[i]).find('name').find('firstName').text();
    let lastName = $(records[i]).find('name').find('lastName').text();
    let city = $(records[i]).find('city').text();
    let country = $(records[i]).find('country').text();
    let email = $(records[i]).find('email').text();
    let gender = $(records[i]).find('gender').text();
    let pet = $(records[i]).find('pet').text();
    let petColour = $(records[i]).find('petColour').text();
    if (email == "")
    email = "N/A";

    stringHtml += "<div class='container-fluid col-md-3 entry'>"
    stringHtml += "<h3>" + firstName + " " + lastName + "</h3>";
    stringHtml += "<p><span class='spanLabel'>City:&nbsp;&nbsp;</span>" + city +"</p>";
    stringHtml += "<p><span class='spanLabel'>Country:&nbsp;&nbsp;</span>" + country +"</p>";
    if (email != "N/A")
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href='mailto:" + email +"'>"+ email +"</a></p>";
    else
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href=''>"+ email +"</a></p>";
    stringHtml += "<p><span class='spanLabel'>Gender:&nbsp;&nbsp;</span>" + gender +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet:&nbsp;</span>" + pet +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet Colour:&nbsp;&nbsp;</span>" + petColour +"</p>";
    stringHtml += "</div>"

  }
  $("#second").append(stringHtml);


}

var displayRecordsBottomScroll = (records) => {
  $("#first").html($("#second").html());
  $("#second").html('');
  let stringHtml = "";
  for (var i = 0; i < records.length; i++) {
    let firstName = $(records[i]).find('name').find('firstName').text();
    let lastName = $(records[i]).find('name').find('lastName').text();
    let city = $(records[i]).find('city').text();
    let country = $(records[i]).find('country').text();
    let email = $(records[i]).find('email').text();
    let gender = $(records[i]).find('gender').text();
    let pet = $(records[i]).find('pet').text();
    let petColour = $(records[i]).find('petColour').text();
    if (email == "")
    email = "N/A";

    stringHtml += "<div class='container-fluid col-md-3 entry'>"
    stringHtml += "<h3>" + firstName + " " + lastName + "</h3>";
    stringHtml += "<p><span class='spanLabel'>City:&nbsp;&nbsp;</span>" + city +"</p>";
    stringHtml += "<p><span class='spanLabel'>Country:&nbsp;&nbsp;</span>" + country +"</p>";
    if (email != "N/A")
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href='mailto:" + email +"'>"+ email +"</a></p>";
    else
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href=''>"+ email +"</a></p>";
    stringHtml += "<p><span class='spanLabel'>Gender:&nbsp;&nbsp;</span>" + gender +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet:&nbsp;</span>" + pet +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet Colour:&nbsp;&nbsp;</span>" + petColour +"</p>";
    stringHtml += "</div>"

  }
  $("#second").html(stringHtml);
}

var displayRecordsTopScroll = (records) => {
  $("#second").html($("#first").html());
  $("#first").html('');
  let stringHtml = "";
  for (var i = 0; i < records.length; i++) {
    let firstName = $(records[i]).find('name').find('firstName').text();
    let lastName = $(records[i]).find('name').find('lastName').text();
    let city = $(records[i]).find('city').text();
    let country = $(records[i]).find('country').text();
    let email = $(records[i]).find('email').text();
    let gender = $(records[i]).find('gender').text();
    let pet = $(records[i]).find('pet').text();
    let petColour = $(records[i]).find('petColour').text();
    if (email == "")
    email = "N/A";
    stringHtml += "<div class='container-fluid col-md-3 entry'>"
    stringHtml += "<h3>" + firstName + " " + lastName + "</h3>";
    stringHtml += "<p><span class='spanLabel'>City:&nbsp;&nbsp;</span>" + city +"</p>";
    stringHtml += "<p><span class='spanLabel'>Country:&nbsp;&nbsp;</span>" + country +"</p>";
    if (email != "N/A")
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href='mailto:" + email +"'>"+ email +"</a></p>";
    else
    stringHtml += "<p><span class='spanLabel'>Email:&nbsp;&nbsp;</span><a href=''>"+ email +"</a></p>";
    stringHtml += "<p><span class='spanLabel'>Gender:&nbsp;&nbsp;</span>" + gender +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet:&nbsp;</span>" + pet +"</p>";
    stringHtml += "<p><span class='spanLabel'>Pet Colour:&nbsp;&nbsp;</span>" + petColour +"</p>";
    stringHtml += "</div>"

  }
  $("#first").html(stringHtml);
}

var scrollMoreTop = () => {
  if (SR - C >= 1) {
    SR -= C;
    $.ajax({
        url: './PartB/getUsers.php',
        type: 'GET',
        data: {
          sr: SR,
          c: C
        }
      })
      .done(function(data) {
        //Loading the data onto the page
        let users = $(data).find('user');
        displayRecordsTopScroll(users);
        $('html, body').animate({
          scrollTop: $("#second").offset().top
        }, 50);
        $(window).scrollTop(0);
      })
      .fail(function(e) {
        console.log("Error loading data:" + e);
      });
  }
}

var scrollMoreBottom = () => {
  if (SR + C <= MAX_RECORDS)
  {
    SR += C;
    $.ajax({
        url: './PartB/getUsers.php',
        type: 'GET',
        data: {
          sr: SR,
          c: C
        }
      })
      .done(function(data) {
        //Loading the data onto the page
        let users = $(data).find('user');
        displayRecordsBottomScroll(users);
        $('html, body').animate({
          scrollTop: $("#second").offset().top
        }, 50);
        $(window).scrollTop($(document).height() - $(window).height() * 3);
      })
      .fail(function(e) {
        console.log("Error loading data:" + e);
      });
  }

}

var setMaxCount = () => {
  $.ajax({
        type: "GET" ,
        url: "./PartB/files/users.xml",
        dataType: "xml" ,
        success: function(xml) {
        MAX_RECORDS = ($(xml).find('user').length);
            }
    });
}
