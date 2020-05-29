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

        public Coin(int x, int y, int width, int height, string filename, Color color, int framesX, int framesY, float timeFrame, int frameWidth, int frameHeight) 
        : base(x,y,width, height,filename, color, framesX, framesY, timeFrame,frameWidth, frameHeight)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            pos.X -= mapSpeed;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
