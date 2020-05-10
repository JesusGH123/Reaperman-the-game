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
    class Item
    {
        Rectangle pos;
        Texture2D texture;

        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Item(Rectangle pos)
        {
            this.pos = pos;
        }
        public void LoadContent(ContentManager Content, String filename)
        {
            texture = Content.Load<Texture2D>(filename);
        }
        public void Update(GameTime gameTime)
        {
            pos.X -= 3;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.End();
        }
        public bool Collision(Rectangle objective)
        {
            return pos.Intersects(objective);
        }
    }
}
