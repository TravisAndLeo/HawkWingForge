window.onload = function () {
    console.log("onload");
    var xmlhttp = new XMLHttpRequest();
    var url = "/ProductTypes/LoadProductTypes";

    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var myArr = JSON.parse(this.responseText);
            SetProductTypes(myArr);
        }
    }
    xmlhttp.open("GET", url);
    xmlhttp.send();
};

function SetProductTypes(array) {
    var htmlOutput = "";
    var i;
    for (i = 0; i < array.length; i++) {
        htmlOutput += '<li><a href="' + array[i].id + '">' + array[i].type + '</a></li>';
    }
    document.getElementById("ulProductTypesDropdown").innerHTML = htmlOutput;
}