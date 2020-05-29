using System;
using System.Collections.Generic;
using System.Collections;
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
    class AnimatedCharacter : AbstractCharacter
    {
        protected ArrayList obstacles; //Defino el arrayList para poder detectar colisiones
        protected bool collision;   //Lo utilizare para detectar colisiones entre piedras y personaje

        public AnimatedCharacter(int x, int y, int width, int height, int incX, int incY)
        {      
            pos = new Rectangle(x, y, width, height);
            inc = new Point(incX, incY);
        }

        public void LoadStandSprites(Actions currentDirection, int x, int y, int width, int height, string filename, Color color)
        {
            switch (currentDirection)
            {
                

                default:
                    break;
            }
        }

        // For SINGLE FILE animated sprites
        public void LoadMoveSprites(Actions currentDirection, int x, int y, int width, int height, string filename, Color color, int framesX, int framesY, float timeFrame, int frameWidth, int frameHeight)
        {
            switch (currentDirection)
            {
                    //This is a method to create objetcs with animations of spritesheets

                default:
                    break;
            }
        }

        // For MULTIPLE FILE animated sprites
        public void LoadMoveSprites(Actions currentDirection, int x, int y, int width, int height, string filename, Color color, string dirname, int frames, float timeFrame)
        {
            switch (currentDirection)
            {
                case Actions.RUN:
                    run = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
                    break;

                case Actions.INITIAL_JUMP:
                    initialJump = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
                    break;

                case Actions.JUMP_LOOP:
                    jumpLoop = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
                    break;

                case Actions.FALLING:
                    falling = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
                    break;

                    //In this space we can add a falling object

                default:
                    break;
            }
        }

        public void SetObstacules(ArrayList obstaclesIn)
        {                               //Aqui hago agregación 
            this.obstacles = obstaclesIn; //Aqui estoy agregando porque no estoy generando un arreglo dentro de mi clase
        }                               //Estoy diciendo que ese arreglo se genera por fuera, y despues se los paso aqui adentro a mi personaje animado
                                        //Ya tengo una referencia a un arreglo que tendra N numero de piedras


        public bool ValidatePosition(Rectangle check) //Este metodo detectará las colisiones entre el auto y user Character
        {                                              //Para luego decidir si nuestro personaje se mueve o no al colisionar con las piedras
                                                       //Aqui estaríamos haciendo uso de agregación y tenemos que usar ArrayList para las piedras

            /*collision = false;*/ // al principio no detectamos colisiones

            for (int i = 0; i < obstacles.Count; i++)   //Aqui estoy recibiendo un arreglo por agregacion gracias al metodo de arriba
            {                                     //El arreglo se genera en game1

                //Voy a verificar la posicion de mi personaje contra todas las posiciones de los obstaculos,
                //si colisiona con al menos uno entonces no avanzaré
                if (check.Intersects(((BasicSprite)obstacles[i]).Pos))
                //si la posicion de mi personjae (check) intersecta con cada una de las posiciones de las piedras
                //Aqui se hace el casteo de BS porque de ahi crearemos el objeto pero despues tendremos que cambiarlo segun nuestra clase
                {
                    collision = true;
                    break; //Aqui termino el for cuando se cumple la condicion
                }
            }
            return !collision; //Aqui reinvertimos la logica, regreso el valor negado. Es decir, si no tengo colisiones si puedo avanzar
        }                       //si tengo colisiones entonces no puedo avanzar

        public override void LoadContent()
        {
            run.LoadContent();
            initialJump.LoadContent(); //We need to load BAS objects content
            jumpLoop.LoadContent();
            falling.LoadContent();
            
        }

        public override void Update(GameTime gameTime)
        {
            // Update the current sprite - guarantees that animated character will be animated
            if (actions == Actions.RUN)
                run.Update(gameTime);
            else if (actions == Actions.INITIAL_JUMP)
                initialJump.Update(gameTime);
            else if (actions == Actions.JUMP_LOOP)
                jumpLoop.Update(gameTime);
            else if (actions == Actions.FALLING)
                falling.Update(gameTime);
            //TO DO
           //Add dying 
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw the current sprite
            if (actions == Actions.RUN)
                run.Draw(gameTime);
            else if (actions == Actions.INITIAL_JUMP)
                initialJump.Draw(gameTime);
            else if (actions == Actions.JUMP_LOOP)
                jumpLoop.Draw(gameTime);
            else if (actions == Actions.FALLING)
                falling.Draw(gameTime);

            //Add dying
        }
    }
}
