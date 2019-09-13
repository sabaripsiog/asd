function validate(phone) {
    const regex = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    if(regex.test(phone)==false){
    console.log(`Please enter a valid phone number.`);
    }else{
    console.log(regex.test(phone));
    }
}

function validateEmail(email) 
{
    var re = /\S+@\S+\.\S+/;
    if(re.test(email)==false){
    console.log(`Please enter a valid email ID.`);
    }else{
    console.log(re.test(email));
    }
}

validate('876328i45873567');  //false
validateEmail('sabarish.a@psiog.com');  //true
validateEmail('shdcjmhc@yahoo.com');    //true
validateEmail('shcjhs.comhskjc@');      //false
validate('6666667777');        //true