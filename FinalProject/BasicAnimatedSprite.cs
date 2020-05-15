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
        protected Rectangle pos;
        protected Texture2D texture;
        ArrayList sprites;

        float timer, timePerFrame;
        int frameCount, currentFrame, frameW, frameH, xtex, ytex, countX, countY;
        bool spriteSheet;
        
        public Rectangle Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public BasicAnimatedSprite(Rectangle pos)   //Receive the position and the size of the different frames
        {
            this.pos = pos;

            sprites = new ArrayList();
        }


        //Multiple sprites
        public void LoadContent(ContentManager Content, String filename, int frameCount, float timeperframe)    //Load the sprites (Soported Multiple files only)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timeperframe;
            spriteSheet = false;

            for(int i = 0; i < frameCount; i++)
            {
                texture = Content.Load<Texture2D>(filename + i.ToString("000"));
                sprites.Add(texture);
            }

        }

        //Spritesheet
        public void LoadContent(ContentManager Content, String name, int frameCount, float timeperframe, int countX, int countY, int frameWidth, int frameHeight)
        {
            this.timePerFrame = timeperframe;
            this.frameCount = frameCount;
            this.frameH = frameHeight;
            this.frameW = frameWidth;
            this.countX = countX;
            this.countY = countY;
            spriteSheet = true;

            texture = Content.Load<Texture2D>(name);
        }

        public virtual void Update(GameTime gameTime)       //Logic for the frame loading
        {
            timer = timer + (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if(timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        public void Draw(SpriteBatch spriteBatch)       //Draw the sprites list
        {
            Rectangle sourceRect;
            int currentX, currentY;

            spriteBatch.Begin();
            if (spriteSheet == false)
            {
                spriteBatch.Draw((Texture2D)sprites[currentFrame], pos, Color.White);
            }
            else
            {
                currentX = currentFrame % countX;
                currentY = (int)currentFrame / countY;
                xtex = currentFrame * frameW;
                if (countY > 1)
                    ytex = currentFrame * frameH;
                else
                    ytex = 0;
                sourceRect = new Rectangle(xtex, ytex, frameW, frameH);
                spriteBatch.Draw(texture, pos, sourceRect, Color.White);
            }
            spriteBatch.End();
        }

        public bool Collision(Rectangle objective)
        {
            return pos.Intersects(objective);
        }
    }
}