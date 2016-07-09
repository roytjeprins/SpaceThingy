


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

    //Assume there is one star:
    var sunsz = 0;
    for (var i =0;i<1/*solarsystem.Stars.length*/;i++){
        sunsz = Math.round(solarsystem.Stars[i].Diameter / 10E6);
        console.log("Je zon is " + w);

        //Set the size:
        $("ul.solarsystem li.sun").css('width', sunsz);
        $("ul.solarsystem li.sun").css('height', sunsz);
        $("ul.solarsystem li.sun").css('left', 420 -  (sunsz/2));
        $("ul.solarsystem li.sun").css('top', 420 -  (sunsz/2));
        $("ul.solarsystem li.sun").css('border-radius',(sunsz / 2 )+ 2);

        //Color it...:
        var strColor = solarsystem.Stars[i].StarColor;
        if (strColor == ""){}

    }



    //Create the planets
    var zindex = 0;
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
        $div.css('z-index',zindex++);


        //Center them around sun.
        var l = 418 - (w/2);
        var t = 418 - (h/2);
        $div.css('left',l);
        $div.css('top',t);
        $div.css('-webkit-animation-duration:'+5+'s');


        //Make the planets:
        $planet = $("<li>", {class: "planet"});
        $div.append($planet);
        $div.css('z-index',zindex++);

        //Set their size:
        var pw = 10;
        var ph = 10;
        var pl = (w/2) - (pw/2);
        var pt = -2 - (ph / 2);
        $planet.css('width',pw);
        $planet.css('height',pw);
        $planet.css('left',pl);
        $planet.css('top',pt);
        $planet.css('border-radius',(pw / 2 )+ 2);
        $planet.css('z-index',zindex++);


        

        //Make the buttons:
        $div = $("<li>", {});
        $div.click(function(){ /* ... */ });
        $("#descriptions").append($div);
        var name = solarsystem.Planets[i].Name;
        $div.append("<h2 id='"+name+"'>"+name+"</h2>");
        console.log("Built you a button");

    }
});
