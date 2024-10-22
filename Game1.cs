using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Globalization;

namespace Monogame_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;

        Texture2D greyTribbleTexture, brownTribbleTexture, creamTribbleTexture;
        Rectangle greyTribbleRec, brownTribbleRec, creamTribbleRec;


        Vector2 greyTribbleSpeed, brownTribbleSpeed, creamTribbleSpeed;
        bool lavenderBlush;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            greyTribbleRec = new Rectangle(300,10,100,100);
            greyTribbleSpeed = new Vector2(2, 4);
            brownTribbleRec = new Rectangle(300,300,100,100);
            brownTribbleSpeed = new Vector2(2, 4);
            creamTribbleRec = new Rectangle(450,400,100,100);
            creamTribbleSpeed = new Vector2(2, 4);
            window = new Rectangle(0, 0,800,600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greyTribbleTexture = Content.Load<Texture2D>("tribbleGrey");
            brownTribbleTexture = Content.Load<Texture2D>("tribbleBrown");
            creamTribbleTexture = Content.Load<Texture2D>("tribbleCream");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            greyTribbleRec.X += (int)greyTribbleSpeed.X;
            
            greyTribbleRec.Y += (int)greyTribbleSpeed.Y;

            if (greyTribbleRec.Right >= window.Width || greyTribbleRec.X <= 0)
                greyTribbleSpeed.X *= -1;
            if (greyTribbleRec.Bottom >= window.Height  || greyTribbleRec.Top <= 0)
                greyTribbleSpeed.Y *= -1;

            brownTribbleRec.X += (int)brownTribbleSpeed.X;

            brownTribbleRec.Y += (int)brownTribbleSpeed.Y;

            if (brownTribbleRec.Right >= window.Width || brownTribbleRec.X <= 0)
                brownTribbleRec.X = 0;
            if (brownTribbleRec.Bottom >= window.Height || brownTribbleRec.Top <= 0)
                brownTribbleSpeed.Y *= -1;

            creamTribbleRec.X += (int)creamTribbleSpeed.X;
            creamTribbleRec.Y += (int)creamTribbleSpeed.Y;

            if (creamTribbleRec.Right >= window.Width || creamTribbleRec.X <= 0)
            {
                creamTribbleSpeed.X *= -1;
                lavenderBlush = true;
                
            }
            if (creamTribbleRec.Bottom >= window.Height || creamTribbleRec.Top <= 0)
                creamTribbleSpeed.Y *= -1;
            lavenderBlush = true;






            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(greyTribbleTexture, greyTribbleRec, Color.White);
            _spriteBatch.Draw(brownTribbleTexture,brownTribbleRec, Color.White);
            _spriteBatch.Draw(creamTribbleTexture, creamTribbleRec, Color.White);
            if (lavenderBlush == true)
            { 
            _spriteBatch.Draw(creamTribbleTexture,creamTribbleRec, Color.LavenderBlush);
            }




            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
