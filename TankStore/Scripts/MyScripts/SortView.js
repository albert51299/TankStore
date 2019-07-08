
var btnBack = document.getElementById("btnBack");
btnBack.addEventListener("click", BackHandler);

//var btnSave = document.getElementById("btnSave");
//btnSave.addEventListener("click", SaveHandler)

function BackHandler(event) {
    window.location.href = "/Home/Index/";
}

function SaveHandler(event) {
    var elSelect = document.getElementById("sortBy");
    var elRadio = document.getElementsByName("order");

    var sortBy = elSelect.value;
    var orderBy;
    for (var i = 0; i < elRadio.length; i++) {
        if (elRadio[i].checked) {
            orderBy = elRadio[i].value;
        }
    }

    /*if (sortBy == "cost") {
        set_cookie("byCost", "true");
        if (orderBy == "byIncrease") {
            set_cookie("byIncrease", "true");
        } else {
            set_cookie("byIncrease", "false");
        }
    } else {
        set_cookie("byCost", "false");
    }*/
    //alert("Changes saved!");
    //window.location.href = "/Home/Index/";
}

function set_cookie(name, value, exp_y, exp_m, exp_d, path, domain, secure) {
    var cookie_string = name + "=" + escape(value);

    if (exp_y) {
        var expires = new Date(exp_y, exp_m, exp_d);
        cookie_string += "; expires=" + expires.toGMTString();
    }

    if (path)
        cookie_string += "; path=" + escape(path);

    if (domain)
        cookie_string += "; domain=" + escape(domain);

    if (secure)
        cookie_string += "; secure";

    document.cookie = cookie_string;
}
