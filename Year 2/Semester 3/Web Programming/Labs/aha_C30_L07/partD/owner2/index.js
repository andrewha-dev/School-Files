/**
 * Created by 1435792 on 10/19/2016.
 */
var Owner = function(){
    this.data = {
        firstName: null,
        lastName: null,
        emailAddress: null,
        phoneNumber: null
    };
    this.fill = function(values){
        //Filling in the parameters first;
        this.data.firstName = "John";
        this.data.lastName = "Doe";
        this.data.emailAddress =  "none@gmail.com";
        this.data.phoneNumber = "123-456-7890";
        for (var attributes in this.data){
            if (values[attributes] !== undefined)
            {
                this.data[attributes] = values[attributes];
            }
        }
    };
    this.setFirstName = function(fn)
    {
        this.data.firstName = fn;
    }
    this.setLastName = function(fn)
    {
        this.data.lastName = fn;
    }
    this.setEmaiAddress = function(fn)
    {
        this.data.emailAddress = fn;
    }
    this.setPhoneNumber = function(fn)
    {
        this.data.phoneNumber = fn;
    }
    this.getFirstName = function(fn)
    {
        return this.data.firstName;
    }
    this.getLastName = function(fn)
    {
        return this.data.lastName;
    }
    this.getEmailAddress = function(fn)
    {
        return this.data.emailAddress;
    }
    this.getPhoneNumber = function(fn)
    {
        return this.data.phoneNumber;
    }
    this.getAllInfo = function(){
        return this.data;
    }
}

exports.getInformation = function(attributes){
    var thisInstance = new Owner();
    thisInstance.fill(attributes);
    return thisInstance;
}




