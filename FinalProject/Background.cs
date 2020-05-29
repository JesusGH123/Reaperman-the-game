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
    class Background : BasicSprite
    {
        int swidth, sheigh;             // Screen size

        //ArrayList layers; There is an ArrayList called textureList which is inherited from AbstractSprite
        //Rectangle pos;  //It is inherited from BS

        //public Rectangle Pos //It is inherited from AbstractSprite
        //{
        //    get { return pos; }
        //    set { pos = value; }
        //}
        public Background(int x, int y, int width, int height, string filename, Color color)
            :base(x,y,width, height, filename, color)
        {

            pos = new Rectangle(x, y, width, height);

            textureList = new ArrayList();
            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;  //It is already done in Game1
            sheigh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public override void LoadContent()
        {
            
            for (int i = 10; i >= 0; i--)
            {
                //texture = Content.Load<Texture2D>("Background/Layer_" + i.ToString("00"));
                
                image = Content.Load<Texture2D>(filename + i.ToString("00"));
                textureList.Add(image);
                source = new Rectangle(0, 0, image.Width, image.Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
            pos.X -= mapSpeed;         //Move the rectangle

            if (pos.X < -swidth) pos.X = swidth;    //If one of the rectangles exit from the screen move this one to the end
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < 10; i++)        //Print all the layers
            {
                spriteBatch.Draw((Texture2D)textureList[i], pos, color);
            }

            spriteBatch.End();
        }
    }
}
