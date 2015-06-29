using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SokobanPC
{
    public class Player
    {
        private Texture2D texture;
        public Vector2 Position { get; set; }

        public Player(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            Position = _position;
        }
        public Player(Texture2D _texture)
        {
            texture = _texture;
            Position = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(Position.Y * (texture.Height), Position.X * (texture.Height)), new Rectangle(0, 0, texture.Height, texture.Height), Color.White);
        }
    }
}
