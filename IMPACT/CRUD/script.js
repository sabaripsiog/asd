var selectedRow = null;
var database;

database=[{ itemName: "Rice", category: "Foods", price: 50, available: 150 },
{ itemName: "Bed cover", category: "Household", price: 500, available: 20 },
{ itemName: "Lipstick", category: "Cosmetics", price: 400, available: 50 },
{ itemName: "Notebooks(Ruled)", category: "Stationery", price: 50, available: 78 },
{ itemName: "Tooth brush", category: "Household", price: 20, available: 75 },
{ itemName: "Eggs(dozen)", category: "Foods", price: 50, available: 50 },
{ itemName: "Basket", category: "Household", price: 70, available: 35 },
{ itemName: "Detergent", category: "Household", price: 90, available: 20 },
{ itemName: "Eye shadow", category: "Cosmetics", price: 250, available: 11 },
{ itemName: "Ink bottle(50ml)", category: "Stationery", price: 350, available: 25 },
{ itemName: "Tooth paste(200g)", category: "Household", price: 70, available: 70},
{ itemName: "Writing pad", category: "Stationery", price: 40, available: 20},
{ itemName: "Crayons box", category: "Stationery", price: 70, available: 10},
{ itemName: "Onion(1 kg)", category: "Foods", price: 40, available: 20},
{ itemName: "Milk(1 lit)", category: "Foods", price: 45, available: 100},
{ itemName: "Face powder", category: "Cosmetics", price: 60, available: 25},
{ itemName: "Cashew(100g)", category: "Foods", price: 110, available: 100},
{ itemName: "Plastic plate", category: "Household", price: 60, available: 30},
{ itemName: "Carrot(1 kg)", category: "Foods", price: 50, available: 18},
{ itemName: "Toor Dal(1 kg)", category: "Foods", price: 213, available: 17},
{ itemName: "Chilli(200g)", category: "Foods", price: 46, available: 14},
{ itemName: "Spoon", category: "Household", price: 8, available: 124},
{ itemName: "Calculator", category: "Stationery", price: 700, available: 12},
{ itemName: "Stapler box", category: "Stationery", price: 45, available: 23},
{ itemName: "Nail polish", category: "Cosmetics", price: 388, available: 17},
{ itemName: "Cookies(100g)", category: "Foods", price: 65, available: 50},
{ itemName: "Moisturizers", category: "Cosmetics", price: 107, available: 22},
{ itemName: "Cheese(100g)", category: "Foods", price: 185, available: 9},
{ itemName: "Urad Dal(1 kg)", category: "Foods", price: 97, available: 24},
{ itemName: "Foundation", category: "Cosmetics", price: 157, available: 5},
{ itemName: "Water color", category: "Stationery", price: 70, available: 10},
{ itemName: "Envelope cover", category: "Stationery", price: 5, available: 100},
{ itemName: "Almonds(100g)", category: "Foods", price: 174, available: 33},
{ itemName: "Geometry box", category: "Stationery", price: 50, available: 15},
{ itemName: "Rice cooker", category: "Household", price: 500, available: 10},
{ itemName: "Grinder", category: "Household", price: 2000, available: 8},
{ itemName: "Tomato(1 kg)", category: "Foods", price: 25, available: 25},
{ itemName: "Hole punch", category: "Stationery", price: 150, available: 10},
{ itemName: "Perfume", category: "Cosmetics", price: 166, available: 42},
];

var objectCopy = JSON.parse(JSON.stringify(database));


function onFormSubmit() {
    if (validate()) {
        var formData = readFormData();
        if (selectedRow == null)
            duplicate(formData);
        else
            updateRecord(formData);
        resetForm();
    }
}

function readFormData() {
    var formData = {};
    formData["itemName"] = document.getElementById("itemName").value;
    formData["category"] = document.getElementById("category").value;
    formData["price"] = document.getElementById("price").value;
    formData["available"] = document.getElementById("available").value;
    return formData;
}
function duplicate(data)
{   
    var datavalue =0;
    for(i=0;i<Object.keys(objectCopy).length;i++)
    {
      if(data.itemName==objectCopy[i].itemName)
      {
        
        datavalue=1;
        break;
      }
    }
	if(datavalue==1){
        alert("Record already exists");
        datavalue=0;
    }else{
        insertNewRecord(data);
    }
}    
function insertNewRecord(data) {
    
    var table = document.getElementById("itemList").getElementsByTagName('tbody')[0];
    var newRow = table.insertRow(table.length);
    cell1 = newRow.insertCell(0);
    cell1.innerHTML = `<input type="checkbox">`;
    cell2 = newRow.insertCell(1);
    cell2.innerHTML = data.itemName;
    cell3 = newRow.insertCell(2);
    cell3.innerHTML = data.category;
    cell4 = newRow.insertCell(3);
    cell4.innerHTML = data.price;
    cell5 = newRow.insertCell(4);
    cell5.innerHTML = data.available;
    cell5 = newRow.insertCell(5);
    cell5.innerHTML = `<a onClick="onRead(this)">Read</a>
                       <a onClick="onEdit(this)">Edit</a>
                       <a onClick="onDelete(this)">Delete</a>`;
    var obj={};
    obj["itemName"]= data.itemName;
    obj["category"]= data.category;
    obj["price"]= data.price;
    obj["available"]= data.available;
    database.push(obj);
    objectCopy.push(obj);
    
    
    current_page = numPages();
        deleteall();
        changePage(current_page);
}

function resetForm() {
    document.getElementById("itemName").value = "";
    document.getElementById("category").value = "";
    document.getElementById("price").value = "";
    document.getElementById("available").value = "";
    selectedRow = null;
}


