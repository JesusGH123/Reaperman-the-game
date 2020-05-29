using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;

namespace FinalProject
{
    class BasicAnimatedSprite : BasicSprite
    {
        // Attributes
        //protected float timePerFrame;
        //protected int currentFrame;
        //protected int frameCount;
        //protected int frameWidth;
        //protected int frameHeight;
        ////....
        ////..
        //bool multipleFiles;

        // ATTRIBUTES
        protected int frameCount;
        protected int currentFrame;
        //protected ArrayList textureList; //Inherited from AbstractCharacter
        protected float timePerFrame;
        protected float timer;
        protected int countX, countY;
        protected int frameWidth, frameHeight;
        protected string dirname;
        // string filename; // inherited from BasicSprite

        // for error checking
        protected bool singleFiles;
        protected bool loadedSingle = false;
        protected bool loadedMultiple = false;

        // Methods
        // FOR SINGLE FILE
        public BasicAnimatedSprite(int x, int y, int width, int height, string filename, Color color, int framesX, int framesY, float timeFrame, int frameWidth, int frameHeight)
            : base(x, y, width, height, filename, color)
        {
            //this.filename = filename;  // Set in the constructor (see BasicSprite)
            this.countX = framesX;  // How many frames along X (horizontal)
            this.countY = framesY;  // How many frames along Y (vertical) - e.g. 1D spritesheet framesY = 1;
            this.frameCount = framesX * framesY;
            this.timePerFrame = timeFrame;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            singleFiles = true;
            loadedSingle = true;
        }

        // FOR MULTIPLE FILE
        public BasicAnimatedSprite(int x, int y, int width, int height, string filename, Color color, string dirname, int frames, float timeFrame)
            : base(x, y, width, height, filename, color)
        {
            // this.filename = filename; // Set in the constructor (see BasicSprite)
            this.dirname = dirname;
            this.frameCount = frames;
            this.timePerFrame = timeFrame;

            singleFiles = false;
            loadedMultiple = true;

            textureList = new ArrayList();
        }

        public override void LoadContent()
        {
            // Common initialization
            currentFrame = 0;
            timer = 0;

            // Loading SINGLE files
            if (singleFiles)
            {
                if (loadedSingle)
                {
                    base.LoadContent();
                }
            }
            // Loading MULTIPLE files
            else
            {
                if (loadedMultiple)
                {
                    // NOTE: Loads images starting from 1 (ONE), not 0 (ZERO)
                    for (int k = 0; k < frameCount; k++)
                    {
                        Texture2D tex;
                        tex = Content.Load<Texture2D>(dirname + "/" + filename + k.ToString("000"));
                        textureList.Add(tex);

                        // NOTE: Assume that all textures (when using multiple textures) are the same size (size of image)
                        frameWidth = tex.Width;
                        frameHeight = tex.Height;
                    }
                }
            }

            // NOTE: Using inherited member "source"
            // SOURCE rectangle - see comment in BasicSprite
            source = new Rectangle(0, 0, frameWidth, frameHeight);  // Initial value
        }

        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer >= timePerFrame)
            {
                // increment currentFrame
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            if (singleFiles)
            {
                int xTex, yTex;
                int currX, currY;

                currX = currentFrame % countX;		// The residual of the division currentFrame / countX
                currY = currentFrame / countX;	    // The quotient of the division currentFrame / countX
                xTex = currX * frameWidth;
                yTex = currY * frameHeight;

                // NOTE: Using inherited member "source"
                source.X = xTex;
                source.Y = yTex;
                source.Width = frameWidth;
                source.Height = frameHeight;

                // We assume inherited member "pos" is updated before Draw() is called
                base.Draw(gameTime);
            }
            else
            {
                // We assume inherited member "pos" is updated before Draw() is called
                // Inherited member "source" does not have to be changed

                // NOTE: Using inherited member "image"
                image = (Texture2D)textureList[currentFrame];
                base.Draw(gameTime);
            }
        }
        public bool Collision(Rectangle objective)
        {
            return pos.Intersects(objective);
        }
    }
}
