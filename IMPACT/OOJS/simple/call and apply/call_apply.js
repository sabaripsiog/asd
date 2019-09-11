// ------------- Call method -------------

const device1 = {
    type : 'laptop',
    display : function(color){
        console.log(`The color of this ${this.type} is ${color}`);
    }
};

device1.display('blue');

const device2 = {
    type : 'phone',
};

device1.display.call(device2,'red');

// ------------- Apply method ---------------------

const object1 = {
    details : function(year,warranty){
        console.log(`This model was introduced in ${year} and it has warranty period of ${warranty} years.`);
    }
};

const object2 = {
    type : 'washing machine',
    load : 'front',
    capacity : 6.5,
    specification : function(){
        console.log(`This ${this.load} load ${this.type} has a capacity of ${this.capacity} kgs.`);
    }
};

object2.specification();
object1.details.apply(object2,[2015,2]);