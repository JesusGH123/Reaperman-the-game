using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalProject
{
    class Enemy:TwoStates
    {
        bool collision;
        public Enemy(int x, int y, int height, int width)
        {
            this.LoadAnimatedSprite(State.NORMAL, x, y, width, height, "chase_", Color.White, "Enemy_Chase", 4, .05f);
            this.LoadAnimatedSprite(State.EXPLODE, x, y, width, height, "death_", Color.White, "Enemy_Death", 3, .05f);
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
            base.LoadContent(); //con esto estamos cargando el metodo heredado de la clase TwoStates
        }

        public void ResetCollision()
        {
            collision = false;
        }


        public override void Update(GameTime gameTime) //Este metodo le hacemos override para poder editar el metodo que hemos 
        {
            Rectangle tempPos = Pos;                                          // heredado de la clase TwoStates el cual lo tiene como virtual para que aqui lo editemos
            tempPos.X -= mapSpeed*2;
            if (collision)                              //Despues usamos base.Update para usar el codigo que tenemos en la clase TwoStates
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
