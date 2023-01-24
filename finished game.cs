
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Drawing;
using System.Text.Encodings.Web;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Final_project
{
    public class Game1 : Game
    {
        //Random generator;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont words;
        Texture2D standerd;
        Texture2D left;
        Texture2D right;
        Texture2D astaroid;
        Texture2D space;
        Texture2D end;
        Texture2D introscr;
        Rectangle standard;
        Rectangle asteroid;
        Rectangle asteroid2;
        Rectangle asteroid3;
        Rectangle introRect;
        Rectangle Space;
        Rectangle endRect;
        Vector2 astaroidspeed;
        Vector2 astaroidspeed2;
        Vector2 astaroidspeed3;
        Vector2 speed;
        KeyboardState keyboardState;
        MouseState mousestate;
        Screen screen;
        enum Screen
        {
            intro,
            ship,
            end,
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
            standard = new Rectangle(425, 300, 50, 50);
            astaroidspeed = new Vector2(3, 11);
            astaroidspeed2 = new Vector2(5, 12);
            astaroidspeed3 = new Vector2(-2, 8);
            speed = new Vector2(0, 0);
            introRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            Space = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            endRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            space = Content.Load<Texture2D>("Spaace");
            end = Content.Load<Texture2D>("End Theme");
            standerd = Content.Load<Texture2D>("standerd");
            left = Content.Load<Texture2D>("fast-left");
            right = Content.Load<Texture2D>("fast-right");
            astaroid = Content.Load<Texture2D>("asteroid");
            words = Content.Load<SpriteFont>("Words");
            introscr = Content.Load<Texture2D>("intro");
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
                    speed.X += -7;
                }
                if (keyboardState.IsKeyDown(Keys.Right))  // Use intellisense to help you listen for any key
                {
                    speed.X += 7;
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    speed.Y += -7;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    speed.Y += 7;
                }

                if (standard.X < 0 || standard.Right > _graphics.PreferredBackBufferWidth)
                {
                    speed.X *= -1;
                }
                if (standard.Y < 0 || standard.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    speed.Y *= -1;
                }

                standard.X += (int)speed.X;
                standard.Y += (int)speed.Y;



                if (standard.Intersects(asteroid) || standard.Intersects(asteroid2) || standard.Intersects(asteroid3))
                {
                    screen = Screen.end;
                }



                if (asteroid.X < 0 || asteroid.Right > _graphics.PreferredBackBufferWidth)
                {
                    astaroidspeed.X *= -1;
                }
                if (asteroid.Y < 0 || asteroid.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    astaroidspeed.Y *= -1;
                }
                if (asteroid2.X < 0 || asteroid2.X > _graphics.PreferredBackBufferWidth - asteroid2.Width)
                {
                    astaroidspeed2.X *= -1;
                }
                if (asteroid2.Y < 0 || asteroid2.Y > _graphics.PreferredBackBufferHeight - asteroid2.Height)
                {
                    astaroidspeed2.Y *= -1;
                }
                if (asteroid3.X < 0 || asteroid3.X > _graphics.PreferredBackBufferWidth - asteroid3.Width)
                {
                    astaroidspeed3.X *= -1;
                }
                if (asteroid3.Y < 0 || asteroid3.Y > _graphics.PreferredBackBufferHeight - asteroid3.Height)
                {
                    astaroidspeed3.Y *= -1;
                }

                asteroid.X += (int)astaroidspeed.X;
                asteroid.Y += (int)astaroidspeed.Y;
                asteroid2.X += (int)astaroidspeed2.X;
                asteroid2.Y += (int)astaroidspeed2.Y;
                asteroid3.X += (int)astaroidspeed3.X;
                asteroid3.Y += (int)astaroidspeed3.Y;

            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            if (screen == Screen.intro)
            {
                _spriteBatch.Draw(introscr, introRect, Color.White);
            }

            if (screen == Screen.ship)
            {
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

                _spriteBatch.Draw(astaroid, asteroid, Color.White);
                _spriteBatch.Draw(astaroid, asteroid2, Color.White);
                _spriteBatch.Draw(astaroid, asteroid3, Color.White);
            }
            else if (screen == Screen.end)
            {
                _spriteBatch.Draw(end, endRect, Color.White);
            }


            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}