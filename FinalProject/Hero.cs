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
    class Hero
    {
        BasicAnimatedSprite sprite1;
        public Hero()
        {
            sprite1 = new BasicAnimatedSprite(new Rectangle(100, 100, 100, 100), 900, 900);
        }
        public void LoadContent(ContentManager Content)
        {
            sprite1.LoadContent(Content, "Run_animation", "0_Reaper_Man_Running_", 12);
        }

        public void Update(GameTime gameTime)
        {
            sprite1.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite1.Draw(spriteBatch);
        }

    }
}
