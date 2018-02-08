/**
 * Created by 1435792 on 10/19/2016.
 */
var Pet = function(){
    this.data = {
        name: null,
        breed: null,
        size: null,
        gender: null
    };
    this.fill = function(values){
        for (var attributes in this.data){
            if (values[attributes] !== undefined)
            {
                this.data[attributes] = values[attributes];
            }
        }
    };
    this.setName = function(fn)
    {
        this.data.name = fn;
    }
    this.setBreed = function(fn)
    {
        this.data.breed = fn;
    }
    this.setSize = function(fn)
    {
        this.data.size = fn;
    }
    this.setGender = function(fn)
    {
        this.data.gender = fn;
    }
    this.getName = function(fn)
    {
        return this.data.name;
    }
    this.getBreed = function(fn)
    {
        return this.data.breed;
    }
    this.getSize = function(fn)
    {
        return this.data.size;
    }
    this.getGender = function(fn)
    {
        return this.data.gender;
    }
    this.getAllInfo = function(){
        return this.data;
    }
}

exports.getInformation = function(attributes){
    var thisInstance = new Pet();
    thisInstance.fill(attributes);
    return thisInstance;
}


