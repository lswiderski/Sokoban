using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public Level()
        {
            newEmptyLevel(1, 1);
            parseLevel(exampleLevel);
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
                    Console.WriteLine(line);
                    for (int i = 0; i < line.Length; i++)
                    {
                        switch (line[i])
                        {
                            case '#': Map[rowIndex, i] = new Block(BLOCK_TYPE.Wall);
                                break;
                            case '@': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor);
                                //Player
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
                            case ' ': Map[rowIndex, i] = new Block(BLOCK_TYPE.Floor);
                                break;
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
    }
}
