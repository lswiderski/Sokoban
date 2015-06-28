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
        }

        public void newEmptyLevel(int sizeX, int sizeY)
        {
            Map = new Block[sizeX, sizeY];
        }
        public void parseLevel(string _txt)
        {
            int numLines = _txt.Split('\n').Length;
            string line = null;

            StringReader strReader = new StringReader(_txt);
            line = strReader.ReadLine();
            int charsInRow = line.Length;
            Map = new Block[numLines, charsInRow];
            //to be continue
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
