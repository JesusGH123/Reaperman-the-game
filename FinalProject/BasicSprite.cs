using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    class BasicSprite
    {
        Texture2D texture;
        Rectangle pos;

        public BasicSprite(Rectangle pos)
        {
            this.pos = pos;
        }

        public void LoadContent(ContentManager Content, String Filename)
        {
            texture = Content.Load<Texture2D>(Filename);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.End();
        }
    }
}
