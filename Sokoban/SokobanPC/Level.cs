using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SokobanPC
{
    class Level
    {
        private Block[,] Map;
        private string exampleLevel = @"#####
#@  #
# $.#
# $.#
#####";
        private Texture2D textures;
        private Player player;
        private List<Box> boxes;
        public string SolvePath { get; set; }

        public Level(Texture2D textures, Player _player, ref List<Box> _boxes )
        {
            NewEmptyLevel(1, 1);
            player = _player;
            boxes = _boxes;
            ParseLevel(exampleLevel);
            this.textures = textures;
            

        }

        public void NewEmptyLevel(int sizeX, int sizeY)
        {
            Map = new Block[sizeX, sizeY];
        }

        public void LoadLevel(LevelData levelData)
        {
            boxes.Clear();
            ParseLevel(levelData.Level);
            SolvePath = levelData.SolvePath;
        }
        private void ParseLevel(string _txt)
        {
            int numLines = _txt.Split('\n').Length;
            int charsInRow = _txt.Length / numLines;
            Map = new Block[numLines, charsInRow];

            using (StringReader reader = new StringReader(_txt))
            {
                string line;
                int rowIndex = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    bool isWallInLineAlready = false;
                    for (int i = 0; i < charsInRow; i++)
                    {

                       
                        if (i < line.Length)
                        {
                            switch (line[i])
                            {
                                case '#': Map[rowIndex, i] = new Block(BLOCK_TYPE.Wall);
                                    isWallInLineAlready = true;
                                    break;
                                    //player
                                case '@': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor);
                                    player.Position = new Vector2( i, rowIndex);
                                    break;
                                // player on goal
                                case '+': Map[rowIndex, i] = new Block(BLOCK_TYPE.Goal);
                                    player.Position = new Vector2(i, rowIndex);
                                    break;
                                //Box
                                case '$': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor){IsEmpty = false};
                                    boxes.Add(new Box(new Vector2(i, rowIndex)));
                                    break;
                                //Box on goal
                                case '*': Map[rowIndex, i] = new Block(BLOCK_TYPE.Goal) { IsEmpty = false };
                                    boxes.Add(new Box(new Vector2(i, rowIndex)));
                                    break;
                                case '.': Map[rowIndex, i] = new Block(BLOCK_TYPE.Goal);
                                    break;
                                case ' ': Map[rowIndex, i] =  new Block( isWallInLineAlready ? BLOCK_TYPE.Floor : BLOCK_TYPE.Empty);
                                    break;
                            }
                        }
                        else
                        {
                            Map[rowIndex, i] = new Block(BLOCK_TYPE.Empty);
                        }
                    }
                    rowIndex++;
                }
            }
        }

        public BLOCK_TYPE getType(int indexX, int indexY)
        {
            return Map[indexY, indexX].BlockType;
        }
        public BLOCK_TYPE getType(Vector2 position)
        {
            return Map[(int)position.Y, (int)position.X].BlockType;
        }
        public bool isEmpty(int indexX, int indexY)
        {
            return Map[indexY, indexX].IsEmpty;
        }
        public void SetEmpty(Vector2 position, bool empty = true)
        {
            Map[(int)position.Y, (int)position.X].IsEmpty = empty;
        }
        public bool isEmpty(Vector2 position)
        {
            return Map[(int)position.Y, (int)position.X].IsEmpty;
        }

        public bool isWall(int indexX, int indexY)
        {
            return Map [indexY, indexX].BlockType == BLOCK_TYPE.Wall;
        }
        public bool isWall(Vector2 position)
        {
            return Map[(int)position.Y, (int)position.X].BlockType == BLOCK_TYPE.Wall;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j].Draw(spriteBatch, textures, new Vector2(i,j));
                    //if (!Map[i, j].IsEmpty)
                    //{
                    //    spriteBatch.Draw(textures, new Vector2(j* (textures.Height), i * (textures.Height)), new Rectangle(1 * (textures.Height), 0, textures.Height, textures.Height), Color.White);
                    //}
                }
            }
        }
    }
}
