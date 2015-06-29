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
        private string exampleLevel = @"  ####
### @#
#    #
# .#.###
# $    #
##*#*# #
# $    #
#   ####
#####";
        private Texture2D textures;
        private Player player;

        public Level(Texture2D textures, Player _player)
        {
            newEmptyLevel(1, 1);
            player = _player;
            parseLevel(exampleLevel);
            this.textures = textures;
            
        }

        public void newEmptyLevel(int sizeX, int sizeY)
        {
            Map = new Block[sizeX, sizeY];
        }
        public void parseLevel(string _txt)
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
                                case '@': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor);
                                    player.Position = new Vector2(rowIndex, i);
                                    break;
                                case '+': Map[rowIndex, i] = new Block(BLOCK_TYPE.Goal);
                                    // player on goal
                                    break;
                                case '$': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor);
                                    //Box
                                    break;
                                case '*': Map[rowIndex, i] = new Block(BLOCK_TYPE.Goal);
                                    //Box on goal
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

                            //TODO: Empty block
                        }
                    }
                    rowIndex++;
                }
            }
        }

        public BLOCK_TYPE getType(int indexX, int indexY)
        {
            return Map[indexX, indexY].BlockType;
        }
        public bool isEmpty(int indexX, int indexY)
        {
            return Map[indexX, indexY].IsEmpty;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j].Draw(spriteBatch, textures, new Vector2(i,j));
                }
            }
        }
    }
}
