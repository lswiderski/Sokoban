using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SokobanPC
{
    public enum BLOCK_TYPE { Floor = 1, Wall , Goal, Empty }
    class Block
    {
        public bool IsEmpty { get; set; }
        public BLOCK_TYPE BlockType { get; set; }

        public Block()
        {
            IsEmpty = true;
            BlockType = BLOCK_TYPE.Floor;
        }

        public Block(BLOCK_TYPE blockType)
        {
            BlockType = blockType;
            IsEmpty = true;
        }

        public Block(char blockType)
        {
            BlockType = (BLOCK_TYPE) blockType;
            IsEmpty = true;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texture, Vector2 position)
        {
            switch (BlockType)
            {
                case BLOCK_TYPE.Floor:
                    spriteBatch.Draw(texture, new Vector2(position.Y * (texture.Height), position.X * (texture.Height)), new Rectangle(5 * (texture.Height), 0, texture.Height, texture.Height), Color.White);
                    break;
                case BLOCK_TYPE.Wall:
                    spriteBatch.Draw(texture, new Vector2(position.Y * (texture.Height), position.X * (texture.Height)), new Rectangle(4 * (texture.Height), 0, texture.Height, texture.Height), Color.White);
                    break;
                case BLOCK_TYPE.Goal:
                    spriteBatch.Draw(texture, new Vector2(position.Y * (texture.Height), position.X * (texture.Height)), new Rectangle(3 * (texture.Height), 0, texture.Height, texture.Height), Color.White);
                    break;
                case BLOCK_TYPE.Empty:
                    spriteBatch.Draw(texture, new Vector2(position.Y * (texture.Height), position.X * (texture.Height)), new Rectangle(6 * (texture.Height), 0, texture.Height, texture.Height), Color.White);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    
}
