using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _ballPosition;
        private Vector2 _ballVelocity;
        private float _velocityScalar = 100;
        private Texture2D _ballTexture;

        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Hello Game";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ballPosition = new Vector2(GraphicsDevice.Viewport.Width/2,GraphicsDevice.Viewport.Height/2);
            System.Random rand = new System.Random();
            _ballVelocity = new Vector2((float)rand.NextDouble(), (float)rand.NextDouble());
            _ballVelocity.Normalize();
            _ballVelocity *= _velocityScalar;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballTexture = Content.Load<Texture2D>("BallTexture");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _ballPosition += (float)gameTime.ElapsedGameTime.TotalSeconds * _ballVelocity;
            if (_ballPosition.X < GraphicsDevice.Viewport.X || _ballPosition.X > GraphicsDevice.Viewport.Width - 32) _ballVelocity.X *= -1; //Im using 32 instead of 64 because my ball texture
            if (_ballPosition.Y < GraphicsDevice.Viewport.Y || _ballPosition.Y > GraphicsDevice.Viewport.Height - 32) _ballVelocity.Y *= -1; // is half the size of the one you use in the tutorial.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_ballTexture, _ballPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}