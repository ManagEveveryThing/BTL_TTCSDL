$(document).ready(function () {
    

    $(".input").click(function () {
        alert("test!");
    });

    $("#select-fied").change(function () {
        var x = document.getElementById("select-fied");
        var y;
        var num = 0;
        while (num < x.length) {
            if(num <10)
                y = document.getElementById("ce_0" + num);
            else
                y = document.getElementById("ce_" + num);
            $(y).css("visibility","hidden");
            num++;
        }
        var i = x.selectedIndex;
        var z;
        if (i < 10)
            z = document.getElementById("ce_0" + i);
        else
            z = document.getElementById("ce_" + i);
        $(z).css("visibility","initial");
    });
});
