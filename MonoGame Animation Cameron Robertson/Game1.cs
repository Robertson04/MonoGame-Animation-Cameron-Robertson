using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Animation_Cameron_Robertson
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Random generator = new Random();
        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;
        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;
        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;
        Texture2D StarTrekTexture;
        SoundEffect crash;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            tribbleGreySpeed = new Vector2(2, 7);
            tribbleBrownSpeed = new Vector2(4, 0);
            tribbleCreamSpeed = new Vector2(0, 4);
            tribbleOrangeSpeed = new Vector2(10, 10);
            
            base.Initialize();
            tribbleGreyRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleGreyRect.Width);
            tribbleGreyRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleGreyRect.Height);
            tribbleBrownRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleBrownRect.Width);
            tribbleBrownRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleBrownRect.Height);
            tribbleCreamRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleCreamRect.Width);
            tribbleCreamRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleCreamRect.Height);
            tribbleOrangeRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleOrangeRect.Width);
            tribbleOrangeRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleOrangeRect.Height);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleGreyRect = new Rectangle(0, 0, 100, 100);
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownRect = new Rectangle(0, 0, 100, 100);
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleCreamRect = new Rectangle(0, 0, 100, 100);
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleOrangeRect = new Rectangle(0, 0, 100, 100);
            StarTrekTexture = Content.Load<Texture2D>("StarTrek");
            crash = Content.Load<SoundEffect>("crash");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                tribbleGreyRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleGreyRect.Width);
                tribbleGreyRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleGreyRect.Height);
                crash.Play();
            }
            if (tribbleGreyRect.Top < 0 || tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleGreyRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleGreyRect.Width);
                tribbleGreyRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleGreyRect.Height);
                crash.Play();
            }
            if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                tribbleBrownRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleBrownRect.Width);
                tribbleBrownRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleBrownRect.Height);
                crash.Play();
            }
            if (tribbleCreamRect.Top < 0 || tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleCreamSpeed.Y *= -1;
                tribbleCreamRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleCreamRect.Width);
                tribbleCreamRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleCreamRect.Height);
                crash.Play();
            }
            if (tribbleOrangeRect.Top < 0 || tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleOrangeSpeed.Y *= -1;
                tribbleOrangeRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleOrangeRect.Width);
                tribbleOrangeRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleOrangeRect.Height);
                crash.Play();
            }
            if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
            {
                tribbleOrangeSpeed.X *= -1;
                tribbleOrangeRect.X = generator.Next(0, _graphics.PreferredBackBufferWidth - tribbleOrangeRect.Width);
                tribbleOrangeRect.Y = generator.Next(0, _graphics.PreferredBackBufferHeight - tribbleOrangeRect.Height);
                crash.Play();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(StarTrekTexture, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
