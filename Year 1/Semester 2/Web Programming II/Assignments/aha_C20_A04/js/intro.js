$(document).ready(function(){
    if (localStorage.getItem("firstName") != null && localStorage.getItem("lastName") != null && localStorage.getItem("phoneNum") != null &&
    localStorage.getItem("pCode") != null && localStorage.getItem("bankRoll") != null && localStorage.getItem("lastVisit") != null)
{
    window.location.href = "./game.html";
    
}

});
var getId = function(id) {
   return document.getElementById(id);
};

var input = function(){
    var firstName = getId("firstName");
    var lastName = getId("lastName");
    var phoneNumber = getId("phoneNumber");
    var postalCode = getId("postalCode");
    var betAmount = getId("betAmount");
    var buttonSubmit = getId("submit");
    firstName.addEventListener('blur', function(){getDataBlur(firstName.value, "firstName")}, false);
    lastName.addEventListener('blur', function(){getDataBlur(lastName.value, "lastName")}, false);
    phoneNumber.addEventListener('blur', function(){getDataBlur(phoneNumber.value, "phoneNumber"), false});
    postalCode.addEventListener('blur', function(){getDataBlur((postalCode.value).toUpperCase(), "postalCode"), false});
    betAmount.addEventListener('blur', function(){getDataBlur(betAmount.value, "betAmount")}, false);
   
    
    $("#userDataForm").submit(function(){
        validateAll();
        
    });
    
    var validateAll = function() {
    var isValid = false;
    isValid = validate(firstName.value, "firstName");
    isValid = validate(lastName.value, "lastName");
    isValid = validate(phoneNumber.value, "phoneNumber");
    isValid = validate(postalCode.value, "postalCode");
    isValid = validate(betAmount.value, "betAmount");
    
    return isValid;

};
    getId("userDataForm").onsubmit = validateAll;
    
};

var getDataBlur = function(value, id){
    validate(value, id);
    
    
    
    
};
input();

var validate = function(value, id){
    var compareTo;
    var isValid = false;
    if (id == "firstName")
    {
        
        compareTo = /^[A-Z][A-z]*$/;
        var isTrue = compareTo.test(value);
        if (isTrue)
        {
            getId("firstName").style.backgroundColor = "#90EE90";
            isValid = true;
            localStorage.setItem("firstName", getId("firstName").value );
        }
        if (!isTrue)
        {
        getId("firstName").style.backgroundColor = "#ef3d47";
        isValid = false;
        }
    }
    if (id == "lastName")
    {
        compareTo = /^[A-Z][A-z]*$/;
        isTrue = compareTo.test(value);
        if (isTrue)
        {
            getId("lastName").style.backgroundColor = "#90EE90";
            isValid = true;
        }
        if (!isTrue)
        {
            getId("lastName").style.backgroundColor = "#ef3d47";
            isValid = false;
        }
    }
    if (id == "phoneNumber")
    {
        compareTo =  /(\(\d{3}\)\s\d{3}\-\d{4})|(^\d{3}\.\d{3}\.\d{4}$)/;
        isTrue = compareTo.test(value);
        if (isTrue)
        {
        getId("phoneNumber").style.backgroundColor = "#90EE90";
        isValid = true;
        }
        if (!isTrue)
        {
        getId("phoneNumber").style.backgroundColor = "#ef3d47";
        isValid = false;
        }
    }
    if (id == "postalCode")
    {
    
     compareTo = /^[\D]{1}[\d]{1}[\D]{1}[\s]{1}[\d]{1}[\D]{1}[\d]{1}$/   ;
     isTrue = compareTo.test(value);
    if (isTrue)
    {
        getId("postalCode").style.backgroundColor = "#90EE90";
        getId("postalCode").value = value.toUpperCase();
        isValid = true;
    }
    if (!isTrue) 
    {
    getId("postalCode").style.backgroundColor = "#ef3d47";
    isValid = false;
    }
    }
    if (id == "betAmount")
    {
        compareTo = /^[\d]{1,4}$/;
        isTrue = compareTo.test(value);
        var isDecimal = value.indexOf(".");
        if (isDecimal != -1)
        isTrue = false;
        if (parseInt(value) < 5 || parseInt(value) > 5000)
        isTrue = false;
        if (isTrue)
        {
        getId("betAmount").style.backgroundColor = "#90EE90";
        isValid = true;
        }
        if (!isTrue)
        {
        getId("betAmount").style.backgroundColor = "#ef3d47";
        isValid = false;
        }
    }
        if (isValid == true)
        {
            if (window.localStorage)
            {
            localStorage.setItem("firstName", getId("firstName").value );
            localStorage.setItem("lastName", getId("lastName").value);
            localStorage.setItem("phoneNum", getId("phoneNumber").value);
            localStorage.setItem("pCode", getId("postalCode").value);
            localStorage.setItem("bankRoll", getId("betAmount").value)
            var date = new Date();
            date = date.toUTCString();
            localStorage.setItem("lastVisit", date);
            
            }
        }
        return isValid;
};
$(document).ready(function(){
$("#userDataForm").validate({
    rules: {
        FirstName: {
            firstNameRegex: true
            
        },
        LastName: {
            lastNameRegex: true
        },
        phoneNumber: {
            phoneNumberRegex: true
        },
        postalCode: {
            postalCodeRegex: true
        },
        betAmount: {
            betAmountRegex: true
        }
        
    },
    messages: {
        FirstName: "Please Enter A Valid First Name",
        LastName: "Please Enter A Valid Last Name",
        phoneNumber: "Please Enter A Valid Phone Number",
        postalCode: "Please Enter A Valid Postal Code",
        betAmount: "Please Enter A Valid Bet Amount"
    },
    submitHandler: function(form)
    {
        form.submit();
    }
})

$.validator.addMethod("firstNameRegex", function(value){
    return /^[A-Z][A-z]*$/.test(value);
}, "Please Enter A Valid First Name");

$.validator.addMethod("lastNameRegex", function(value){
    return /^[A-Z][A-z]*$/.test(value);
}, "Please Enter A Valid Last Name");

$.validator.addMethod("phoneNumberRegex", function(value){
    return /(\(\d{3}\)\s\d{3}\-\d{4})|(^\d{3}\.\d{3}\.\d{4}$)/.test(value);
}, "Please Enter A Valid Phone Number");

$.validator.addMethod("postalCodeRegex", function(value){
    return /^[\D]{1}[\d]{1}[\D]{1}[\s]{1}[\d]{1}[\D]{1}[\d]{1}$/.test(value);
}, "Please Enter A Valid Postal Code");

$.validator.addMethod("betAmountRegex", function(value){
    if (value > 5000 || value < 0)
    {
        return false;
    }
    return /^[\d]{1,4}$/.test(value);
}, "Please Enter A Valid Bet Amount");
});