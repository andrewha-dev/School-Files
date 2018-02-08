var _ = require('underscore');
var chalk = require('chalk');

var arr = [10, 5, 112,-34, -12, 45, 1, 51, -5, 234, 4, 556, -2];

console.log(_.max(arr));

console.log(_.countBy(arr, function(num){
	return num % 2 == 0 ? 'even' : 'odd';
}));

console.log(_.countBy(arr, function(num){
	return num > 0 ? 'greater' : 'less';
}));

console.log(chalk.red("Andrew Ha"))

console.log(chalk.black.bgWhite("Modules are cool"))
