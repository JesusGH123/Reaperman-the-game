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
    //Wrapper y personaje son similares, sin embargo van a tener dos estados diferentes
    enum State { NORMAL, EXPLODE }
    class TwoStates : IMonogame
    {

        public static int mapSpeed = 3;
        protected BasicSprite normalSprite; //Les ponemos protected porque vamos a derivar esta clase ya que se la heredaremos a la clase Bomb
        protected BasicAnimatedSprite normalAnimSprite;
        protected BasicAnimatedSprite explodeSprite;
        protected bool normalSpriteType;
        protected State state; //Con este elegiremos la direccion actual para dibujar los sprites

        protected Rectangle pos;

        public Rectangle Pos //Tuvimos que definir esta propiedad para que pudieramos
        {                    //meter un rectangulo en el metodo de Colision que tenemos
            set              //En la clase bomb el cual se llama Colision
            {
                if (normalSpriteType)
                    normalSprite.Pos = value; //Aqui la clase Wrapper nos da la posibilidad de poder elegir 
                else                        //la opcion de que tenga un contenido estatico y animado, si me da esa opcion por eso
                {                           //Debo de agregar codigo para poder especificar despues que propiedad voy a devolver
                    normalAnimSprite.Pos = value;
                }

                explodeSprite.Pos = value;
            }
            get
            {
                return explodeSprite.Pos; //en el caso del personaje no importaba cual regresabamos porque todos se iban
                                          //a actualizar al mismo tiempo, pero aqui regresamos el que siempre usamos que en este caso es explode 
            }                               //Porque es la animacion de la clase bomba
        }

        //Aui evitamos sobrecargar el consutrctor

        public void LoadNormalSprite(int x, int y, int width, int height, string filename, Color color)
        {
            //Necesitamos hacer 3 metodos polimorficos
            //Porque vamos a cargar estados normales para los objetos que estarán en el estado NORMAL
            //Uno puede ser una sola imagen sin animacion y los otros 2 pueden ser multiples and spritesheet
            normalSprite = new BasicSprite(x, y, width, height, filename, color);
            normalSpriteType = true;
        }

        public void LoadAnimatedSprite(State currentState, int x, int y, int width, int height, string filename, Color color, int framesX, int framesY, float timeFrame, int frameWidth, int frameHeight)
        {
            if (currentState == State.NORMAL)  //Para cargar archivos de spriteSheets
            {
                normalAnimSprite = new BasicAnimatedSprite(x, y, width, height, filename, color, framesX, framesY, timeFrame, frameWidth, frameHeight);
                normalSpriteType = false;
            }

            else if (currentState == State.EXPLODE) //Podemos agregar mas condiciones de estados
            {
                explodeSprite = new BasicAnimatedSprite(x, y, width, height, filename, color, framesX, framesY, timeFrame, frameWidth, frameHeight);
            }
        }
        public void LoadAnimatedSprite(State currentState, int x, int y, int width, int height, string filename, Color color, string dirname, int frames, float timeFrame)
        {
            if (currentState == State.NORMAL)  //Para cargar archivos de spriteSheets
            {
                normalAnimSprite = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
                normalSpriteType = false;
            }

            else if (currentState == State.EXPLODE) //Podemos agregar mas condiciones de estados
            {
                explodeSprite = new BasicAnimatedSprite(x, y, width, height, filename, color, dirname, frames, timeFrame);
            }
        }

        public virtual void LoadContent()
        {
            if (normalSpriteType)
                normalSprite.LoadContent();
            else
                normalAnimSprite.LoadContent();

            explodeSprite.LoadContent();
        }

        public virtual void Update(GameTime gameTime) //Este lo hacemos virtual para que podamos agregarle o quitarle
        {                                              //instrucciones al metodo Update que utilizamos en la clase Bomb
            switch (state)
            {
                case State.NORMAL:
                    if (normalSpriteType)
                        normalSprite.Update(gameTime);
                    else
                        normalAnimSprite.Update(gameTime);
                    break;
                case State.EXPLODE:
                    explodeSprite.Update(gameTime);
                    break;
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            switch (state)
            {
                case State.NORMAL:
                    if (normalSpriteType)
                        normalSprite.Draw(gameTime);
                    else
                        normalAnimSprite.Draw(gameTime);
                    break;
                case State.EXPLODE:
                    explodeSprite.Draw(gameTime);
                    break;

            }
        }
    }
}

