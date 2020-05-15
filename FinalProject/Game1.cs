/* Autors:
        Jose de Jesus Garcia Hernandez
        Antonio Misael Delgado Salmeron
        Maria Fernanda Yañez Zavala         
    
    Current version: Alpha 2.1

*/
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Schema;

namespace FinalProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        //Game elements
        ArrayList coins, tiles;

        Hero theHero;                            //Reaper man
        Background background1, background2;
        BasicSprite coinDraw;           //The coin of the score
        Song song;

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

            theHero = new Hero(new Rectangle(80, sheight - 175, 100, 100));
            background1 = new Background(new Rectangle(0, 0, swidth, sheight));
            background2 = new Background(new Rectangle(swidth, 0, swidth, sheight));
            coinDraw = new BasicSprite(new Rectangle(10, 10, 40, 40));
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

            song = Content.Load<Song>("song");      //Song
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;          //Repeat the song (If we want to create a playlist we need to delete this)

            //Load the contents
            theHero.LoadContent(Content);
            background1.LoadContent(Content);
            background2.LoadContent(Content);
            coinDraw.LoadContent(Content, "Gold_1");

            theHero.setKeys(Keys.Space);             //Sets the key "Space" for the character jumping
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            timer = timer + (float) gameTime.ElapsedGameTime.TotalSeconds;      //Timer for game events
            
            //Updates
            theHero.Update(gameTime);
            background1.Update(gameTime);
            background2.Update(gameTime);

            //Logic

            if (timer > 3)      //Coins spawn every 5 seconds
            {
                int randomTileY = random.Next(0, 3);        // The height in which the tile will spawn (RANDOM)

                if (randomTileY != 0)       // To print a tile if the platform is not in the ground
                {                                       
                        Tile tile = new Tile(new Rectangle(random.Next(swidth, 2 * swidth), (sheight - 120) - (randomTileY * 200), 400, 80));  //Positions the tiles under the coins and in a random X
                        tile.LoadContent(Content, "Background/env_ground");
                        tiles.Add(tile);

                }
                 
                for (int i = 0; i < 3; i++)                //Coins spawn in groups of 3
                {
                        Coin coin = new Coin (new Rectangle(swidth + (i * 50), (sheight - 140) - (randomTileY * 200), 35, 35));     //Positions the coins separated between each other and in diferent heights
                        coin.LoadContent(Content, "AnimatedCoin", 10, 40f, 10, 1, 44, 40);
                        coins.Add(coin);
                }

                timer = timer - 5;          //  Reset timer
            }

            for(int i = 0; i < coins.Count; i++)              //Coin logic (for every coin in the arraylist)
            {
                ((Coin)coins[i]).Update(gameTime);

                    if(((Coin)coins[i]).Pos.X < -45)            //Remove coin when it exits from screen for avoiding lag
                    {
                        coins.RemoveAt(i);
                    }

                    if (((Coin)coins[i]).Collision(theHero.Pos))    //If the hero collects a coin the score increases by 1 and it is removed
                    {
                        coins.RemoveAt(i);
                    }
            }

            for (int i = 0; i < tiles.Count; i++)              //Coin logic
            {
                ((BasicSprite)tiles[i]).Update(gameTime);

                if (((BasicSprite)tiles[i]).Pos.X < -500)            //Remove coin when it exits from screen
                {
                    tiles.RemoveAt(i);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw the objetcs
            background1.Draw(spriteBatch);
            background2.Draw(spriteBatch);
            theHero.Draw(spriteBatch);
            coinDraw.Draw(spriteBatch);

            for (int i = 0; i < tiles.Count; i++)
            {
                ((Tile)tiles[i]).Draw(spriteBatch);
            }
            for(int i = 0; i < coins.Count; i++)
            {
                ((Coin)coins[i]).Draw(spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}