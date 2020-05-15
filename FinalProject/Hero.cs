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
        bool hasJumped, collision;
        Color color;

        Actions actions;    //Enumerator instance

        public Hero(Rectangle pos)
        {
            run = new BasicAnimatedSprite(pos);           //States creation
            initialJump = new BasicAnimatedSprite(pos);
            jumpLoop = new BasicAnimatedSprite(pos);
            falling = new BasicAnimatedSprite(pos);

            collision = false;
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
            run.LoadContent(Content, "Run_Animation/0_Reaper_Man_Running_", 12, 40f);
            initialJump.LoadContent(Content, "Jump_Animation/0_Reaper_Man_Jump Start_", 6, 40f);
            jumpLoop.LoadContent(Content, "JumpLoop_Animation/0_Reaper_Man_Jump Loop_", 6, 40f);
            falling.LoadContent(Content, "Falling_Animation/0_Reaper_Man_Falling Down_", 6, 40f);

            color = Color.White;
            velocity = new Point(0, 0);     //Initialize the increment
        }

        public void ResetCollisions()
        {
            collision = false;
            color = Color.White;

        }

        public bool Collision(Rectangle check)
        {
            if (this.Pos.Intersects(check) || collision)
            {
                Rectangle temp = this.Pos; temp.Height = Pos.Width / 2;
                if (!temp.Intersects(check))
                {

                    collision = true;
                }
            }
            return collision;
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

            if (collision)
            {
                hasJumped = false;
            }

            if (hasJumped != true)      //Hero has not jumped
            {
                if (Keyboard.GetState().IsKeyDown(jump))
                {
                    hasJumped = true;           //Hero jumped
                    velocity.Y = Gravity * -1;
                }
            }

            if (hasJumped == true)      //When hero jumps
            {
                actions = Actions.INITIAL_JUMP;
                temp.Y += velocity.Y;
                velocity.Y += 1;
            }
            if (velocity.Y == 0)
            {
                actions = Actions.JUMP_LOOP;
                hasJumped = false;
                velocity.Y += 1;
            }
            if (velocity.Y > 0 && !collision)
            {
                actions = Actions.FALLING;
                hasJumped = true;

            }

            if (temp.Y + Pos.Height > 710)
            {
                /* temp.Y = 720 - Pos.Height; */ //Stop falling at bottom
                hasJumped = false;
                actions = Actions.RUN;
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