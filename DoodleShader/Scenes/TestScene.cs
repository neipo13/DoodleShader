﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace DoodleShader.Scenes
{
    public class TestScene : Scene
    {
        Effect doodleEffect;

        public override void initialize()
        {
            addRenderer(new DefaultRenderer());

            var emma = createEntity("emma");
            var emmaTexture = content.Load<Texture2D>("img/emma");
            var emmaSprite = new Sprite(emmaTexture);
            emma.addComponent(emmaSprite);
            emma.position = new Vector2(400, 400);

            doodleEffect = content.Load<Effect>("effects/DoodleShader");
            doodleEffect.Parameters["doodleMaxOffset"].SetValue(new Vector2(0.005f, 0.005f));
            doodleEffect.Parameters["doodleNoiseScale"].SetValue(new Vector2(6f, 8f));
            doodleEffect.Parameters["doodleFrameCount"].SetValue(6);
            doodleEffect.Parameters["doodleFrameTime"].SetValue(0.2f);
            emmaSprite.material = new Material(doodleEffect);


            var text = createEntity("txt");
            var textTexture = content.Load<Texture2D>("img/text");
            var textSprite = new Sprite(textTexture);
            text.addComponent(textSprite);
            text.position = new Vector2(400, 600);
            textSprite.material = new Material(doodleEffect);


        }

        public override void update()
        {
            base.update();

            doodleEffect.Parameters["time"].SetValue(Time.time);
        }
    }
}
