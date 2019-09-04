var current_page = 1;
var records_per_page =5;
function dis()
{
    if(document.getElementById("pnum").value == "" || document.getElementById("pnum").value <=0)
    {
        alert("Records per page should be a positive value");
    } else if(document.getElementById("pnum").value > Object.keys(database).length)
    {
        alert("Enter a smaller value");
    } else {
    records_per_page=document.getElementById("pnum").value;
    current_page = 1;
    deleteall();
    changePage(current_page);
    }
}
function go_to_page()
{
    if(document.getElementById("goto").value == "" || document.getElementById("goto").value <=0)
    {
        alert("Should be a positive value");
    } else if(document.getElementById("goto").value > numPages())
    {
        alert("Enter a smaller value");
    } else {
        current_page=document.getElementById("goto").value;
        deleteall();
        changePage(current_page);
    }
}
function prevPage()
{
    if (current_page > 1) {
        current_page--;
        deleteall();
        changePage(current_page);
        
    }
}
function nextPage()
{
    if (current_page < numPages()) {
        current_page++;
        deleteall();
        changePage(current_page); 
    }
}
function changePage(page)
{
    
var page_span = document.getElementById("page");

    // Validate page
    if (page < 1) page = 1;
    if (page > numPages()) page = numPages();
    


    for (var i = (page-1) * records_per_page; i < (page * records_per_page)  && i < objectCopy.length; i++)
    {
        var table = document.getElementById("itemList").getElementsByTagName('tbody')[0];
        var newRow = table.insertRow(table.length);
        cell1 = newRow.insertCell(0);
        cell1.innerHTML = `<input type="checkbox">`;
        cell2 = newRow.insertCell(1);
        cell2.innerHTML = objectCopy[i].itemName;
        cell3 = newRow.insertCell(2);
        cell3.innerHTML = objectCopy[i].category;
        cell4 = newRow.insertCell(3);
        cell4.innerHTML = objectCopy[i].price;
        cell5 = newRow.insertCell(4);
        cell5.innerHTML = objectCopy[i].available;
        cell5 = newRow.insertCell(5);
        cell5.innerHTML = `<a onClick="onRead(this)">Read</a>
                       <a onClick="onEdit(this)">Edit</a>
                       <a onClick="onDelete(this)">Delete</a>`;
    }
  
    page_span.innerHTML = page;

    if (page == 1) {
        document.getElementById("btn_prev").disabled = true;
    } else {
        document.getElementById("btn_prev").disabled = false;
    }

    if (page == numPages()) {
        document.getElementById("btn_next").disabled = true;
    } else {
        document.getElementById("btn_next").disabled = false;
    }
}

function numPages()
{
    return Math.ceil(Object.keys(objectCopy).length / records_per_page);
}


window.onload = function() {
    changePage(1);
  
};

 
function deleteall()
{
var table = document.getElementById("itemList");
for(var i = table.rows.length - 1; i > 0; i--)
{
table.deleteRow(i);
}
}