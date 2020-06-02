using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalProject
{
    abstract class AbstractSprite : IMonogame
    {
        // Attributes
        protected Texture2D image;
        protected ArrayList textureList;
        protected Rectangle pos;
        protected Rectangle source;
        protected Color color;
        protected string filename;

        protected static SpriteBatch spriteBatch;
        protected static ContentManager Content;

        // Properties 
        public Rectangle Pos
        {
            set { pos = value; }
            get { return pos; }
        }


        public static void SetSpriteBatch(SpriteBatch spriteBatchIn)
        {
            spriteBatch = spriteBatchIn;
        }

        public static void SetContentManager(ContentManager ContentIn)
        {
            Content = ContentIn;
        }

        // Methods
        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

       
    }
}
