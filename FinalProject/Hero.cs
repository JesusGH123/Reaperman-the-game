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

namespace FinalProject 
{

    class Hero : AnimatedCharacter
    {
        Keys jump;
        int Gravity = 25;
        bool collisionObstacle;
        bool hasJumped/*, collision*/;
        private Color color;

        //Enumerator instance

        public Hero(int x, int y, int width, int height, int incX, int incY, Color color)
        : base(x, y, width, height, incX, incY)
        {
            
            LoadMoveSprites(Actions.RUN, x, y, width, height, "0_Reaper_Man_Running_", color, "Run_Animation", 12, .05f);
            LoadMoveSprites(Actions.INITIAL_JUMP, x, y, width, height, "0_Reaper_Man_Jump Start_", color, "Jump_Animation", 6, .05f);
            LoadMoveSprites(Actions.JUMP_LOOP, x, y, width, height, "0_Reaper_Man_Jump Loop_", color, "JumpLoop_Animation", 6, .05f);
            LoadMoveSprites(Actions.FALLING, x, y, width, height, "0_Reaper_Man_Falling Down_", color, "Falling_Animation", 6, .05f);

            //velocity = new Point(0, 0);
            collision = false;
            collisionObstacle = false;


        }

        public Color Color
        {
            set { color = value; }
            get { return color; }
        }

        public void SetKeys(Keys jump)
        {
            this.jump = jump;
        }

        public override void LoadContent() //Iherited Method from AnimatedCharacter
        {
            base.LoadContent();
        }


        public void ResetCollisions()
        {
            collision = false;
        }

        public void ResetCollisionsObstacle()
        {

            collisionObstacle = false;

        }

        public bool Collision(Rectangle checkColl)
        {

            if (Pos.Intersects(checkColl))

            {
                collisionObstacle = true;
               
            }

            return collisionObstacle;
        }

       

        public bool DirectionalCollision(Rectangle check) //Add this method in AnimatedCharacter
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

        public override void Update(GameTime gameTime) //Iherited Method from AnimatedCharacter
        {

            if (actions == Actions.JUMP_LOOP)
                actions = Actions.FALLING;

            else if (actions == Actions.FALLING)
                actions = Actions.RUN;

            Rectangle temp = this.Pos;          //Temporary rectangle for moving the hero

            if (collisionObstacle){
                color = Color.Red;
            }

            if (collision)
            {
                
                hasJumped = false;
            }

            if (hasJumped != true)      //Hero has not jumped
            {
                if (Keyboard.GetState().IsKeyDown(jump))
                {
                    hasJumped = true;           //Hero jumped
                    inc.Y = Gravity * -1;
                }
            }

            if (hasJumped == true)      //When hero jumps
            {
                actions = Actions.INITIAL_JUMP;
                temp.Y += inc.Y;
                inc.Y += 1;
            }
            if (inc.Y == 0)
            {
                actions = Actions.JUMP_LOOP;
                hasJumped = false;
                inc.Y += 1;
            }
            if (inc.Y > 0 && !collision)
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

            base.Update(gameTime); //Load method updates to all BAS objects
        }

        public override void Draw(GameTime gameTime) //Iherited Method from AnimatedCharacter
        {
            base.Draw(gameTime);
        }

    }
}