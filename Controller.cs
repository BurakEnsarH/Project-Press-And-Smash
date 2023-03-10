﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Miner
{
    class Controller
    {
        public static double timer = 2D;
        public static double maxTime = 2D;
        static Random rand = new Random();
        public static bool inGame = false;
        public static double totalTime = 0;

        public static void Update(GameTime gameTime, Texture2D spriteSheet)
        {

            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
                totalTime += gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState kState = Keyboard.GetState();
                if (kState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                    totalTime = 0;
                }
            }

            if (timer <= 0)
            {
                int side = rand.Next(4);

                switch (side)
                {
                    case 0:
                        Enemy.enemies.Add(new Enemy(new Vector2(-500, rand.Next(-500, 2000)), spriteSheet));
                        break;
                    case 1:
                        Enemy.enemies.Add(new Enemy(new Vector2(2000, rand.Next(-500, 2000)), spriteSheet));
                        break;
                    case 2:
                        Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), -500), spriteSheet));
                        break;
                    case 3:
                        Enemy.enemies.Add(new Enemy(new Vector2(rand.Next(-500, 2000), 2000), spriteSheet));
                        break;
                }

                timer = maxTime;

                if(maxTime > 0.5)
                {
                    maxTime -= 0.05D;
                }
            }
        }
    }
}
