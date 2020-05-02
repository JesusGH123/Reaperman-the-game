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

namespace FinalProject
{
    class Background
    {
        ArrayList layers;
        Rectangle pos1, pos2;

        int mapSpeed = 3;
        public Background()
        {
            layers = new ArrayList();

            pos1 = new Rectangle(0, -100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 80);
            pos2 = new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, -100, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height + 80);
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
            pos1.X -= mapSpeed;
            pos2.X -= mapSpeed;
            if (pos1.X < -GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width) pos1.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            if (pos2.X < -GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width) pos2.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < layers.Count; i++)
            {
                spriteBatch.Draw((Texture2D)layers[i], pos1, Color.White);
                spriteBatch.Draw((Texture2D)layers[i], pos2, Color.White);
            }
            spriteBatch.End();
        }
    }
}
