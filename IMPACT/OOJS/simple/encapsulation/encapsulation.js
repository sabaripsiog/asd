function details(){
    let brand  = 'Samsung';
    let inch = 45;
    let price = 65000;

    return{
        get_data : function ()
        {
            console.log(`This is ${brand} TV of size ${inch} inches and costs Rupees ${price}`);
        }
    }
}

let product = details(); // the object returned by details function is stored in a variable

product.get_data();

console.log(product.brand); // returns undefined because brand is not a property of returned object

//Other way around

television={
    brand : 'Onida',
    inch : 32,
    price : 25000,

    display : function (){
        floor = 5;
        console.log(`${this.brand} ${this.inch}inch TV of price is in ${floor}th floor.`)
    }
};

television.display();

television.brand = 'Panasonic';
television.inch = 40;
television.price = 35000;

television.display(); // displays new values given to the object's properties

console.log(television.floor); // returns undefined since floor is accessible to display key only