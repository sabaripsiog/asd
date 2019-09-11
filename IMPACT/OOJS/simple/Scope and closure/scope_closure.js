function Mobile(brand,inch,price){
    var brand1 = brand;
    var inch1 = inch;
    var price1 = price;


Mobile.prototype.camera = function(){
    front_camera = '12MP';

    return function(back_camera){
        console.log(`This ${brand1} phone has ${front_camera} Front Camera and ${back_camera} Back Camera`);
        console.log(`It has ${inch1} inch screen diplay and costs Rupees ${price1}.`)
    }

}
}

const mobile = new Mobile('Sony', 6, 40000);

var z = mobile.camera();

z('16MP');