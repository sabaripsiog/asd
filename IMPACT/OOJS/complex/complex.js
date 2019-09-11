// ----- Nested Inheritance -------- //
function Home_appliance(emi,start){            //constructor
    this.warranty = 2;
    this.discount_percent = 15;
    this.product = function(){
        console.log(`This product has an offer starting from ${start} of this week where an EMI plan for ${emi} months can be availed.`);
    };
}

function Computer(brand,inch,price){
    this.details = function(){
        console.log(`This ${brand} ${inch} inch model costs Rupees ${price}.`);
    };
    this.monitor = function(){                               
        console.log(`The screen is sleek.`);
    };
}

function Laptop(){
    this.brand = 'Apple';
    this.storageGB = 256;  
}

function Television(){
    this.brand = 'Samsung';
    this.inch = 55;
}

// setting up nested inheritance chain
Computer.prototype = new Home_appliance();                 //prototype inheritance 
Laptop.prototype = new Computer();
Television.prototype = new Laptop();

var device1 = new Television();                           //class objects
var device2 = new Laptop();

//----- using call and apply ------ //
function Washing_machine()
{
    this.capacityKG = 6;
    Home_appliance.call(this);   //call
}

var device3 = new Washing_machine();

function Vaccum_cleaner()
{
    this.price = 10000;
    Home_appliance.apply(this,[12,'Friday']);    //apply
}

var device4 = new Vaccum_cleaner();

function New_device(brand,inch,price){
    this.brand = brand;
    Computer.apply(this,[brand,inch,price]);
}

var device5 = new New_device('DELL',24,30000);

function TV1(){
    let brand  = 'Samsung';                      // this data is encapsulated
    let inch = 45;                               // local variable
    let price = 65000;                           // has local scope

    return{
        get_data : function ()
        {
            console.log(`This is ${brand} TV of size ${inch} inches and costs Rupees ${price}.`);
        }
    }
}
var television1 = new TV1();

function OtherTV(name) {               //composite
    this.name = name;
}

OtherTV.prototype.display = function () {
    console.log(this.name);
}

function Device(name) {
    this.name = name;
    this.tv = [];
}

Device.prototype.add = function (tvs) {
    this.tv.push(tvs);
}

Device.prototype.getTVName = function (index) {
    return this.tv[index].name;
}

Device1 = new Device('First device set');

mob1 = new OtherTV('Toshiba');
mob2 = new OtherTV('TLC');

Device1.add(mob1);
Device1.add(mob2);

let goods = (function () {               //design pattern
    let warranty = device1.warranty; 
    function addWarranty() {
      warranty += 1;
      console.log(`One year warranty added! Current warranty period is ${warranty} years.`);
    }
    return {
      warranty: addWarranty
    };
})(device1.warranty);


a = function(){ console.log(`Customer :`);}
a();
(function abc(){             //IIFE
    console.log(`This laptop looks good.`);
})();
b = function(){console.log('Salesperson :');}
b();
console.log(`Product is from ` + device5.brand + ' P series.');
device5.details();
device4.product(); 
device2.monitor();
console.log(`Discount is `+device3.discount_percent +`percentage.`);
console.log(`Customer :`);(function abc(){             //IIFE
    console.log(`Can you also show me a LED TV?`);
})();
console.log('Salesperson :');
television1.get_data();
console.log(`The warranty is for `+ device1.warranty +` years.`);
a();
(function abc(){             
    console.log(`Is there any discount?`);
})();
b();
const module = (function(brand,model,original_price){  //module
    var discount_percent = 8;

    var final_price = (function(){    // submodule
        return (original_price*(100-discount_percent)/100);
    })();
    console.log(`The offer price of ${brand} ${model} TV with discount is`+` `+ final_price+`.`);
}
)('Samsung','QLED',65000);
a();
console.log(`Any other brands?`);
b();
console.log(Device1.getTVName(0)+` and `+Device1.getTVName(1));
a();
console.log(`No!! Samsung is fine. I'll pay through credit card.`);
b();
console.log(`Using card gives you one more year warranty.`);
goods.warranty.call(device5);
console.log(`Thanks for the purchase Sir.`);



