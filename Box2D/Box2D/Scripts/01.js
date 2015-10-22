/// <reference path="Box2D.js" />

window.onload = function () {
    var b2Vec2 = Box2D.Common.Math.b2Vec2,
    b2BodyDef = Box2D.Dynamics.b2BodyDef,
    b2Body = Box2D.Dynamics.b2Body,
    b2FixtureDef = Box2D.Dynamics.b2FixtureDef,
    b2World = Box2D.Dynamics.b2World,
    b2PolygonShape = Box2D.Collision.Shapes.b2PolygonShape,
    b2CircleShape = Box2D.Collision.Shapes.b2CircleShape,
    b2DebugDraw = Box2D.Dynamics.b2DebugDraw,
    b2RevoluteJointDef = Box2D.Dynamics.Joints.b2RevoluteJointDef,

    context = document.getElementById('gameCanvas').getContext('2d');

    var escala = 30,
    gravidade = new b2Vec2(0.0, 9.8),
    mundo = new b2World(gravidade, true);

    criarPiso();
    setupDebugDraw();
    animar();



    function criarPiso() {
        var corpoDef = new b2BodyDef;
        corpoDef.type = b2Body.b2_staticBody;

        corpoDef.position.x = 640 / 2 / escala;
        corpoDef.position.y = 450 / escala;

        var fixtureDef = new b2FixtureDef;
        fixtureDef.density = 1.0;
        fixtureDef.friction = 0.5;
        fixtureDef.restitution = 0.2;

        fixtureDef.shape = new b2PolygonShape;
        fixtureDef.shape.SetAsBox(320 / escala, 10 / escala);

        var corpo = mundo.CreateBody(corpoDef);
        var fixture = corpo.CreateFixture(fixtureDef);
        
    };

    function setupDebugDraw() {
        var debugDraw = new b2DebugDraw();
        debugDraw.SetSprite(context);
        debugDraw.SetDrawScale(escala);
        debugDraw.SetFillAlpha(0.3);
        debugDraw.SetLineThickness(1.0);

        debugDraw.SetFlags(b2DebugDraw.e_shapeBit | b2DebugDraw.e_jointBit);

        mundo.SetDebugDraw(debugDraw);
    };

    var fps = 1 / 60,
        velocidadeIteração = 8,
        posiçãoIterações = 3;

    function animar() {

        mundo.Step(fps, velocidadeIteração, posiçãoIterações);
        mundo.ClearForces();
        mundo.DrawDebugData();

        setTimeout(animar, fps);
    };
};
