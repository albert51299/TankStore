
var btnBack = document.getElementById("btnBack");
btnBack.addEventListener("click", BackHandler);

var btnAdd = document.getElementById("btnAddGold");
btnAdd.addEventListener("click", AddHandler);

var btnShow = document.getElementById("btnShowClientBuys");
btnShow.addEventListener("click", ShowHandler);

function AddHandler(event) {
    var input = prompt("Top up", "");
    if (input == null) {
        return;
    }
    if (isNumeric(input)) {
        var gold = parseInt(input);
        if (gold < 0) {
            alert("Please enter a positive number");
        } else {
            window.location.href = "/Client/AddGold?gold=" + gold;
        }
    } else {
        alert("Input string is not a number");
    }
}

function ShowHandler(event) {
    var str = getCookie("buysEmpty");
    if (str == "true") {
        alert("Buys is empty");
    } else {
        window.location.href = "/Client/ShowClientBuys/";
    }
}

function BackHandler(event) {
    window.location.href = "/Home/Index/";
}

// return cookie with specified name or undefined
function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}
