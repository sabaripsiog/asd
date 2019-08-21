var m1,m2,m3,m4;





function func()
{
    m1=parseInt(document.getElementById("mark1").value,10);
    m2=parseInt(document.getElementById("mark2").value,10);
    m3=parseInt(document.getElementById("mark3").value,10);
    m4=parseInt(document.getElementById("mark4").value,10);
    var sum=m1+m2+m3+m4;
    document.getElementById("demo").value=sum;
    var average=(sum/4);
    document.getElementById("dem").value=average;
    var pass=0,fail=0;
    if (average>60)
    {
        pass=pass+1;
    }
    else
    {
        fail=fail+1;
    }
    document.getElementById("pass").value=pass;
    document.getElementById("fail").value=fail;
    
}

