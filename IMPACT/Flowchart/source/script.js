var m1=0,m2=0,m3=0,m4=0;
var i=0,j=0;
var grade=[0,1,2,3,4,5,6,7,8,9,10,11,12];
var pass=[0,0,0,0,0,0,0,0,0,0,0,0,0];
var fail=[0,0,0,0,0,0,0,0,0,0,0,0,0];
var total=[0,0,0,0,0,0,0,0,0,0,0,0,0];
var pp=[0,0,0,0,0,0,0,0,0,0,0,0,0];
var y;
var totalpass=0,totalfail=0,passpp=0;

function validate()
{
	grade[i]=document.getElementById("gr").value;
	y=grade[i];
    m1=parseInt(document.getElementById("mark1").value);
    m2=parseInt(document.getElementById("mark2").value);
    m3=parseInt(document.getElementById("mark3").value);
	m4=parseInt(document.getElementById("mark4").value);
	if(m1 == "" || m2 =="" || m3 == "" || m4 == "")
	{
		alert("Enter all marks");
	}else if(m1<0 || m1>100)
	{
		alert("Enter proper marks for English");
		return false;
	}else if(m2<0 || m2>100)
	{
		alert("Enter proper marks for Mathematics");
		return false;
	}else if(m3<0 || m3>100)
	{
		alert("Enter proper marks for Science");
		return false;
	}else if(m4<0 || m4>100)
	{
		alert("Enter proper marks for Social Studies");
		return false;
	}else{
		func();
		return true;
	}
}


function func()
{
	grade[i]=document.getElementById("gr").value;
	y=grade[i];
    
    //validate();
    var sum=m1+m2+m3+m4;
    document.getElementById("demo").value=sum;
    var average=(sum/4);
    document.getElementById("dem").value=average;
    if (average>=60)
    {
        pass[y]++;
		total[y]++;
    }
    else
    {
        fail[y]++;
		total[y]++;
    }
	pp[y]=(pass[y]/total[y])*100;
	pp[y]=pp[y].toFixed(0);
    }

function display()
{   
    var u="<hr>"
    var d="<pre>";
    var s="Grade     Total     Pass     Fail     Average";
	var f="</pre";
	var o="<br>";
	var m="<br>";
	for(i=1;i<10;i++)
	{
    var l="  "+grade[i]+"         "+total[i]+"        "+pass[i]+"        "+fail[i]+"         "+pp[i];
	o+=l;
	o+=m;
	}
	for(i=10;i<13;i++)
	{
    var l="  "+grade[i]+"        "+total[i]+"        "+pass[i]+"        "+fail[i]+"         "+pp[i];
	o+=l;
	o+=m;
	}
	for(i=1;i<13;i++)
	{
	totalpass=totalpass+pass[i];
	totalfail=totalfail+fail[i];
	}
	var tot=totalpass+totalfail;
	if(tot!=0)
	{
	var passpp=(totalpass/tot)*100;
	}
	else{
		passpp=0;
	}
	passpp=passpp.toFixed(0);
	var t=" "+"All"+"        "+tot+"        "+totalpass+"        "+totalfail+"         "+passpp;
    document.getElementById("Result").innerHTML=d+u+s+u+o+u+t+u+f;
}
function reset()
{
	document.getElementById("mark1").value="";
	document.getElementById("mark2").value="";
	document.getElementById("mark3").value="";
	document.getElementById("mark4").value="";
	document.getElementById("demo").value="";
	document.getElementById("dem").value="";
}
