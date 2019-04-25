function waiverHandler(c, idSec) {
    var w = document.getElementById(idSec);

    if (c.checked) {
        w.style.display = "block";
    } else {
        w.style.display = "none";
    }

}

function test(c) {
    alert(c.checked);
}

function deleteFormHandler() {
    $("#soldDelete").addClass("hidden");
    $("#purposeDelete").addClass("hidden");
    $("#constructDelete").addClass("hidden");
    $("#" + $("#deleteReason").val()).removeClass("hidden");
}

function waiveFormHandler() {
    $("#usedWaive").addClass("hidden");
    $("#sellWaive").addClass("hidden");
    $("#leaseWaive").addClass("hidden");
    $("#utilizeWaive").addClass("hidden");
    $("#" + $("#waiveReason").val()).removeClass("hidden");
}

function reduceFormHandler() {
    $("#debtReduce").addClass("hidden");
    $("#modReduce").addClass("hidden");
    $("#" + $("#reduceReason").val()).removeClass("hidden");
}