using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanPC
{
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
    }
    public enum BLOCK_TYPE { Floor = ' ', Wall = '#', Goal = '.'}
}
