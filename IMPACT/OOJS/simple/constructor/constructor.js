function Mobile(brand,inch,price)
{
    this.brand = brand;
    this.inch = inch;
    this.price = price;
    this.display = function (){
        console.log(`This ${this.brand} mobile of size ${this.inch} inches costs Rupees ${this.price}.`);
    } 
}

// this Mobile constructor function can be used to create multiple objects

let mob1 = new Mobile('Apple', 5, 60000);
let mob2 = new Mobile('One plus', 6, 35000);

mob1.display();
mob2.display();