const device = {
    color : 'red',
    display : 'HD',
    switch_on : function(){
        console.log(`The device is switched on`);
    }
};

const mobile = Object.create(device); // prototype inheritance

console.log(mobile); //shows blank object since it does not have properties on its own

mobile.switch_on(); // but it can access the properties of device
console.log(mobile.log);

var a = Object.getPrototypeOf(mobile);

console.log(a); // returns device object as it becomes the prototype of mobile
