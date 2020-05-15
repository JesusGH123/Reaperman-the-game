using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Coin : BasicAnimatedSprite
    {

        public Coin(Rectangle pos) : base(pos)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            pos.X -= 3;

            base.Update(gameTime);
        }

    }
}
