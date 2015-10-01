/// <reference path="../Scripts/jquery-2.1.0-vsdoc.js" />

$().ready(function () {
    var canvas = $("#testcanvas")[0];
    var context = canvas.getContext('2d');

    //context.fillStyle = "#F00";
    //context.fillRect(200, 10, 100, 100);

    //context.strokeStyle = "#00F";
    //context.strokeRect(110, 10, 50, 50);
    //context.clearRect(210, 20, 30, 20);

    //context.beginPath();
    //context.arc(100, 300, 40, Math.PI, false);
    //context.closePath();
    //context.fill();

    //context.beginPath();
    //context.moveTo(170, 160);
    //context.lineTo(170, 220);
    //context.lineTo(300, 220);
    //context.closePath();
    //context.stroke();

    //context.save();
    //context.translate(300, 80);
    //context.scale(-1, 1);
    //context.fillStyle = "#000";
    //context.font = "20 pt Arial";
    //context.fillText("Hello world!", 0, 0);
    //context.restore();

    //context.fillStyle = "rgba(0, 255, 0, 0.3)";
    //context.fillRect(240, 40, 100, 100);

    //var image = $("#dragon")[0];
    var image = new Image();
    image.src = "Images/uwqfC.gif";
    image.onload = function () {

        var xx = image.width / 10;
        var yy = image.height / 8;
        context.drawImage(image, 0, 0);
        context.drawImage(image, 0, 50, 100, 25);
        context.drawImage(image, xx * 2, yy * 7, xx, yy, 0, 70, xx, yy);
        var x = 0;
        setInterval(function () {
            context.clearRect(0, 0, canvas.width, canvas.height);
            for (var i = 0; i < 8; i++) {
                context.drawImage(image, xx * x, yy * i, xx, yy, xx * i, 0, xx, yy);
            }
            x = (x + 1) % 10;
        }, 16);

    };

    var musica = new Audio();

    if (musica.canPlayType("audio/mp3") != "") {
        musica.oncanplaythrough = function () {
            alert("Musica foi carregada");
            musica.play();
        }
    }

    musica.src = "Music/Terra's Theme.mp3";
});