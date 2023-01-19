
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Final_project
{
    public class Game1 : Game
    {
        Random generator;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont words;
        Texture2D standerd;
        Texture2D left;
        Texture2D right;
        Texture2D astaroid;
        Texture2D space;
        Rectangle standard;
        Rectangle asteroid;
        Rectangle asteroid2;
        Rectangle asteroid3;
        Rectangle Space;
        Vector2 astaroidspeed;
        Vector2 speed;
        KeyboardState keyboardState;
        MouseState mousestate;
        Screen screen;
        enum Screen
        {
            intro,
            ship,

        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.intro;
            screen = Screen.ship;
            base.Initialize();
            _graphics.PreferredBackBufferWidth = 1000; // Sets the width of the window to 800 pixels

            _graphics.PreferredBackBufferHeight = 800; // Sets the height of the window to 500 pixels

            _graphics.ApplyChanges(); // Applies the new dimensions
            asteroid = new Rectangle(500, 50, 100, 100);
            asteroid2 = new Rectangle(200, 200, 100, 100);
            asteroid3 = new Rectangle(700, 400, 100, 100);
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
            words = Content.Load<SpriteFont>("Words");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mousestate = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.intro)
             {
             if (mousestate.LeftButton == ButtonState.Pressed)
             {
                  screen = Screen.ship;
             }
                
            }

            if (screen == Screen.ship)
            {
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
            }
           

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
            _spriteBatch.Draw(astaroid, asteroid2, Color.White);
            _spriteBatch.Draw(astaroid, asteroid3, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}