
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D standerd;
        Texture2D left;
        Texture2D right;
        Texture2D astaroid;
        Texture2D space;
        Rectangle standard;
        Rectangle Leftt;
        Rectangle Rightt;
        Rectangle asteroid;
        Rectangle Space;
        Vector2 astaroidspeed;
        Vector2 speed;
        KeyboardState keyboardState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.PreferredBackBufferWidth = 1000; // Sets the width of the window to 800 pixels

            _graphics.PreferredBackBufferHeight = 800; // Sets the height of the window to 500 pixels

            _graphics.ApplyChanges(); // Applies the new dimensions
            asteroid = new Rectangle(500,10,40,40);
            standard = new Rectangle(425, 300, 100, 100);
            astaroidspeed = new Vector2(0, 0);
            speed = new Vector2(0, 0);
            Space = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            space = Content.Load<Texture2D>("space");
            standerd = Content.Load<Texture2D>("standerd");
            left = Content.Load<Texture2D>("fast-left");
            right = Content.Load<Texture2D>("fast-right");
            astaroid = Content.Load<Texture2D>("asteroid");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            keyboardState = Keyboard.GetState();
            speed.X = 0;
            speed.Y = 0;
            if (keyboardState.IsKeyDown(Keys.Left))  // Use intellisense to help you listen for any key
            {
                speed.X += -5;
            }
            if (keyboardState.IsKeyDown(Keys.Right))  // Use intellisense to help you listen for any key
            {
                speed.X += 5;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                speed.Y += -5;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                speed.Y += 5;
            }

            standard.X += (int)speed.X;
            standard.Y += (int)speed.Y;    

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            _spriteBatch.Draw(space, Space, Color.White);
            if (speed.X > 0)
            {
                _spriteBatch.Draw(right, standard, Color.White);
            }
            else if (speed.X < 0)
            {
                _spriteBatch.Draw(left, standard, Color.White);
            } 
            else
            {
                _spriteBatch.Draw(standerd, standard, Color.White);
            }

            _spriteBatch.Draw(astaroid,asteroid,Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}