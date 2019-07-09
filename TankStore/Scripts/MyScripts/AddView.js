
var forms = document.getElementsByTagName("form");
forms[0].addEventListener("submit", SubmitHandler);

function SubmitHandler(event) {
    var name = document.getElementById("tankName");
    var country = document.getElementById("tankCountry");
    var cost = document.getElementById("tankCost");
    var count = document.getElementById("tankCount");
    if ((name.value == "") || (country.value == "") || (parseInt(cost.value) <= 0) || (parseInt(count.value) < 0)) {
        alert("Incorrect data");
        event.preventDefault();
    }
}

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

var btnCancel = document.getElementById("btnCancel");
btnCancel.addEventListener("click", CancelHandler);

function CancelHandler(event) {
    window.location.href = "/Admin/ControlPanel/";
}
