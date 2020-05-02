using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FinalProject
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game elements
        Hero theHero;                            //Reaper man
        Background background1;

        Song song;

        //Variables
        int swidth = 1080, sheight= 720;        // The width and the height of the screen

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            swidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            sheight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            theHero = new Hero(new Rectangle(80, sheight - 175 , 100, 100));
            background1 = new Background();
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
            song = Content.Load<Song>("song");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;          //Repeat the song until we create a playlist

            theHero.LoadContent(Content);
            background1.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            theHero.Update(gameTime);
            background1.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            background1.Draw(spriteBatch);

            theHero.Draw(spriteBatch);           

            base.Draw(gameTime);
        }
    }
}
