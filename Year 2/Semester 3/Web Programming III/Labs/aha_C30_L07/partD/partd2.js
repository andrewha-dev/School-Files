/**
 * Created by 1435792 on 10/19/2016.
 */
var owner = require('./owner2');


var testObject = {FakeAttribute: "wadawdaw"}
var ownerObject = owner.getInformation(testObject);
console.log(ownerObject.getFirstName());
console.log(ownerObject.getLastName());
console.log(ownerObject.getEmailAddress());
console.log(ownerObject.getPhoneNumber());

console.log(ownerObject.getAllInfo());