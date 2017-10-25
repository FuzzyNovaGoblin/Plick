using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Plick
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle visRect;
        Camera2d Camera;

        Player player;

        JoyStick joyStick;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Camera = new Camera2d(GraphicsDevice.Viewport, 3200, 3200, 1);
            Camera.Pos = new Vector2(0, 0);
            visRect = new Rectangle(GraphicsDevice.Viewport.Width / 4, GraphicsDevice.Viewport.Height / 4, GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            joyStick = new JoyStick(Content.Load<Texture2D>("joyStickBase"), Content.Load<Texture2D>("joyStickTop"));

             player = new Player(new Vector2(100, 100), Content.Load<Texture2D>("PlickTheFish"));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            player.update();
            //MoveCam();
            joyStick.Update();
            Touch();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.MidnightBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront,
                    null, null, null, null, null,
                    Camera.GetTransformation());


            player.Draw(spriteBatch);
            joyStick.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void MoveCam()
        {
            if (!visRect.Contains(player.rotPos))
            {
                if (visRect.X > player.rotPos.X)
                {
                    visRect.X = (int)player.rotPos.X;
                }
                else if(visRect.X+visRect.Width < player.rotPos.X)
                {
                    visRect.X = (int)player.rotPos.X;
                }

                if (visRect.Y > player.rotPos.Y)
                {
                    visRect.Y = (int)player.rotPos.Y;
                }
                else if (visRect.Y + visRect.Height < player.rotPos.Y)
                {
                    visRect.Y = (int)player.rotPos.Y;
                }
            }
        }

        public void Touch()
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            if (touchCollection.Count > 0)
            {
                
                if (touchCollection[0].State == TouchLocationState.Released)
                {
                    Camera.Move(new Vector2(10, 10));
                    Log.Debug("Position: ", touchCollection[0].Position.ToString());
                }

            }
                    
        }

    }
}
