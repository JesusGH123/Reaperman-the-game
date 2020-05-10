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
        Rectangle pos1, pos2;

        public Background()
        {
            layers = new ArrayList();
            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            sheigh = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            pos1 = new Rectangle(0, -100, swidth, sheigh + 80);
            pos2 = new Rectangle(swidth, -100, swidth, sheigh + 80);
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

            pos1.X -= 3;
            pos2.X -= 3;

            if (pos1.X < -swidth) pos1.X = swidth;
            if (pos2.X < -swidth) pos2.X = swidth;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw((Texture2D)layers[i], pos1, Color.White);
                spriteBatch.Draw((Texture2D)layers[i], pos2, Color.White);
            }

            spriteBatch.End();
        }
    }
}
