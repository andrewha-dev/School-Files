$(document).ready(function(){
    var finalAmount = localStorage.getItem('bankRoll');
    console.log(finalAmount);
    $("#finalAmount").text("$" +  finalAmount);
    
    $("#signIn").on('click', function() {
        window.location = "./intro.html"
    })
})