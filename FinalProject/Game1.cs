/* Autors:
        Jose de Jesus Garcia Hernandez
        Antonio Misael Delgado Salmeron
        Maria Fernanda Yañez Zavala         
    
    Current version: Alpha 2.1

*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections;
using System.Runtime.ExceptionServices;

namespace FinalProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game elements
        ArrayList coins, tiles, obstacles;

        Hero theHero;                            //Reaper man
        Background background1, background2;
        BasicSprite coinDraw;           //The coin of the score
        Song song;
        SoundEffect coinSound;

        //Variables
        int swidth = 1080, sheight = 720;        // The width and the height of the screen                       // The player score
        double timer = 0;                       
        Random random = new Random();            // Random values initializing

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            coins = new ArrayList();
            tiles = new ArrayList();

            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            sheight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;


        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = swidth;
            graphics.PreferredBackBufferHeight = sheight;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            AbstractSprite.SetContentManager(Content); //Esto lo tenemos que hacer para que carge el contendio 
            AbstractSprite.SetSpriteBatch(spriteBatch); //Y esto como es estatico le va a servir a todos los objetos

            song = Content.Load<Song>("song");      //Song
            coinSound = Content.Load<SoundEffect>("CoinSound");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;          //Repeat the song (If we want to create a playlist we need to delete this)

            theHero = new Hero(80, sheight - 140, 100, 100, 0, 0);     //I changed -175 for -140 here for debug
            background1 = new Background(0, 0, swidth, sheight,"Background/Layer_",Color.White);
            background2 = new Background(swidth, 0, swidth, sheight, "Background/Layer_", Color.White);

            //coinDraw = new BasicSprite(new Rectangle(10, 10, 40, 40));

            //Load the contents
            theHero.LoadContent();

            background1.LoadContent();
            background2.LoadContent();

            //coinDraw.LoadContent(Content, "Gold_1");


            theHero.SetKeys(Keys.Space);             //Sets the key "Space" for the character jumping
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;      //Timer for game events

            //Updates
            theHero.Update(gameTime);
            background1.Update(gameTime);
            background2.Update(gameTime);
            theHero.ResetCollisions();

            //Logic

            if (timer > 3)      //Coins spawn every 5 seconds
            {

                int randomTileY = random.Next(0, 3);        // The height in which the tile will spawn (RANDOM)

                if (randomTileY != 0)       // To print a tile if the platform is not in the ground
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Tile tile = new Tile(random.Next(swidth, 2 * swidth), (sheight - 120) - (randomTileY * 200), 400, 60, "Background/env_ground", Color.White);  //Positions the tiles under the coins and in a random X
                        tile.LoadContent();
                        tiles.Add(tile);
                    }
                }

                for (int i = 0; i < 3; i++)                //Coins spawn in groups of 3
                {
                    Coin coin = new Coin(swidth + (i * 50), (sheight - 145) - (randomTileY * 200), 35, 35, "AnimatedCoin", Color.White,10,1,.05f,44,40);     //Positions the coins separated between each other and in diferent heights
                    coin.LoadContent();
                    coins.Add(coin);
                }

                timer = timer - 5;          //  Reset timer
            }

            for (int i = 0; i < coins.Count; i++)              //Coin logic (for every coin in the arraylist)
            {
                ((Coin)coins[i]).Update(gameTime);

                if (((Coin)coins[i]).Pos.X < -45)            //Remove coin when it exits from screen for avoiding lag
                {
                    coins.RemoveAt(i);
                }

                if (((Coin)coins[i]).Collision(theHero.Pos))    //If the hero collects a coin the score increases by 1 and it is removed
                {
                    coins.RemoveAt(i);
                    coinSound.Play();
                }
            }

            for (int i = 0; i < tiles.Count; i++)              //Coin logic
            {
                ((BasicSprite)tiles[i]).Update(gameTime);
                theHero.DirectionalCollision(((BasicSprite)tiles[i]).Pos);

                if (((BasicSprite)tiles[i]).Pos.X < -400)            //Remove coin when it exits from screen
                {
                    tiles.RemoveAt(i);
                }
            }
                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            //Draw the objetcs
            background1.Draw(gameTime);
            background2.Draw(gameTime);
            theHero.Draw(gameTime);
            //coinDraw.Draw(spriteBatch);

            for (int i = 0; i < tiles.Count; i++)
            {
                ((Tile)tiles[i]).Draw(gameTime);
            }
            for (int i = 0; i < coins.Count; i++)
            {
                ((Coin)coins[i]).Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}