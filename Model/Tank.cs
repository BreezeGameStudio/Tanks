using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tanks.Model
{
    class Tank
    {
        private string name;
        private ContentManager Content;

        public int health;
        public int max_health = 4;
        public float speed = 1f;

        public Vector2 position;
        public Rectangle collision_box;
        public Texture2D texture;

        public Tank(ContentManager content)
        {
            this.Content = content;
            this.health = this.max_health;
            this.position = new Vector2(0, 0);
            this.texture = this.Content.Load<Texture2D>("tank_U");
            this.collision_box = texture.Bounds;
        }

        public Bullet Shoot()
        {
            Direction direction = Direction.Up;
            if (this.texture == this.Content.Load<Texture2D>("tank_U"))
            {
                direction = Direction.Up;
            }
            else if (this.texture == this.Content.Load<Texture2D>("tank_R"))
            {
                direction = Direction.Right;
            }
            else if (this.texture == this.Content.Load<Texture2D>("tank_D"))
            {
                direction = Direction.Down;
            }
            else if (this.texture == this.Content.Load<Texture2D>("tank_L"))
            {
                direction = Direction.Left;
            }
            return new Bullet(direction, Content, this.position);
        }

        #region Move_Methods
        public void Move_Up()
        {
            if(this.position.Y > 16){
                this.position.Y -= speed;
                this.texture = this.Content.Load<Texture2D>("tank_U");
            }
        }

        public void Move_Right()
        {
            if(this.position.X < Game1.game_ground_width - 30)
            {
                this.position.X += speed;
                this.texture = this.Content.Load<Texture2D>("tank_R");
            }
        }

        public void Move_Down()
        {
            if (this.position.Y < Game1.game_ground_height - 32)
            {
                this.position.Y += speed;
                this.texture = this.Content.Load<Texture2D>("tank_D");
            }
        }

        public void Move_Left()
        {
            if (this.position.X > 16)
            {
                this.position.X -= speed;
                this.texture = this.Content.Load<Texture2D>("tank_L");
            }
        }
        #endregion
    }
}