var x ;
var indexrow;
function onEdit(td) {
    selectedRow = td.parentElement.parentElement;

    var x = selectedRow.rowIndex;
    indexrow = ((current_page-1)*records_per_page) + x ;
    document.getElementById("itemName").value = selectedRow.cells[1].innerHTML;
    document.getElementById("category").value = selectedRow.cells[2].innerHTML;
    document.getElementById("price").value = selectedRow.cells[3].innerHTML;
    document.getElementById("available").value = selectedRow.cells[4].innerHTML;
}

function updateRecord(formData) {
    selectedRow.cells[1].innerHTML = formData.itemName;
    selectedRow.cells[2].innerHTML = formData.category;
    selectedRow.cells[3].innerHTML = formData.price;
    selectedRow.cells[4].innerHTML = formData.available;

          objectCopy[indexrow-1].itemName = selectedRow.cells[1].innerHTML;
          objectCopy[indexrow-1].category = selectedRow.cells[2].innerHTML;
          objectCopy[indexrow-1].price = selectedRow.cells[3].innerHTML;
          objectCopy[indexrow-1].available = selectedRow.cells[4].innerHTML;
 
}
document.getElementById("undo").disabled = true;
var y;
var index_deleted_row;
function onDelete(td) {
    if (confirm('Are you sure to delete this record ?')) {
        row = td.parentElement.parentElement;
        y= row.rowIndex;
        index_deleted_row = ((current_page-1)*records_per_page) + y ;
        
        
        objectCopy.splice(index_deleted_row-1,1);
        resetForm();
        deleteall();
        changePage(current_page);
        document.getElementById("undo").disabled = false;
        
       
    }
}

function undo()
{
    var obj={};
    obj["itemName"]= database[index_deleted_row-1].itemName;
    obj["category"]= database[index_deleted_row-1].category;
    obj["price"]= database[index_deleted_row-1].price;
    obj["available"]= database[index_deleted_row-1].available;
    objectCopy.splice(index_deleted_row-1,0,obj);
    resetForm();
    deleteall();
    changePage(current_page);
    document.getElementById("undo").disabled = true;
    
    
}

function validate() {
    isValid = true;
    if (document.getElementById("itemName").value == "") {
        isValid = false;
        alert("Item name should be entered.");
    } else if(document.getElementById("category").value == "")
    {
        isValid = false;
        alert("Category should be entered.");
    } else if(document.getElementById("price").value == "")
    {
        isValid = false;
        alert("Price should be entered.");
    }else if(document.getElementById("price").value < 0)
    {
        isValid = false;
        alert("Price should be positive");
    } else if(document.getElementById("price").value > 10000000)
    {
        isValid = false;
        alert("Costly!!Enter a lower price.");
    }
    else if(document.getElementById("available").value == "")
    {
        isValid = false;
        alert("Available units should be entered.");
    } else if(document.getElementById("available").value < 0)
    {
        isValid = false;
        alert("Available units should be positive");
    } else if(document.getElementById("available").value > 1000)
    {
        isValid = false;
        alert("Enter lesser available units.");
    }
    else{

    if(isNaN(document.getElementById("itemName").value))
    {
        isValid = true;
    }else{
        isValid=false;
        alert("Item name should not be a number.")
    }
    if(isNaN(document.getElementById("category").value))
    {
        isValid = true;
    }else{
        isValid=false;
        alert("Category should not be a number.")
    }
    }
    return isValid;
}


function select_all(source) 
{
    var checkboxes = document.querySelectorAll('input[type="checkbox"]');
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i] != source)
            checkboxes[i].checked = source.checked;
    }
}

function delete_selected()
{
var table = document.getElementById("itemList");
var rowCount = table.rows.length;
if (confirm('Are you Sure?'))
{
    for (var i = 1; i < rowCount; i++)
    {
    var row = table.rows[i];
    var chkbox = row.cells[0].childNodes[0];
    if (chkbox != null && chkbox.checked == true )
    {
    table.deleteRow(i);
    rowCount--;
    i--;
    }
    }
}
}

function search_record()
{
    records_per_page= Math.ceil(Object.keys(objectCopy).length);
    deleteall();
    changePage(records_per_page);
    var input, filter, table, tr, td, i, txtValue,tz,txtValue1;
    input = document.getElementById("search");
    filter = input.value.toUpperCase();
    table = document.getElementById("itemList");
    tr = table.getElementsByTagName("tr");
  
    for (i = 0; i < tr.length; i++)
    {
    td = tr[i].getElementsByTagName("td")[1];
    tz = tr[i].getElementsByTagName("td")[2];
    if (td ) 
    {
        txtValue = td.textContent || td.innerText;
        txtValue1 = tz.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1 || txtValue1.toUpperCase().indexOf(filter) > -1)
        {
          tr[i].style.display = "";
        } else 
        {
          tr[i].style.display = "none";
        }
      } 
    }
}

function onRead(td)
{
    openModal();
    selectedRow = td.parentElement.parentElement;
    document.getElementById("thisitem").innerHTML = selectedRow.cells[1].innerHTML;
    document.getElementById("thiscategory").innerHTML = selectedRow.cells[2].innerHTML;
    document.getElementById("thisprice").innerHTML = selectedRow.cells[3].innerHTML;
    document.getElementById("thisavailable").innerHTML = selectedRow.cells[4].innerHTML;
    
}

var modal = document.getElementById("simpleModal");

function openModal()
{
    modal.style.display = 'block';
}  

function closeModal()
{
    modal.style.display = 'none';
}  
window.onclick = function(event) {
    if (event.target == modal) {
      modal.style.display = "none";
    }
  }