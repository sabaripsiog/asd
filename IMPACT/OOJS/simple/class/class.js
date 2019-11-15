class Devices
{
    
}
function Television(brand,inch,price)
{
    this.brand = brand;
    this.inch = inch;
    this.price = price;
    this.display = function (){
        console.log(`This is ${this.brand} TV of size ${this.inch} inches and costs Rupees ${this.price}.`);
    } 
}

// the above constructor function can be used create a class of objects


const object1 = new Television('Onida', 40, 30000);

object1.brand = 'LG'; //changes the brand name to 'LG'

const object2 = new Television('Toshibha', 55, 60000);

console.log(object1);
object1.display();

console.log(object2);
object2.display();

