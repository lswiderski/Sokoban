using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace SokobanPC
{
   public class LevelData
    {
       public String Level { get; set; }
       public string SolvePath { get; set; }

       public LevelData(string level, string solvePath)
       {
           Level = level;
           SolvePath = solvePath;
       }
       public LevelData(string level)
       {
           Level = level;
           SolvePath = "";
       }
    }
}
