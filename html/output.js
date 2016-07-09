


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
    $("ul.solarsystem li.earth span").css('left', w/2 - 5);
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
        var color1 = 'rgb(245,245,245)'; //Bottom, yellow
        var color2 = '#fff'; //Top.        
        switch (strColor){
            case "Red":                
                color2 = 'rgb(204,2,0)';
            break;
            case "Orange":
                color2 = 'rgb(248,155,0)';
            break;
            case "Yellow":
                color2 = 'rgb(245,201,22)';
            break;
            case "Yellow White":
                color2 = 'rgb(250,245,200)';
            break;
            case "White":
                color2 = 'rgb(255,255,255)';
            break;
            case "Blue White":
                color2 = 'rgb(218,235,245)';
            break;
            case "Blue":
                color2 = 'rgb(0,115,190)';
            break;
            default:
        }
      
        
        $("ul.solarsystem li.sun").css({
            background: "-webkit-gradient(linear, left bottom, left top, color-stop(0.35, "+color2+"), color-stop(1.00, "+color1+"))" 
        });


        $("ul.solarsystem li.sun").css('box-shadow', '0 0 ' + (25+(sunsz/5)) + 'px ' + color2);
    }

    //Create the planets
    var zindex = 0;
    for (var i =0;i<solarsystem.Planets.length;i++){
        //Create their orbit:
        var $div = $("<li>", {id: solarsystem.Planets[i].Name+"Orbit", class: "orbit"});
        $div.click(function(){ /* ... */ });
       
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
        var t = solarsystem.Planets[i].OrbitingTime;
        $div.css({'-webkit-animation-duration' : t+'s'});

        $(".solarsystem").append($div);

        //Make the planets:
        $planet = $("<li>", {class: "planet"});
        $div.append($planet);
        $div.css('z-index',zindex++);

        //Set their size:
        var psz = 2 + solarsystem.Planets[i].Mass / 50;
        var pl = (w/2) - (psz/2);
        var pt = -2 - (psz / 2);
        $planet.css('width',psz);
        $planet.css('height',psz);
        $planet.css('left',pl);
        $planet.css('top',pt);
        $planet.css('border-radius',(psz / 2 )+ 2);
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
