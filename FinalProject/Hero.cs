using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    enum Actions { RUN, DYE, DAMAGE, INITIAL_JUMP, JUMP_LOOP, FALLING };    //Reaper man states
    class Hero
    {
        BasicAnimatedSprite run;     
        BasicAnimatedSprite initialJump;
        BasicAnimatedSprite jumpLoop;
        BasicAnimatedSprite falling;

        Point velocity; //Incremento para la caída

        Keys jump;
        int Gravity = 25;

        Actions actions;    //Enumerator instance

        bool hasJumped;  public Hero(Rectangle pos)
        {
            run = new BasicAnimatedSprite(pos, 900, 900);           //States creation
            initialJump = new BasicAnimatedSprite(pos, 900, 900);
            jumpLoop = new BasicAnimatedSprite(pos, 900, 900);
            falling = new BasicAnimatedSprite(pos, 900, 900);

            actions = Actions.RUN;                              //Iniciar solo un enumerador
        }

        public Rectangle Pos
        {

            get { return run.Pos; }
            set
            {
                run.Pos = value;
                initialJump.Pos = value;
                jumpLoop.Pos = value;
                falling.Pos = value;

            }
        }

        public void setKeys(Keys jump)
        {
            this.jump = jump;
        }

        public void LoadContent(ContentManager Content)
        {
            run.LoadContent(Content, "Run_Animation", "0_Reaper_Man_Running_", 12);
            initialJump.LoadContent(Content, "Jump_Animation", "0_Reaper_Man_Jump Start_", 6);
            jumpLoop.LoadContent(Content, "JumpLoop_Animation", "0_Reaper_Man_Jump Loop_", 6);
            falling.LoadContent(Content, "Falling_Animation", "0_Reaper_Man_Falling Down_", 6);

            velocity = new Point(0, 0);     //Initialize the increment
        }

        public void Update(GameTime gameTime)
        {
            run.Update(gameTime);
            initialJump.Update(gameTime);
            jumpLoop.Update(gameTime);
            falling.Update(gameTime);

            if (actions == Actions.JUMP_LOOP)
                actions = Actions.FALLING;

            if (actions == Actions.FALLING)
                actions = Actions.RUN;

            Rectangle temp = this.Pos;          //Temporary rectangle for moving the hero

            if (hasJumped != true)      //Hero has not jumped
            {
                if (Keyboard.GetState().IsKeyDown(jump))
                {
                    hasJumped = true;           //Hero jumped
                    velocity.Y = Gravity;       
                }
            }

            if (hasJumped == true)      //When hero jumps
            {
                temp.Y -= velocity.Y;
                velocity.Y -= 1;
                actions = Actions.INITIAL_JUMP;
            }

            if (temp.Y + Pos.Height >= 720)
            {
                temp.Y = 720 - Pos.Height;  //Stop falling at bottom
                hasJumped = false;
                actions = Actions.RUN;
            }
            else
            {
                temp.Y += 1;                 //Falling
                actions = Actions.FALLING;
            }

            this.Pos = temp;       
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (actions == Actions.RUN)                     //Draw each state when necessary
                run.Draw(spriteBatch);
            else if (actions == Actions.JUMP_LOOP)
                jumpLoop.Draw(spriteBatch);
            else if (actions == Actions.FALLING)
                falling.Draw(spriteBatch);
            else if (actions == Actions.INITIAL_JUMP)
                initialJump.Draw(spriteBatch);
        }

    }
}
