using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    class BasicSprite
    {
        protected Texture2D texture;
        protected Rectangle pos;
        public static int mapSpeed = 3;     //The value in which the objects will move

        public Rectangle Pos        //Return the position value
        {
            get { return pos; }
            set { pos = value; }
        }
        public BasicSprite(Rectangle pos)   //Receive the pos rectangle
        {
            this.pos = pos;
        }

        public void LoadContent(ContentManager Content, String Filename)    //Load one single image
        {
            texture = Content.Load<Texture2D>(Filename);
        }

        public virtual void Update(GameTime gameTime)
        {
            pos.X -= mapSpeed;     //Move the sprite along the map
        }

        public void Draw(SpriteBatch spriteBatch)   //Draw the sprite
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.End();
        }

        public bool Collision(Rectangle check)      //Collision for a basicSprite object
        {
            return pos.Intersects(check);
        }
    }
}
