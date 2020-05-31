﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    class Obstacle :TwoStates
    {
        bool collision;
        public Obstacle(int x, int y, int height, int width)
        {
            this.LoadNormalSprite(x, y, width, height, "dinamita_", Color.White);
            this.LoadAnimatedSprite(State.EXPLODE, x, y, width, height, "fire_", Color.White, 16, 1, 0.0f, 64, 64);
            collision = false;
        }

        public bool Collision(Rectangle RectIn)
        {
            if (this.Pos.Intersects(RectIn))
                collision = true;

            return collision;
        }

        public override void LoadContent()
        {
            base.LoadContent(); //con esto estamos cargando el metodo heredado de la clase Wrapper
        }

        public void ResetCollision()
        {
            collision = false;
        }


        public override void Update(GameTime gameTime) //Este metodo le hacemos override para poder editar el metodo que hemos 
        {
            Rectangle tempPos = Pos;                                          // heredado de la clase Wrapper el cual lo tiene como virtual para que aqui lo editemos
            tempPos.X -= mapSpeed;
            if (collision)                              //Despues usamos base.Update para usar el codigo que tenemos en la clase Wrapper
            {
                state = State.EXPLODE;
            }
            else
            {
                state = State.NORMAL;
            }
            Pos = tempPos;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}