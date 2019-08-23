var m1=0,m2=0,m3=0,m4=0;

var pass=0,fail=0,totstu=0,passpp=0;
var gradcount=1;
function func()
{
    m1=parseInt(document.getElementById("mark1").value);
    m2=parseInt(document.getElementById("mark2").value);
    m3=parseInt(document.getElementById("mark3").value);
    m4=parseInt(document.getElementById("mark4").value);
    var sum=m1+m2+m3+m4;
    document.getElementById("demo").value=sum;
    var average=(sum/4);
    document.getElementById("dem").value=average;
    check(average);
}
function check(average)
{
    
    if (average>=60)
    {
        pass=pass+1;
    }
    else
    {
        fail=fail+1;
    }
    totstu=pass+fail;
    passpp=(pass/totstu)*100;
    document.getElementById("pass").value=pass;
    document.getElementById("fail").value=fail;
    document.getElementById("totstu").value=totstu;
    document.getElementById("passpp").value=passpp;
}

function nextstu() 
{
    document.getElementById("mark1").value="";
    document.getElementById("mark2").value="";
    document.getElementById("mark3").value="";
    document.getElementById("mark4").value="";
    document.getElementById("demo").value="";
    document.getElementById("dem").value="";
}

 function assign()
{  
    gradcount = document.getElementById("gr").value;
    document.getElementById("gd").value= gradcount;
}