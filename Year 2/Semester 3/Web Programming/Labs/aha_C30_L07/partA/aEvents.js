/**
 * Created by 1435792 on 10/19/2016.
 */
var emitter = require('events');
var myMath = new emitter();

var myAdd = function(a, b){
    console.log(a + b);
}

var mySubtract = function(a, b){
    console.log(a - b);
}

var myMultiply = function(a, b){
    console.log(a * b);
}

var myDivide = function(a, b){
    console.log(a/b);
}

myMath.on('event', myAdd)

myMath.on('event', mySubtract);

myMath.on('event', myMultiply);

myMath.on('event', myDivide);


myMath.emit('event', 100,2);
