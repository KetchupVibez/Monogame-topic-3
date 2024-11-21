using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_topic_3
{
    public class Game1 : Game
    {
        Texture2D tribbleGreyTexture, tribbleBrownTexture, tribbleCreamTexture, tribbleOrangeTexture, cradleTexture;
        Rectangle greyTribbleRect, brownTribbleRect, creamTribbleRect, orangeTribbleRect, window, cradleRect;
        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleCreamSpeed, tribbleOrangeSpeed;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            greyTribbleRect = new Rectangle(10, 250, 100, 100);
            brownTribbleRect = new Rectangle(160, 250, 100, 100);
            creamTribbleRect = new Rectangle(310, 250, 100, 100);
            orangeTribbleRect = new Rectangle(460, 250, 100, 100);
            cradleRect = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 600; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions 
            tribbleGreySpeed = new Vector2(4, 0);
            tribbleBrownSpeed = new Vector2(4, 0);
            tribbleCreamSpeed = new Vector2(4, 0);
            tribbleOrangeSpeed = new Vector2(4, 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            cradleTexture = Content.Load<Texture2D>("cradle");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            greyTribbleRect.X += (int)tribbleGreySpeed.X;
            greyTribbleRect.Y += (int)tribbleGreySpeed.Y;
            if (greyTribbleRect.Right > _graphics.PreferredBackBufferWidth || greyTribbleRect.Left < 0)
                tribbleGreySpeed.X *= -1;
            if (greyTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || greyTribbleRect.Top < 0)
                tribbleGreySpeed.Y *= -1;
            creamTribbleRect.X += (int)tribbleCreamSpeed.X;
            creamTribbleRect.Y += (int)tribbleCreamSpeed.Y;
            if (creamTribbleRect.Right > _graphics.PreferredBackBufferWidth || creamTribbleRect.Left < 0)
                tribbleCreamSpeed.X *= -1;
            if (creamTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || creamTribbleRect.Top < 0)
                tribbleCreamSpeed.Y *= -1;
            orangeTribbleRect.X += (int)tribbleOrangeSpeed.X;
            orangeTribbleRect.Y += (int)tribbleOrangeSpeed.Y;
            if (orangeTribbleRect.Right > _graphics.PreferredBackBufferWidth || orangeTribbleRect.Left < 0)
                tribbleOrangeSpeed.X *= -1;
            if (orangeTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || orangeTribbleRect.Top < 0)
                tribbleOrangeSpeed.Y *= -1;
            if (brownTribbleRect.Right > _graphics.PreferredBackBufferWidth || brownTribbleRect.Left < 0)
                tribbleBrownSpeed.X *= -1;
            if (brownTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || brownTribbleRect.Top < 0)
                tribbleBrownSpeed.Y *= -1;
            brownTribbleRect.X += (int)tribbleBrownSpeed.X;
            brownTribbleRect.Y += (int)tribbleBrownSpeed.Y;

            if (greyTribbleRect.Intersects(brownTribbleRect))
            {
                greyTribbleRect.X -= 2;
                brownTribbleRect.X += 2;

                tribbleGreySpeed.X *= -1;
                tribbleBrownSpeed.X *= -1;

            }
            if (creamTribbleRect.Intersects(orangeTribbleRect))
            {
                creamTribbleRect.X -= 2;
                orangeTribbleRect.X += 2;

                tribbleCreamSpeed.X *= -1;
                tribbleOrangeSpeed.X *= -1;
            }
            
            if (creamTribbleRect.Intersects(brownTribbleRect))
            {
                creamTribbleRect.X += 2;
                brownTribbleRect.X -= 2;

                tribbleCreamSpeed.X *= -1;
                tribbleBrownSpeed.X *= -1;

            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightCoral);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(cradleTexture, cradleRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
