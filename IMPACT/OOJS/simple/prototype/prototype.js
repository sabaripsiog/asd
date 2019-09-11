function System(OpSys,processor,RAMgb){
    this.OpSys = OpSys;
    this.processor = processor; 
    this.RAMgb = RAMgb;

    this.display = function(){
        console.log(`Operating system : ${this.OpSys}`);
        console.log(`Processor : ${this.processor}`);
        console.log(`Memory(RAM) : ${this.RAMgb} GB`);
    }
}

let system1 = new System('Windows', 'Intel i5', 8);
system1.display();

const computer={
    brand : 'DELL',
    mouse : true,
    price : 30000
};

System.prototype = computer;

console.log(system1.brand); // returns undefined since there was no prototype object while declaring system1

let system2 = new System('Windows', 'Intel i6', 8);

console.log(system2.brand); // returns DELL
console.log(system2.mouse); // returns true

//now let us completely change the prototype

const laptop = {
    brand : 'Apple',
    keyboard : false,
}

System.prototype = laptop;

let system3 = new System('iOS 12','Intel i5', 16);

console.log(system3.mouse); // returns undefined as the prototype is completely changed

console.log(system2.price); // returns previous prototype property value as the object is still associated with it


console.log(system3.brand); //returns latest value
console.log(system3.keyboard);
system3.display();