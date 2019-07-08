
var btnBack = document.getElementById("btnBack");
btnBack.addEventListener("click", BackHandler);

var forms = document.getElementsByTagName("form");
forms[0].addEventListener("submit", CreateAccHandler);

if (getCookie("LoginUsed") == "true") {
    alert("Login already used");
}

function CreateAccHandler(event) {
    var fieldLogin = document.getElementById("login");
    var fieldPassword = document.getElementById("password");
    if ((fieldLogin.value == "") || (fieldPassword.value == "")) {
        alert("Not all fields are filled");
        event.preventDefault();
    }
}

function BackHandler(event) {
    window.location.href = "/Home/Index/"
}

function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
        "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
}
