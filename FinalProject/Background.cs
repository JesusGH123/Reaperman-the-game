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

        Texture2D score;
        Texture2D lives;
        Rectangle poshud;
        Rectangle posscore;

        public Background(int x, int y, int width, int height, string filename, Color color)
            :base(x,y,width, height, filename, color)
        {

            pos = new Rectangle(x, y, width, height);              // position of the hud (Fer, 31/05/20)
            poshud = new Rectangle(10, 10, 40, 40);
            posscore= new Rectangle(1000, 10, 280, 150);

            textureList = new ArrayList();
            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;  //It is already done in Game1
            sheigh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public override void LoadContent()
        {
            
            for (int i = 10; i >= 0; i--)
            {   
                image = Content.Load<Texture2D>(filename + i.ToString("00"));
                textureList.Add(image);
                source = new Rectangle(0, 0, image.Width, image.Height);
            }
            
            score = Content.Load<Texture2D>("score");
            lives = Content.Load<Texture2D>("heart");           //The new lives
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
            spriteBatch.Draw(score, posscore, color);

            // i debe de ser el numero de vidas del hero pero ahorita no lo tenemos
                for (int i = 0; i < 5; i++)
                {
                    spriteBatch.Draw(lives, new Rectangle((i*40)+30, 30, 40, 40), Color.White);
                }
            
            spriteBatch.End();
        }
    }
}
