//Converts The Card Objects To An Array
$(document).ready(function(){
    if (localStorage.getItem("firstName") != null && localStorage.getItem("lastName") != null && localStorage.getItem("phoneNum") != null &&
    localStorage.getItem("pCode") != null && localStorage.getItem("bankRoll") != null && localStorage.getItem("lastVisit") != null)
    {
        $("h4").text("Welcome Back : " + localStorage.getItem("firstName") + " " + localStorage.getItem("lastName"));
    }
    else 
    window.location.href = "./intro.html"

const winsTemplate = 
[
        [0,4,20,24, 10],//Outside Corners
         
        [6,8,16,18, 10],//Inside Corners
         
        [3,4,8,9, 20],//Postage Stamp
        
        [2,10,14,22, 10],//Outside Diamond
        
        [7,11,13,17, 10], //Inside Diamond
        
        [0,6,12,18,24, 2], //Diagonal
        
        [4,8,12,16,20, 2], //Diagonal
    
        [0,5,10,15,20, 5], //vertical
       
        [1,6,11,16,21, 5], // Vertical
       
        [2,7,12,17,22, 5], //Vertical
       
        [3,8,13,18,23, 5], //Vertical
       
        [4,9,14,19,24, 5], //Vertical
         
        [0,1,2,3,4, 3], //Horizontal
        
        [5,6,7,8,9, 3], //Horizontal
        
        [10,11,12,13,14, 3], //Horizontal
        
        [15,16,17,18,19, 3], //Horizontal
        
        [20,21,22,23,24, 3], //Horizontal
        
        [0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24, 250] //Fullhouse
    ] ;
    
var ConvertCardToNumbers = function(array){
    var array2 = array;
    var newarray = new Array();
    var numbers = [];
    for (var i = 0; i < 5; i++){
        for (var j = 0; j < 5; j++)
        {
            newarray.push(array2[j][i]);
        }
    }
    for (i = 0; i < newarray.length; i++){
        if (newarray[i].clicked == true){
            numbers.push(i);
        }
    }
    return numbers;
};
//Passes In A Card 
var checkingWinnings = function(card, bet){
    
    var betAmount = bet;
    var cardNumbers = ConvertCardToNumbers(card);
    var allTrue = [];
    var totalAllTrue = false;
    var winnings = 0;
    
    for (var i = 0; i < winsTemplate.length; i++){
        totalAllTrue = false;
        allTrue = [];
        for (var k = 0; k < cardNumbers.length; k++){
            for (var j = 0; j < winsTemplate[i].length-1; j++){
                if (winsTemplate[i][j] == cardNumbers[k]){
                    allTrue.push(true);
                }
            }
        }
        totalAllTrue = true;
        if(allTrue.length != winsTemplate[i].length-1){
            totalAllTrue = false;
        }
        if (totalAllTrue){
            winnings += (betAmount * winsTemplate[i][winsTemplate[i].length-1]);
            if (winsTemplate[i][winsTemplate[i].length-1] == 250){
                winnings = (betAmount * 250);
            }
        }
        
    }
    return winnings;
};
var Generate = function(min, max, count){
    var used = [];
    var nums = [];
        
    for (var i = 0; i < max; i++){
        used[i] = false;
    }
        
    do{
        var newnum = Math.floor(Math.random() * (max - min) + min);
        if (used[newnum] != true){
            used[newnum] = true;
            nums.push({number: newnum, clicked: false});
        }
    }while(nums.length < count);
    return nums;
};



function Card(){ 
    var squareObjects = [[], [], [], [], []];
    
    squareObjects[0] = Generate(1, 15, 5); 
    squareObjects[1] = Generate(16, 30, 5); 
    squareObjects[2] = Generate(31, 45, 5); 
    squareObjects[3] = Generate(46, 60, 5);
    squareObjects[4] = Generate(61, 75, 5); 
    
    return squareObjects;
}
var tablesVisible;
var checkedCardOne;
var checkedCardTwo;
var checkedCardThree;
var generate = function (numberOfCards) {
    $("#toggletest").removeAttr('disabled');
    resetGame();
    clearInterval(globalInterval);
    clearInterval(setupInterval);
    clearInterval(setupInterval2);
    clearInterval(setupInterval3);
    clearInterval(setupInterval4);
    checkedCardOne = false;
    checkedCardTwo = false;
    checkedCardThree = false;
    globalCounter = 0;
    chances = 3;
    finished = false;
    unfadeCard();
    var bet = parseInt(document.getElementById("betAmount").value);
    var originalBetAmount = $("#startingCashInfo").text();
    var multiplier;
    if (numberOfCards == "one")
    multiplier = 1;
    if (numberOfCards == "two")
    multiplier = 2;
    if (numberOfCards == "three")
    multiplier = 3;
    var newBetAmount = (originalBetAmount - (bet*multiplier));
    var toStringNewCash = newBetAmount.toString();
    var removeMoney = bet;
    var winningNumbers = winningNumbersGet();
    // localStorage.setItem('bankRoll', toStringNewCash)
    // $("#startingCashInfo").text(localStorage.getItem('bankRoll'));
    
    
    
    var winnings = 0;
    checkLose();
    
    if (isNaN(removeMoney) || (checkBetPossible(numberOfCards) == false) || (bet > originalBetAmount))
    {
        window.alert("Enter a valid bet amount");
        return;
    }
    if (checkBetPossible(numberOfCards) == true){
        
    localStorage.setItem('bankRoll', toStringNewCash);
    }

   
    var tableName = document.getElementsByTagName("td");
    var cardNumbers = numberOfCards;
    var nothing = 0;
    if (cardNumbers == "one" || cardNumbers == "two" || cardNumbers == "three")
    {
        tablesVisible = 1;
    var numberCalled = document.getElementById("numbersMason");
    numberCalled.innerHTML = "Numbers Called: ";
     var oneCard = new Card();
     var twoCard = new Card();
     var threeCard = new Card();
    //Adding Numbers to First Card
    for(var i = 0; i < 5; i++){ 
              for(var j = 0; j < 5; j++){
                  tableName[nothing].innerHTML = (oneCard[j][i].number);
                  nothing++;
                  
              }
    }
    bet = bet;
     tableName[12].innerHTML = "Free";
    var replace = document.getElementById("startingCashInfo");
    var  newValue = parseInt(replace.textContent) - bet;
    replace.innerHTML = newValue;

    
    }
     
     if (cardNumbers == "two" || cardNumbers == "three")
    { 
     //Adding Numbers to Second Card
     tablesVisible = 2;
      for(i = 0; i < 5; i++){
              for(j = 0; j < 5; j++){
                  tableName[nothing].innerHTML = (twoCard[j][i].number);
                  nothing++;
                  
              }
    }
    
     tableName[37].innerHTML = "Free";
    newValue = parseInt(replace.textContent) - bet;
    replace.innerHTML = newValue;
    }
    
    if (cardNumbers == "three")
    {
        tablesVisible = 3;
     //Adding Numbers to Third Card
      for(i = 0; i < 5; i++){
              for(j = 0; j < 5; j++)
              {
                  tableName[nothing].innerHTML = (threeCard[j][i].number);
                  nothing++;
              }
    }
     tableName[62].innerHTML = "Free";
    newValue = parseInt(replace.textContent) - bet;
    replace.innerHTML = newValue;

     
    }
    localStorage.setItem('bankRoll', toStringNewCash)
    
    var winningNumbersFromGenerator = [];
    for (i = 0; i < winningNumbers.length; ++i)
        {
        var displayNumbers = parseInt(winningNumbers[i]);
        var letter;
             
        if (displayNumbers > 0 && displayNumbers <= 15)
        letter = "B";
        if (displayNumbers > 15 && displayNumbers <= 30)
        letter = "I";
        if (displayNumbers > 30 && displayNumbers <= 45)
        letter = "N";
        if (displayNumbers > 45 && displayNumbers <= 60)
        letter = "G";
        if (displayNumbers > 60 && displayNumbers <= 75)
        letter = "O";
             
        var toString = (letter + "-" + displayNumbers).toString();
             
        winningNumbersFromGenerator[i] = toString;
        }
        displayNumbersFn(winningNumbersFromGenerator);
        playGame(winningNumbers, oneCard, twoCard, threeCard);
};



window.onload = function() {
var oneCard = document.getElementById("oneCards");
var twoCard = document.getElementById("twoCards");
var threeCard = document.getElementById("threeCards");
oneCard.addEventListener('click',function(){ hideCard("tableTwo", "tableThree", "tableOne", "tableOne", "id", "one")}, false);
twoCard.addEventListener('click',function(){ hideCard("tableThree", "tableThree", "tableOne", "tableTwo", "id", "two")}, false);
threeCard.addEventListener('click',function(){ hideCard("id", "id", "tableOne", "tableTwo", "tableThree", "three")}, false);
var leaveButton = document.getElementById("leave");
leaveButton.addEventListener('click', leave, false );
var reset = document.getElementById('combineName');
reset.addEventListener('click', notUser, false);
var date = new Date();
date = date.toUTCString();
localStorage.setItem('lastVisit', date);



};


var hideCard = function(a, b, c, d, f, g){ //Hides Bingo Cards Based On The Dropdown Menu Selection
 
 document.getElementById(a).style.visibility = "hidden";
 document.getElementById(b).style.visibility = "hidden";
 document.getElementById(c).style.visibility = "visible";
 document.getElementById(d).style.visibility = "visible";
 document.getElementById(f).style.visibility = "visible";
 generate(g); //After Hiding The Bingo Card it Generates The Objects
 
} ;

var winningNumbersGet = function() {
 var winningNumbers = Generate(1,75,40);
        var _ret = [];
        for(var i = 0; i < winningNumbers.length; i++)
            _ret.push(winningNumbers[i].number);
        return _ret; 
};



var writing = function(replace){
    $("#numbersMason").append(replace + " ");
};

var dataFromForm = function(){

    var firstName, lastName, phoneNumber, postalCode, startingCash; 
    
    var formData = location.search;
    
    formData = formData.substr(1);
    while (formData.indexOf("+") != -1)
        {
        formData = formData.replace("+", " ");
        }
    
    var allTheData = formData.split("&");
    
    
    for (var i = 0; i < allTheData.length; i++)
        {
         allTheData[i] = unescape(allTheData[i]);
         var removeEqualSign = (allTheData[i].indexOf("=") + 1);
         allTheData[i] = allTheData[i].substr(removeEqualSign, allTheData[i].length);
         
        } 
    firstName = allTheData[0];
    lastName = allTheData[1];
    phoneNumber = allTheData[2];
    postalCode = allTheData[3];
    startingCash = allTheData[4]; 
    startingCash = startingCash;
    
    document.getElementById("firstNameInfo").innerHTML = localStorage.getItem('firstName');
    document.getElementById("lastNameInfo").innerHTML = localStorage.getItem('lastName');
    document.getElementById("phoneNumberInfo").innerHTML = localStorage.getItem('phoneNum');
    document.getElementById("postalCodeInfo").innerHTML = localStorage.getItem('pCode');
    $("#startingCashInfo").text(localStorage.getItem('bankRoll'));
    document.getElementById("lastVisit").innerHTML = localStorage.getItem('lastVisit');
    document.getElementById("combineName").innerHTML = "  " + localStorage.getItem('firstName') + " " + localStorage.getItem('lastName') + "?";
     
};
dataFromForm();

var checkLose = function() {
    var startingCash = document.getElementById("startingCashInfo").innerHTML;
    var amount = parseInt(startingCash);
     if (amount <= 0)
    {
        window.alert("You are out of money, you lose!");
        window.alert("It has come to our attention, you have lost all your money betting.");
        window.open('https://www.problemgambling.ca/Pages/Home.aspx','1457997469034','width=700,height=500,toolbar=0,menubar=0,location=0,status=1,scrollbars=1,resizable=1,left=0,top=0');
        
        var newBet = window.prompt("Enter New Bet Amount","Enter New Bet Amount");
        if (!isNaN(newBet))
        {
            document.getElementById("startingCashInfo").innerHTML =  newBet;
        }
        else 
            return;
        
        
    }
};

var checkBetPossible = function(numberOfCards) {
    var startingCash = document.getElementById("startingCashInfo").innerHTML;
    var amountLeft = parseInt(startingCash)
    var bet = parseInt($("#betAmount").val());
    var betValid = true;
    if (isNaN(amountLeft))
    {
        $("#startingCashInfo").text(0);
    }
    if (numberOfCards == "one")
    {
        bet = bet*1;
    }
    if (numberOfCards == "two")
    {
        bet = bet*2;
    }
    if (numberOfCards == "three")
    {
        bet = bet*3;
    }
    if ((amountLeft - bet) < 0){
     betValid = false; 
    }
    return betValid;
    
}

function leave()
{
    window.location = "./leave.html";
}


var notUser = function(){
localStorage.removeItem('firstName');
localStorage.removeItem('lastName');
localStorage.removeItem('phoneNum');
localStorage.removeItem('pCode');
localStorage.removeItem('bankRoll');
localStorage.removeItem('lastVisit');
localStorage.removeItem('testMode')
location.reload();
};

var globalInterval;
var displayNumbersFn = function(winningNumbersFromGenerator) {
    var winningsDisplay = winningNumbersFromGenerator;
    setUp(winningsDisplay);
    globalInterval = setInterval(function(){
        displayNumbersToScreen(winningsDisplay);
    }, 10000); //This is the amount of time between each number being called. Modify the number to change the timings
};
var globalCounter = 0;
var finished = true;
var displayNumbersToScreen = function(winnings)
{
    if (globalCounter == -1)
    {
        globalCounter = 0;
        finished = true;
    }
    writing(winnings[globalCounter]);
    globalCounter++;
 
    if (globalCounter > 39)
    {
        clearInterval(globalInterval);
        setTimeout(function() {
        globalCounter = -1;    
        }, 10000); //Waits 10 seconds after the last number is called before not allowing anymore input
        
    }
};

var chances = 3;
var playGame = function(winningNumbers, firstCard, secondCard, thirdCard)
{
    var tableName = document.getElementsByTagName("td");
    checkedCardOne = false;
    checkedCardTwo = false;
    checkedCardThree = false;
    if (globalCounter != -1)
    {   
        $("#tableOne td").on('click', function(e){
            checkForTestMode();
        var cardUno = firstCard;
        var clickCellNumber = $(this).text();
        if (validateIfLegal(winningNumbers, clickCellNumber) == true)
        {
            $(this).css("background-color", "green")
        }
        else 
        {
            if (globalCounter != -1)
            {
            $(this).css("background-color", "red")
            chances--;
            }
        }
        cardUno = markingCard(winningNumbers, cardUno, clickCellNumber);
        if (chances == 0)
        {
            cheatAnimation();
        }
        if (globalCounter == -1)
        {
            if (checkedCardOne == false)
            {
                fadeCard("#tableOne");
            var bet = $("#betAmount").val();
            var winnings = checkingWinnings(cardUno, bet);
                if (winnings != 0)
                {
                   clearInterval(setupInterval2);
                   clearInterval(setupInterval3);
                   clearInterval(setupInterval4);
                   animationWin("Card One", winnings); 
                   updateBet(winnings);
                   tableName[12].innerHTML = "Win";
                   winAnimation();
                }
                if (winnings == 0) {
                    clearInterval(setupInterval2);
                    clearInterval(setupInterval3);
                    clearInterval(setupInterval4);
                    animationLose("Card One", winnings);
                    tableName[12].innerHTML = "Lose";

                }
                checkedCardOne = true;
            }
        }
        });
        
        $("#tableTwo td").on('click', function(e){
            checkForTestMode();
        var cardDos = secondCard;
        var clickCellNumber = $(this).text();
        if (validateIfLegal(winningNumbers, clickCellNumber) == true)
        {
            $(this).css("background-color", "green")
        }
        else 
        {
            if (globalCounter != -1)
            {
            $(this).css("background-color", "red")
            chances--;
            }
        }
        cardDos = markingCard(winningNumbers, cardDos, clickCellNumber);
        if (chances == 0)
        {
            cheatAnimation();
        }
        if (globalCounter == -1)
        {
            clearInterval(setupInterval2);
            if (checkedCardTwo == false)
            {
                fadeCard("#tableTwo");
                var bet = $("#betAmount").val();
                var winnings = checkingWinnings(cardDos, bet);
                clearInterval(setupInterval2);
                if (winnings != 0)
                {
                    clearInterval(setupInterval2)
                    clearInterval(setupInterval3);
                    clearInterval(setupInterval4)
                    animationWin("Card Two", winnings);
                    updateBet(winnings);
                   tableName[37].innerHTML = "Win!"
                   winAnimation();
                    
                }
                if (winnings == 0)
                {
                    clearInterval(setupInterval2)
                    clearInterval(setupInterval3);
                    clearInterval(setupInterval4)
                    animationLose("Card Two", winnings);
                    tableName[37].innerHTML = "Lose"
                }
                checkedCardTwo = true;
            }
        }
        });
        
        $("#tableThree td").on('click', function(e){
            checkForTestMode();
        var cardTres = thirdCard;
        var clickCellNumber = $(this).text();
        if (validateIfLegal(winningNumbers, clickCellNumber) == true)
        {
            $(this).css("background-color", "green")
        }
        else 
        {
            if (globalCounter != -1)
            {
            $(this).css("background-color", "red")
            chances--;
            }
        }
        cardTres = markingCard(winningNumbers, cardTres, clickCellNumber);
        if (chances == 0)
        {
            cheatAnimation();
        }
        if (globalCounter == -1)
        {
            if (checkedCardThree == false)
            {
                fadeCard("#tableThree");
                var bet = $("#betAmount").val();
                var winnings = checkingWinnings(cardTres, bet);
                clearInterval(setupInterval2);
                if (winnings != 0)
                {
                    clearInterval(setupInterval2)
                    clearInterval(setupInterval3);
                    clearInterval(setupInterval4)
                    animationWin("Card Three", winnings);
                    updateBet(winnings);
                    tableName[62].innerHTML = "Win!"
                    winAnimation();
                }
                if (winnings == 0)
                {
                    clearInterval(setupInterval2)
                    clearInterval(setupInterval3);
                    clearInterval(setupInterval4)
                    animationLose("Card Three", winnings);
                    tableName[62].innerHTML = "Lose!"
                }
                checkedCardThree = true;
            }
        }
        });
    }
    
};
var markingCard = function(winningNumbers,cardToMark,cellNumber) {
     var updatedCard = cardToMark;
    if (validateIfLegal(winningNumbers, cellNumber) == true)
    {
        updatedCard = markTheCard(cardToMark, cellNumber);
    }
    return updatedCard;
};
var validateIfLegal = function(winningNumbers, cellNumber) {
    for (var i = 0; i < globalCounter+1; i++)
    {
        if (winningNumbers[i] == cellNumber || cellNumber == "Free")
        {
            return true;
        }
    }
};

var markTheCard = function(cardToMark, cellNumber) {
    var cardMark = cardToMark;
    for (var i = 0; i < cardMark.length; i++)
        for (var j = 0; j < cardMark[i].length; j++)
        {
            if (cellNumber == "Free")
            {
                cardMark[2][2].clicked = true;
                cardMark[2][2].number = "Free";
            }
            if (cardMark[i][j].number == cellNumber)
            {
                cardMark[i][j].clicked = true;
                return cardMark;
            }
        }
};
var resetGame = function() {
    $("#tableOne td").css("background-color", "white")
    $("#tableTwo td").css("background-color", "white")
    $("#tableThree td").css("background-color", "white")
}
var setupInterval;
var setUp = function(winningNums){
var c = document.getElementById('numbersCanvas');
var ctx = c.getContext('2d');
ctx.font = "bold 30pt Arial, serif";
setupInterval = setInterval(function(){
    if (finished != true)
    {
    scrollText(winningNums);
    }
    if (finished == true)
    {
        clearInterval(setupInterval);
    }
}, 25);


};

const dx = 4;
const startPosition = 1500;
var curr = startPosition;

var scrollText  = function(winningNums){
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    var counter = 0;
	ctx.fillStyle = "#"+randomColour();
	ctx.strokeStyle = "#"+randomColour();
	counter++;
	if (curr < -200)
		curr = startPosition;
	else 
		curr = curr - dx;
	
	ctx.clearRect(0,0,1500,600);
	if (globalCounter != -1)
	{
	ctx.clearRect(0,0,1500,600);
	if (globalCounter != 0)
	{
	ctx.font = "bold 30pt Arial, serif";
	ctx.fillText(winningNums[globalCounter-1], curr, 50);
	}
	ctx.font = "bold 10pt Arial, serif";
	ctx.fillText("Chances Left : " + chances , 50, 68);
	ctx.fillText("Numbers Called : " + (globalCounter) + " / 40" , 1300, 68);
	}
	if (globalCounter == -1)
	{
	    clearInterval(setupInterval);
	    secondSetUp();
	}
};

var randomColour = function() {
    var arrayOfColors = ["FFAE07"];
	return arrayOfColors[Math.round(Math.random()*1)];
};

var setupInterval2;
var secondSetUp = function(winningNums){
var c = document.getElementById('numbersCanvas');
var ctx = c.getContext('2d');
ctx.font = "bold 30pt Arial, serif";
setupInterval2 = setInterval(function(){
    scrollTextWin();
}, 25);


};
var scrollTextWin  = function(){
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    var counter = 0;
	ctx.fillStyle = "#"+randomColour();
	ctx.strokeStyle = "#"+randomColour();
	counter++;
	if (curr < -2000)
		curr = (startPosition+300);
	else 
		curr = curr - dx;
	
	ctx.clearRect(0,0,1500,600);

	ctx.font = "bold 30pt Arial, serif";
	ctx.fillText("The Game Has Finished! Please Click Each Card One More Time In Order To Validate Your Winnings", curr, 50);


};


var setupInterval3;
var animationWin = function(card, winnings) {
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    ctx.font = "bold 30pt Arial, serif";
    setupInterval3 = setInterval(function(){
    scrollTextBetWin(card, winnings);
}, 25);
};
var scrollTextBetWin  = function(card, winnings){
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    var counter = 0;
	ctx.fillStyle = "#"+randomColour();
	ctx.strokeStyle = "#"+randomColour();
	counter++;
	if (curr < -500)
		curr = (startPosition+300);
	else 
		curr = curr - dx;
	
	ctx.clearRect(0,0,1500,600);

	ctx.font = "bold 30pt Arial, serif";
	ctx.fillText("You have won $" + winnings + " from " + card + "!", curr, 50);
};

var setupInterval4;
var animationLose = function(card, winnings) {
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    ctx.font = "bold 30pt Arial, serif";
    setupInterval4 = setInterval(function(){
    scrollTextBetLose(card, winnings);
}, 25);
};
var scrollTextBetLose  = function(card, winnings){
    var c = document.getElementById('numbersCanvas');
    var ctx = c.getContext('2d');
    var counter = 0;
	ctx.fillStyle = "#"+randomColour();
	ctx.strokeStyle = "#"+randomColour();
	counter++;
	if (curr < -500)
		curr = (startPosition+300);
	else 
		curr = curr - dx;
	
	ctx.clearRect(0,0,1500,600);

	ctx.font = "bold 30pt Arial, serif";
	ctx.fillText("Sorry, " + card + " Doesn't Have A Bingo", curr, 50);
};

var updateBet = function(winnings){
    var newWinnings = parseInt($("#startingCashInfo").text()) + parseInt(winnings);
    $("#startingCashInfo").text(newWinnings);
    localStorage.setItem('bankRoll', newWinnings);
    
};

var cheatAnimation = function() {
    $("td").css('backgroundColor', 'red');
    alert("Unfortunately you have run out of chances - Restarting Game. You will not get your money back.");
    location.reload();
    
};
var winAnimation = function(){
    $(".panel").css('background-image','url(./images/Money.gif)')
    $(".panel").css('background-position','50% 50%')
    $(".panel").css('background-repeat','repeat')
    setTimeout(winUnanimate, 2000)
}

var winUnanimate = function() {
    $(".panel").css('background-image','none')
}


var fadeCard = function(id){
    $(id).animate({
        opacity: "0",
    }, 1000, function(){
        hideTable(id)
    });
};

var hideTable = function(id)
{
   $(id).css('visibility', 'hidden'); 
}
var unfadeCard = function(){
    $("#tableOne").css('opacity','1');
    $("#tableTwo").css('opacity', '1');
    $("#tableThree").css('opacity', '1');
};

$(document).ready(function(){
    if(localStorage.getItem('testMode') == "on"){
        $("#toggletest").prop('checked', true);
    }
    if ((localStorage.getItem('testMode') != "on"))
    {
        localStorage.setItem('testMode', "off");
    }
     
    $("#dialog").dialog({ autoOpen: false });
    $("#betaDialogue").on('click', function(){
    $("#dialog").dialog('open');
        });
        
    $("#toggletest").on('change', function(e){
    ($(this).is(":checked")) ? localStorage.setItem('testMode', "on") : localStorage.setItem('testMode', "off");
    });
});

var checkForTestMode = function() {
    $("#toggletest").attr('disabled', 'true');
    if ($("#toggletest").is(':checked'))
    {
        checkTable();
    }
};

var checkTable = function(){
    if (globalCounter == -1)
    {
    tablesVisible--;
    console.log(tablesVisible);
    if (tablesVisible < 1)
    {
        setTimeout(function(){
            location.reload();
        }, 10000)
    }
    }
}
window.onerror = function() {
    alert("An unexpected error event has occured");
    location.reload();
}

});       