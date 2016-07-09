


//Load the system
console.log("You have "+solarsystem.Stars.length+ " Star(s)");
console.log("You have "+solarsystem.Planets.length+ " Planet(s)");

//Autocenter all the things:
$(function(){
    //Get the sun's center position:
    var x = parseInt($("ul.solarsystem li.sun").css('left'));
    var y = parseInt($("ul.solarsystem li.sun").css('top'));
    var ds = parseInt($("ul.solarsystem li.sun").css('width'));
    //Add half the diameter.
    x += (ds/2);
    y += (ds/2);




    var w =  parseInt($("ul.solarsystem li.earth").css('width'));
    var h =  parseInt($("ul.solarsystem li.earth").css('height'));
    $("ul.solarsystem li.earth").css('left', x - (w/2));
    $("ul.solarsystem li.earth").css('top', y - (h/2));
    $("ul.solarsystem li.earth span").css('left', w/2 - 5   );
    $("ul.solarsystem li.earth span").css('top', -5);



    $("ul.solarsystem li.mars").css('left', 80);
    console.log("Done aligning items");


    //Create the planets
    for (var i =0;i<solarsystem.Planets.length;i++){
        //Create their orbit:
        var $div = $("<li>", {id: solarsystem.Planets[i].Name+"Orbit", class: "orbit"});
        $div.click(function(){ /* ... */ });
        $(".solarsystem").append($div);
        console.log("Built you an orbit.");

        //Orbit size:
        var w = solarsystem.Planets[i].OrbitingRadius / 2;
        var h = w;

        //Set it:
        $div.css('width',w);
        $div.css('height',h);
        $div.css('border-radius',(w / 2 )+ 2);

        //Center them around sun.
        $div.css('left',418 - (w/2));
        $div.css('top',418 - (h/2));

        //Make the buttons:
        $div = $("<li>", {});
        $div.click(function(){ /* ... */ });
        $("#descriptions").append($div);
        var name = solarsystem.Planets[i].Name;
        $div.append("<h2 id='"+name+"'>"+name+"</h2>");
        console.log("Built you a button");

    }
});
