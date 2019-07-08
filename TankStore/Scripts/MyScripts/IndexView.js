
var div1 = document.getElementById("addBtn1");
var div2 = document.getElementById("addBtn2");
// common button for all cases
var divBtn1 = document.createElement("input");
divBtn1.type = "button";
divBtn1.className = "buttonLarge";
div1.appendChild(divBtn1);
// add buttons in depend on cookies
if ((getCookie("isAdmin") == "true") || (getCookie("isClient") == "true")) { // user is authenticated

    var btnLogout = document.createElement("input");
    btnLogout.value = "Logout";
    btnLogout.className = "buttonLarge";
    btnLogout.type = "button";
    div2.appendChild(btnLogout);
    btnLogout.addEventListener("click", LogoutHandler);

    if (getCookie("isAdmin") == "true") { // buttons to admin panel(add, delete, update), logout
        divBtn1.value = "Admin panel";
        divBtn1.addEventListener("click", AdminHandler);
    } else { // buttons to buy selected, sort, user account(top up, showallbuys), logout
        divBtn1.value = "My account";
        divBtn1.addEventListener("click", UserAccHandler);

        var divBuy = document.getElementById("buyBtn");
        var btnBuy = document.createElement("input");
        btnBuy.value = "Buy selected";
        btnBuy.className = "buttonLarge";
        btnBuy.type = "submit";
        divBuy.appendChild(btnBuy);

        var form = btnBuy.form;
        form.addEventListener("submit", BuySelectedHandler);

        var cash = document.getElementById("Cash");
        var divCash = document.getElementById("divCash");
        divCash.innerText = "Current cash - " + cash.value;

        var divSort = document.getElementById("btnSort");
        var btnSort = document.createElement("input");
        btnSort.value = "Sort order";
        btnSort.className = "buttonLarge";
        btnSort.type = "button";
        divSort.appendChild(btnSort);
        btnSort.addEventListener("click", SortHandler);
    }
} else { // no authentication - buttons to login and registration
    divBtn1.value = "Login";
    divBtn1.addEventListener("click", LoginHandler);

    var btnReg = document.createElement("input");
    btnReg.value = "Registration";
    btnReg.className = "buttonLarge";
    btnReg.type = "button";
    div2.appendChild(btnReg);

    btnReg.addEventListener("click", RegHandler);
}

function BuySelectedHandler(event) {
    var elements = document.getElementsByClassName("inputNumber");

    var allPosNumbers = true;
    for (var i = 0; i < elements.length; i++) {
        if (!isNumeric(elements[i].value) || (parseInt(elements[i].value) < 0)) {
            allPosNumbers = false;
        }
    }
    if (!allPosNumbers) {
        alert("Not all fields filled by positive numbers");
        event.preventDefault();
    }
    
    var allZero = true;
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].value != 0) {
            allZero = false;
        }
    }
    if (allZero) {
        // don't send post request
        alert("No one tank selected");
        event.preventDefault();
    }

    var notEnough = false;
    var avElements = document.getElementsByClassName("available");
    for (var i = 0; i < elements.length; i++) {
        var required = parseInt(elements[i].value);
        var available = parseInt(avElements[i].innerText);
        if (required > available) {
            notEnough = true;
            break;
        }
    }
    if (notEnough) {
        // don't send post request
        alert("Not enough tanks in store");
        event.preventDefault();
    }

    var strCash = document.getElementById("Cash").value;
    var Cash = parseInt(strCash);
    var costs = document.getElementsByClassName("cost");
    var sum = 0;
    for (var i = 0; i < costs.length; i++) {
        sum += costs[i].innerText * elements[i].value;
    }
    if (sum > Cash) {
        alert("Not enough gold");
        event.preventDefault();
    }
}

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

// return cookie with specified name or undefined
function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}

function SortHandler(event) {
    window.location.href = "/Client/Sort/";
}

function AdminHandler(event) {
    window.location.href = "/Admin/ControlPanel/";
}

function UserAccHandler(event) {
    window.location.href = "/Client/MyAccount/";
}

function LogoutHandler(event) {
    var result = confirm("Are you sure want to logout?");
    if (result) {
        window.location.href = "/ManageAccounts/Logout/";
    }
}

function RegHandler(event) {
    window.location.href = "/ManageAccounts/Reg/";
}

function LoginHandler(event) {
    window.location.href = "/ManageAccounts/Login/";
}
