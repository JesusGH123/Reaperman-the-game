using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    enum actions { run, dye, damage};     
    class Hero
    {
        BasicAnimatedSprite sprite1;     // Reaper man   
        Point velocity;

        bool hasJumped = false;

        public Hero(Rectangle pos)
        {
            //this.pos = pos;

            sprite1 = new BasicAnimatedSprite(pos, 900, 900);        
        }
        public void LoadContent(ContentManager Content)
        {
            sprite1.LoadContent(Content, "Run_animation", "0_Reaper_Man_Running_", 12);
        }

        public void Update(GameTime gameTime)
        {
            sprite1.Update(gameTime);
            
            // Search for the jump
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite1.Draw(spriteBatch);
        }

    }
}
