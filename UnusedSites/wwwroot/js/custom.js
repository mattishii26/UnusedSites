function waiverHandler(c, idSec) {
    var w = document.getElementById(idSec);

    if (c.checked) {
        w.style.display = "block";
    } else {
        w.style.display = "none";
    }

}

function test(c) {
    alert(c.checked
        );
}