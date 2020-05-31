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
    class BasicSprite : AbstractSprite
    {
        public static int mapSpeed = 3;
        bool collision;

        public BasicSprite(int x, int y, int width, int height, string filename, Color color)
        {
            pos = new Rectangle(x, y, width, height);
            this.filename = filename;
            this.color = color;
            collision = false;
        }

        public bool Collision(Rectangle objective)
        {
            if(pos.Intersects(objective))
            collision = true;

            return collision;
        }

        public void ResetCollisions()
        {
            collision = false;

        }

        public override void LoadContent()
        {
            if (filename != null || Content != null)
            {
                 image = Content.Load<Texture2D>(filename + 1.ToString("00"));
                source = new Rectangle(0, 0, image.Width, image.Height);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            if (spriteBatch != null)
            {
                spriteBatch.Begin();
                   spriteBatch.Draw(image, pos, source, color);
                spriteBatch.End();
            }
        }
    }
}
