using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SokobanPC
{
    public class Box
    {
        public Vector2 MoveVector = Vector2.Zero;
        public Vector2 Position { get; set; }
        public bool IsActive { get; set; }
        public int ID { get; set; }
        private static int Global_ID = 0;
        public Box(Vector2 position)
        {
            Position = position;
            ID = Global_ID++;
        }

        public void moveUp()
        {
            MoveVector = new Vector2(0, -1);
            Position += MoveVector;
        }
        public void moveLeft()
        {
            MoveVector = new Vector2(-1, 0);
            Position += MoveVector;
        }
        public void moveDown()
        {
            MoveVector = new Vector2(0, 1);
            Position += MoveVector;
        }
        public void moveRight()
        {
            MoveVector = new Vector2(1, 0);
            Position += MoveVector;
        }
        public void Update(GameTime gameTime)
        {
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D texture)
        {
            spriteBatch.Draw(texture, new Vector2(Position.X * (texture.Height), Position.Y * (texture.Height)), new Rectangle((IsActive ? 2:1 )* (texture.Height), 0, texture.Height, texture.Height), Color.White);
        }
    }
}
