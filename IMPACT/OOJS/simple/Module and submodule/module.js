const mobile = (function(){  //module
    var brand = 'Lenevo';
    var model = 'Z6 Pro';
    var original_price = 30000;
    var discount_percent = 8;

    var discounted_value = function(){  
        return (original_price*(100-discount_percent)/100);
    }

    var tax_percent = 2.5;


    var final_price = (function (){  //submodule
        return (discounted_value()*(tax_percent+100)/100);
    })();

    console.log(`The offer price of ${brand} ${model} mobile with tax is`+` `+ final_price);
}
)();