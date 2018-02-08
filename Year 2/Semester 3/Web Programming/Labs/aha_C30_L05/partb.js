var myModule = require('./bModules.js')
console.log(myModule.area(3))
console.log(myModule.areaRect(4,6))
console.log(myModule.perimRect(4, 6));
console.log(myModule.isTriangle(3,4,5))
console.log(myModule.isTriangle(3,4,8))

console.log(myModule.area(myModule.areaRect(2,3)))