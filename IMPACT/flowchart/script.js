var m1=new Array();
var m2=new Array();
var m3=new Array();
var m4=new Array();
var sum=new Array();
var average=new Array();
//var fail=new Array();
//var pass=new Array();
//var totstu=new Array();
var passpp=new Array();
var gradcount=1;
var grade=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
var i,y;
var x=0;
var pass=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
var fail=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
var passpp=["0","0","0","0","0","0","0","0","0","0","0","0","0"];
var totstu=["0","0","0","0","0","0","0","0","0","0","0","0","0"];

function func()
{
    grade[x]=document.getElementById("gr").value;
    m1[x]=parseInt(document.getElementById("mark1").value);
    m2[x]=parseInt(document.getElementById("mark2").value);
    m3[x]=parseInt(document.getElementById("mark3").value);
    m4[x]=parseInt(document.getElementById("mark4").value);
    
    check();
    x++;
}

function check()
{
    sum[x]=m1[x] + m2[x] + m3[x] + m4[x];
    document.getElementById("demo").value=sum[x];
    average[x]=(sum[x]/4);
    document.getElementById("dem").value=average[x];
    if (average[x]>=60)
    {
        pass[grade[x]]++;
        totstu[grade[x]]++;
    }
    else
    {
        fail[grade[x]]++;
        totstu[grade[x]]++;
    }
    passpp[grade[x]]=(pass[grade[x]]/totstu[grade[x]])*100;
    
}

function display()
{
    var print="<hr/>";
    var k="Grade  No.of.students  pass fail passpercent <br/>";
    for(i=1;i<=12;i++)
    {
    
    
    print+=i+totstu[i]+pass[i]+fail[i]+passpp[i]+"<br/>";
    document.getElementById("Result").innerHTML=k+print;

    document.getElementById("pass").value=pass[i];
    document.getElementById("fail").value=fail[i];
    document.getElementById("totstu").value=totstu[i];
    document.getElementById("passpp").value=passpp[i];
    }
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

