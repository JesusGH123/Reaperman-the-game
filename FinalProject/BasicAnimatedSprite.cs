using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    public class BasicAnimatedSprite
    {
        Rectangle pos;
        Texture2D texture;
        ArrayList sprites;

        float timer, timePerFrame = 40f;
        int frameCount, currentFrame, frameW, frameH;
        
        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public BasicAnimatedSprite(Rectangle pos, int frameW, int frameH)
        {
            this.pos = pos;
            this.frameW = frameW;
            this.frameH = frameH;

            sprites = new ArrayList();
        }

        public void LoadContent(ContentManager Content, String dir, String filename, int frameCount)
        {
            this.frameCount = frameCount;

            for(int i = 0; i < frameCount; i++)
            {
                texture = Content.Load<Texture2D>(dir + "/" + filename + i.ToString("000"));
                sprites.Add(texture);
            }

        }

        public void Update(GameTime gameTime)
        {
            timer = timer + (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw((Texture2D) sprites[currentFrame], pos, Color.White);
            spriteBatch.End();
        }
    }
}