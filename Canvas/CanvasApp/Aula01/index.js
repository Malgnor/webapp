/// <reference path="../Scripts/jquery-2.1.0-vsdoc.js" />
// context.drawImage(img,sx,sy,swidth,sheight,x,y,width,height);
var game = {}

$().ready(function () {
    var canvas = $("#testcanvas")[0];
    var context = canvas.getContext('2d');
    game.context = context;
    game.canvas = canvas;
    game.dragon = new Sprite(50, 50, "Images/uwqfC.gif", 75, 70);
    game.dragon2 = new Sprite(150, 50, "Images/uwqfC.gif", 75, 70);
    setInterval(function () {
        game.dragon2.x++;
        if (Keys.isDown(Keys.A)) {
            game.dragon.x--;
        }
        if (Keys.isDown(Keys.D)) {
            game.dragon.x++;
        }
        if (Keys.isDown(Keys.W)) {
            game.dragon.y--;
        }
        if (Keys.isDown(Keys.S)) {
            game.dragon.y++;
        }
    }, 16);
    window.requestAnimationFrame(desenhar);
    var musica = new Audio();

    if (musica.canPlayType("audio/mp3") != "") {
        musica.oncanplaythrough = function () {
            musica.play();
        }
    }

    musica.src = "Music/Terra's Theme.mp3";

    document.addEventListener("keydown", function (event) { event.preventDefault(); Keys.onKeydown(event); }, false);
    document.addEventListener("keyup", function (event) { event.preventDefault(); Keys.onKeyup(event); }, false);

});

function desenhar() {
    game.context.clearRect(0, 0, game.canvas.width, game.canvas.height);
    game.dragon.Draw();
    game.dragon2.Draw();
    window.requestAnimationFrame(desenhar);
}

var Keys = {
    _pressed: {},

    BACKSPACE: 8, TAB: 9, ENTER: 13, SHIFT: 16, CTRL: 17, ALT: 18,
    PAUSE: 19, BREAK: 19, CAPS: 20, ESC: 27, SPACE: 32, PAGE_UP: 33,
    PAGE_DOWN: 34, LEFT: 37, UP: 38, RIGHT: 39, DOWN: 40, INS: 45, DEL: 46,
    K0: 48, K1: 49, K2: 50, K3: 51, K4: 52,
    K5: 53, K6: 54, K7: 55, K8: 56, K9: 57,
    A: 65, B: 66, C: 67, D: 68, E: 69, F: 70, G: 71, H: 72, I: 73,
    J: 74, K: 75, L: 76, M: 77, N: 78, O: 79, P: 80, Q: 81, R: 82,
    S: 83, T: 84, U: 85, V: 86, W: 87, X: 88, Y: 89, Z: 90,
    N0: 96, N1: 97, N2: 98, N3: 99, N4: 100,
    N5: 101, N6: 102, N7: 103, N8: 104, N9: 105,
    TIMES: 106, PLUS: 107, MINUS: 106, DECIMAL: 110, DIVIDE: 111,
    F1: 112, F2: 113, F3: 114, F4: 115, F5: 116, F7: 117,
    F8: 118, F9: 119, F10: 120, F11: 121, F12: 122,
    NUM_LOCK: 144, SCRL_LOCK: 115,

    isDown: function (keyCode) {
        return this._pressed[keyCode];
    },

    isDownOnce: function (keyCode) {
        var b = this._pressed[keyCode]
        delete this._pressed[keyCode];
        return b;
    },
    onKeydown: function (event) {
        this._pressed[event.keyCode] = true;
    },
    onKeyup: function (event) {
        event.preventDefault();
        delete this._pressed[event.keyCode];
    }
};

function Sprite(x, y, sourceImage, width, height) {
    var self = this;
    this.x = x;
    this.y = y;
    this.imageLoaded = false;
    this.image = new Image();
    this.image.onload = function () {
        self.width = width || self.image.width;
        self.height = height || self.image.height;
        self.imageLoaded = true;
    }
    this.image.src = sourceImage;
}

Sprite.prototype.Draw = function () {
    if(this.imageLoaded)
        game.context.drawImage(this.image, 0, 0, this.width, this.height, this.x, this.y, this.width, this.height);
}