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
    enum Actions { RUN, DYE, DAMAGE, INITIAL_JUMP, JUMP_LOOP, FALLING };    //Character states

    abstract class AbstractCharacter : IMonogame
    {
        // ATTRIBUTES
        // -------------------------------------------
        //protected Rectangle pos;
        protected Rectangle pos;

        protected BasicAnimatedSprite run, initialJump, jumpLoop, falling;
        protected Actions actions;
        protected Point inc;
        protected int lives;

        //Properties
        public Rectangle Pos
        {
            set
            {
                run.Pos = value;
                initialJump.Pos = value;
                jumpLoop.Pos = value;
                falling.Pos = value;
               
            }
            get { return run.Pos; }
        }

      

        public int Lives   //properties to increment and decrement character lives
        {
            set
            {
                lives = value;
            }

            get
            {
                return lives;
            }
        }

        // Methods
        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
