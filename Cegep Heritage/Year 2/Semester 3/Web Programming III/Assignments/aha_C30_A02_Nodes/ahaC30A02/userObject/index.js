/**
 * Created by 1435792 on 10/27/2016.
 */
var User = function () {
    this.data = {
        firstName: null,
        lastName: null,
        username: null,
        emailAddress: null,
        phoneNum: null

    };
    this.fill = function(values){
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
    this.setUsername = function(fn)
    {
        this.data.username = fn;
    }
    this.setEmailAddress = function(fn)
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
    this.getUsername = function(fn)
    {
        return this.data.username;
    }
    this.getEmailAddress = function(fn)
    {
        return this.data.emailAddress;
    }
    this.getPhoneNumber = function(fn)
    {
        return this.data.phoneNum;
    }
    this.getAllInfo = function(){
        return this.data;
    }
}

exports.returnObject = function(attributes){
    var thisInstance = new User();
    thisInstance.fill(attributes);
    return thisInstance;
}