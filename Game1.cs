using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Tanks.Model;

namespace Tanks
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Tank tank;
        private List<Bullet> bullets = new List<Bullet>();
        private Camera2d camera = new Camera2d();
        MouseState currentState;
        MouseState lastState;
        public static System.Drawing.Rectangle screen = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        public static int game_ground_width = screen.Width / 3;
        public static int game_ground_height = screen.Height / 3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            camera.Pos = new Vector2(screen.Width/6, screen.Height/6);
            _graphics.PreferredBackBufferWidth = screen.Width;
            _graphics.PreferredBackBufferHeight = screen.Height;
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            this.tank = new Tank(Content);
            this.tank.position = camera.Pos;
            this.currentState = new MouseState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastState = currentState;
            currentState = Mouse.GetState();
            if(lastState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed)
            {
                this.bullets.Add(this.tank.Shoot());
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.W))
            {
                this.tank.Move_Up();
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.D))
            {
                this.tank.Move_Right();
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.S))
            {
                this.tank.Move_Down();
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {
                this.tank.Move_Left();
            }

            if(this.bullets != null)
            {
                foreach (var item in this.bullets)
                {
                    item.Fly();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null, null, camera.get_transformation(GraphicsDevice));
            _spriteBatch.Draw(Content.Load<Texture2D>("brick"), new Vector2(-1, 0), new Rectangle(-1, 0, game_ground_width + 1, game_ground_height), Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            _spriteBatch.Draw(Content.Load<Texture2D>("grass"), new Vector2(16, 16), new Rectangle(0, 0, game_ground_width - 30, game_ground_height - 32), Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
            _spriteBatch.End();

            if (this.bullets != null)
            {
                foreach (var item in this.bullets)
                {
                    item.Draw(_spriteBatch);
                }
            }

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null,null,camera.get_transformation(GraphicsDevice));
            _spriteBatch.Draw(this.tank.texture, this.tank.position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
