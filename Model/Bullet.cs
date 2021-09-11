using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tanks.Model
{
    public enum Direction { Up,Right,Down,Left}

    class Bullet
    {
        Direction direction;
        ContentManager Content;
        Vector2 position;
        Texture2D texture;


        public Bullet(Direction direction, ContentManager content, Vector2 tank_position)
        {
            this.Content = content;
            this.direction = direction;
            switch (direction)
            {
                case Direction.Up:
                    this.texture = Content.Load<Texture2D>("bullet_U");
                    this.position = new Vector2(tank_position.X*3 + 14, tank_position.Y*3-3);
                    break;
                case Direction.Right:
                    this.texture = Content.Load<Texture2D>("bullet_R");
                    this.position = new Vector2(tank_position.X*3 + 32, tank_position.Y*3 + 12);
                    break;
                case Direction.Down:
                    this.texture = Content.Load<Texture2D>("bullet_D");
                    this.position = new Vector2(tank_position.X*3 + 14, tank_position.Y*3 + 30);
                    break;
                case Direction.Left:
                    this.texture = Content.Load<Texture2D>("bullet_L");
                    this.position = new Vector2(tank_position.X*3-1, tank_position.Y*3 + 12);
                    break;
            }
        }

        public void Fly()
        {
            switch (direction)
            {
                case Direction.Up:
                    this.position.Y -= 10;
                    break;
                case Direction.Right:
                    this.position.X += 10;
                    break;
                case Direction.Down:
                    this.position.Y += 10;
                    break;
                case Direction.Left:
                    this.position.X -= 10;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, texture.Bounds, Color.White);
            spriteBatch.End();
        }
    }
}
