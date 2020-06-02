using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Box : BasicSprite
    {
        public Box(int x, int y, int width, int heigh) : base(x, y, width, heigh, "theBox_", Color.White)
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle tempPos = Pos;              
            tempPos.X -= mapSpeed;

            Pos = tempPos;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
