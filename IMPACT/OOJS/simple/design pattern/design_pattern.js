let washing_machine = (function () {
    let warranty = 0;
    let product_name = 'Siemens';
  
    function addWarranty() {
      warranty += 1;
      console.log(`One year warranty added! Current warranty period is ${warranty} years`);
    }
  
    function displayName() {
      console.log(`Name: ${product_name}`);
    }

  
    return {
      name: displayName,
      warranty: addWarranty
    };
})();

washing_machine.name();                      // returns product name

washing_machine.product_name = 'LG';         // trying to change name

washing_machine.name();                      // does not change

washing_machine.warranty();                  //adds one year warranty 
washing_machine.warranty();                  //adds one more year to warranty