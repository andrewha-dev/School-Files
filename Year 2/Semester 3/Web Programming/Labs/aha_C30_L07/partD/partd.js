/**
 * Created by 1435792 on 10/19/2016.
 */
var owner = require('./owner');
var pet = require('./pet');

var ownerTestAttributeObject = {firstName: "Andrew", lastName: "Ha", emailAddress: "IHaveNoEmail", phoneNumber: "IHaveNoPhone"};

var ownerObject = owner.getInformation(ownerTestAttributeObject);
console.log(ownerObject.getFirstName());
console.log(ownerObject.getLastName());
console.log(ownerObject.getEmailAddress());
console.log(ownerObject.getPhoneNumber());

ownerObject.setFirstName("SWAG");
ownerObject.setLastName("DAZED");
ownerObject.setPhoneNumber("911");
ownerObject.setEmaiAddress("1@1.com");

console.log("\nTESTING SETTERS\n")
console.log(ownerObject.getFirstName());
console.log(ownerObject.getLastName());
console.log(ownerObject.getEmailAddress());
console.log(ownerObject.getPhoneNumber());

var petTestAttributeObject = {name: "Satan", breed: "Fire", size: "Clifford", gender: "M"};
var petObject = pet.getInformation(petTestAttributeObject);

console.log("\nTestiing Pet Object")
console.log(petObject.getName());
console.log(petObject.getBreed());
console.log(petObject.getSize());
console.log(petObject.getGender());

petObject.setName("Lucifer");
petObject.setBreed("Flames");
petObject.setSize('CliffordsBrothersSizeWhichIsPrettyDamnHuge')
petObject.setGender('DID U JUST ASSUME MY GENDER!??!?!?');

console.log("\nChecking Sets")
console.log(petObject.getName());
console.log(petObject.getBreed());
console.log(petObject.getSize());
console.log(petObject.getGender());

console.log("Testing getInfo");
console.log(ownerObject.getAllInfo());
console.log(petObject.getAllInfo());