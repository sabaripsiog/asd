var retailer = 'Amazon'; //global variable, becomes a property of global object

console.log(window.retailer); // window is the global object

console.log(this.retailer); //this points to the window objects

let place = 'Chroma';

console.log(window.place); // returns undefined because place is not window object property since it is declared with let, still can be used anywhere in the program

const Television = {
    brand : 'TCL',
    inch : 32,
    price : 25000,
    details : function(){
        console.log(`We bought this ${this.inch}inch ${this.brand} TV for ${this.price} at ${retailer}`); 
    }
}

Television.details();