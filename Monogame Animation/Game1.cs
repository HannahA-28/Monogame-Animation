using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Rectangle window;

        Texture2D greyHairtexture;
        Rectangle greyHairRect;
        Vector2 greyHairSpeed;

        Texture2D blondeHairtexture;
        Rectangle blondeHairRect;
        Vector2 blondeHairSpeed;
        Color blondeHairColor;

        Texture2D brownHairtexture;
        Rectangle brownHairRect;
        Vector2 brownHairSpeed;
        Color brownHairColor;

        Texture2D orangeHairtexture;
        Rectangle orangeHairRect;
        Vector2 orangeHairSpeed;

        Color backGroundColor;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            greyHairRect = new Rectangle(100, 500, 100, 100);
            greyHairSpeed = new Vector2(0, 2);

            blondeHairRect = new Rectangle(600, 250, 100, 100);
            blondeHairSpeed = new Vector2(-4, 2);

            brownHairRect = new Rectangle(3, 50, 100, 100);
            brownHairSpeed = new Vector2(4, 2);

            orangeHairRect = new Rectangle(1, 300, 100, 100);
            orangeHairSpeed = new Vector2(-6, 0);

            blondeHairColor = Color.White;
            brownHairColor = Color.White;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            greyHairtexture = Content.Load<Texture2D>("greyHair");

            blondeHairtexture = Content.Load<Texture2D>("blondeHair");

            brownHairtexture = Content.Load<Texture2D>("brownHair");

            orangeHairtexture = Content.Load<Texture2D>("orangeHair");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            greyHairRect.X += (int)greyHairSpeed.X;
            if (greyHairRect.Right >= window.Width || greyHairRect.Left <= 0)
            {
                greyHairSpeed.X *= -1;
            }
            if (greyHairRect.Bottom >= window.Height || greyHairRect.Top <= 0)
            {
                greyHairSpeed.Y *= -1;
            }
            greyHairRect.Y += (int)greyHairSpeed.Y;

            blondeHairRect.X += (int)blondeHairSpeed.X;
            if (blondeHairRect.Right >= window.Width || blondeHairRect.Left <= 0)
            {
                blondeHairSpeed.X *= -1;
                backGroundColor = Color.MediumPurple;
                blondeHairColor = Color.LightSeaGreen;
            }
            if (blondeHairRect.Bottom >= window.Height || blondeHairRect.Top <= 0)
            {
                blondeHairSpeed.Y *= -1;
                backGroundColor = Color.LightSeaGreen;
                blondeHairColor = Color.MediumPurple;
            }
            blondeHairRect.Y += (int)blondeHairSpeed.Y;

            brownHairRect.X += (int)brownHairSpeed.X;
            if (brownHairRect.Right >= window.Width || brownHairRect.Left <= 0)
            {
                brownHairSpeed.X *= -1;
                brownHairRect = new Rectangle(100, 300, 50, 50);
                brownHairColor = Color.HotPink;
            }
            if (brownHairRect.Bottom >= window.Height || brownHairRect.Top <= 0)
            {
                brownHairSpeed.Y *= -1;
                brownHairRect = new Rectangle(100, 300, 200, 200);
                brownHairColor = Color.Blue;
            }
            brownHairRect.Y += (int)brownHairSpeed.Y;

            orangeHairRect.X += (int)orangeHairSpeed.X;
            if (orangeHairRect.Right >= window.Width || orangeHairRect.Left <= 0)
            {
                orangeHairSpeed.X *= -1;
                orangeHairRect = new Rectangle(1, 300, 100, 100);
            }
            if (orangeHairRect.Bottom >= window.Height || orangeHairRect.Top <= 0)
            {
                orangeHairSpeed.Y *= -1;
            }
            orangeHairRect.Y += (int)orangeHairSpeed.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backGroundColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(greyHairtexture, greyHairRect, Color.White);
            _spriteBatch.Draw(blondeHairtexture, blondeHairRect, blondeHairColor);
            _spriteBatch.Draw(brownHairtexture, brownHairRect, brownHairColor);
            _spriteBatch.Draw(orangeHairtexture, orangeHairRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
