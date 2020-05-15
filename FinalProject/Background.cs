using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics.PerformanceData;

namespace FinalProject
{
    class Background
    {
        int swidth, sheigh;             // Screen size

        ArrayList layers;
        Rectangle pos;

        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Background(Rectangle pos)
        {
            this.pos = pos;

            layers = new ArrayList();
            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            sheigh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public void LoadContent(ContentManager Content)
        {
            Texture2D texture;
            for (int i = 10; i >= 0; i--)
            {
                texture = Content.Load<Texture2D>("Background/Layer_"+i.ToString("00"));
                layers.Add(texture);
            }
        }

        public void Update(GameTime gameTime)
        {
            pos.X -= BasicSprite.mapSpeed;         //Move the rectangle

            if (pos.X < -swidth) pos.X = swidth;    //If one of the rectangles exit from the screen move this one to the end
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < 10; i++)        //Print all the layers
            {
                spriteBatch.Draw((Texture2D)layers[i], pos, Color.White);
            }

            spriteBatch.End();
        }
    }
}
