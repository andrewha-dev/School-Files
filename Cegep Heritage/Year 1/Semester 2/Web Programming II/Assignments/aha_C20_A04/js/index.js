$(document).ready(function (e){
    setTimeout(load, 5000)
    $("#fireworkOne").hide();
    $("#fireworkTwo").hide();
    $("#fireworkThree").hide();
    $("#buttonSkip").on('click', skip);
    $("#movingDragonRight").css('opacity', '0')
    $("#movingDragonLeft").css('opacity', '0');
    setTimeout(skip, 23000)
    
});

var load = function() {

    $("#doorleft").animate({
        // opacity: "0.3",

    },2000, function(){
    })
     $("#doorright").animate({
        // opacity: "0.3",
    },2000, function(){
    unhideDragon();
    })

    setTimeout(hideDoor, 500)
    setTimeout(expandCanvas, 501)
}   
var unhideDragon = function() {
    $("#movingDragonRight").css('opacity', '1')
    $("#movingDragonLeft").css('opacity', '1');
}

var hideDoor = function(){
    $("#doorleft").animate({
        left: "-43%"
    }, 3000)
    
    $("#doorright").animate({
        left: "90%"
    }, 3000)
}
var expandCanvas = function() {
    $("#canvasCenter").animate({
        width: "100%",
        left: "0%",
        
    }, 3000, drawFireWork);
}

var drawFireWork = function() {
    interval = setInterval(drawRocketShoot, 5);
}

var drawFireWorkGlobalVarYPos = 931;
var drawFireWorkIncrement = 4;


var drawRocketShoot = function() {
    var c = document.getElementById("canvasCenter");
    var ctx = c.getContext("2d");
    $("#canvasCenter").attr("width", "1511");
    $("#canvasCenter").attr("height", "931");
    $("#canvasCenter").css("width", "auto");
    ctx.clearRect(0,0,1511,931);
    ctx.beginPath();
    ctx.arc(300, drawFireWorkGlobalVarYPos, 5, 0, 2 * Math.PI, false)
    ctx.fillStyle = "#FFFFFF";
    ctx.fill();
    ctx.closePath();
    
    ctx.beginPath();
    ctx.arc(756, drawFireWorkGlobalVarYPos, 5, 0, 2 * Math.PI, false)
    ctx.fillStyle = "#FFFFFF";
    ctx.fill();
    ctx.closePath();
    
    ctx.beginPath();
    ctx.arc(1200, drawFireWorkGlobalVarYPos, 5, 0, 2 * Math.PI, false)
    ctx.fillStyle = "#FFFFFF";
    ctx.fill();
    ctx.closePath();
    
    
    drawFireWorkGlobalVarYPos -= drawFireWorkIncrement;
    if (drawFireWorkGlobalVarYPos <150)
    {
        ctx.clearRect(0,0,1511,931);
        clearInterval(interval);
        $("#fireworkOne").show();
        $("#fireworkTwo").show();
        $("#fireworkThree").show();
        setTimeout(hideFireWorks, 3000)
        setUp();
        moveDragon();
        setTimeout(fadeDragon, 2500);
    }
}
var hideFireWorks = function() {
    $("#fireworkOne").animate({
        opacity: "0",
    },10000);
    $("#fireworkTwo").animate({
        opacity: "0",
    },10000);
     $("#fireworkThree").animate({
        opacity: "0",
    },10000);
    // setTimeout(setUp, 4000)
}
var setUp = function(){
    //  $("#fireworkOne").hide();
    // $("#fireworkTwo").hide();
    // $("#fireworkThree").hide();
    
var c = document.getElementById('canvasCenter');
var ctx = c.getContext('2d');
ctx.font = "bold 40pt Arial, serif";
setInterval(scrollText, 50);


}

const dx = 10;
const startPosition = 1600;
var curr = startPosition;

var scrollText  = function(){
    var c = document.getElementById('canvasCenter');
    var ctx = c.getContext('2d');
    var counter = 0;
	ctx.fillStyle = "#"+randomColour();
	ctx.strokeStyle = "#"+randomColour();
	counter++;
	if (curr < -1200)
		curr = startPosition;
	else 
		curr = curr - dx;
	
	ctx.clearRect(0,0,1511,931)
	ctx.fillText("Welcome To The Eight Dragon Casino!", curr, 800);	
	
}

var randomColour = function() {
    var arrayOfColors = ["FFAE07", "CC0200", "FFFFFF", "D99406"];
	return arrayOfColors[Math.round(Math.random()*4)];
}

var moveDragon = function() {
    $("#movingDragonLeft").animate({
        left: "39%",
        top: "20%",
    }, 5000)
    $("#movingDragonRight").animate({
        left: "26%",
        top: "20%",
    }, 5000, function() {
        setTimeout(shrinkDragon, 3000)
    })
}
var shrinkDragon = function() {
    $("#movingDragonLeft").animate({
        width: "5px",
        height: "5px",
        opacity: "0",
        left: "50%",
        top: "50%"
    },5000)
    $("#movingDragonRight").animate({
        width: "5px",
        height: "5px",
        opacity: "0",
        left: "50%",
        top: "50%"
    },5000)
}
var skip = function() {
    window.location.href="./intro.html";
};
