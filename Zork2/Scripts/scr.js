$(document).ready(function () {
    four();
    $('#sendBtn').click(function () {
        $('.textHolder').animate({ scrollTop: $('.textHolder').prop("scrollHeight") }, 1000);
        
        document.getElementById("inputField").focus();
    })
})
    var elements = document.getElementsByClassName("column");
    var i;

function four() {

    for (i = 0; i < elements.length; i++) {
        elements[i].style.flex = "25%";
    }
}