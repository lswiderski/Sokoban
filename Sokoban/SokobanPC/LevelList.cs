using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SokobanPC
{
    public class LevelList
    {
        private List<LevelData> levels;


        public LevelList()
        {
            levels = new List<LevelData>();

            AddLevel0();        
            AddPredefinedLevels();
        }

        private void AddPredefinedLevels()
        {
            levels.Add(new LevelData(@"  ####
### @#
#    #
# .#.###
# $    #
##*#*# #
# $    #
#   ####
#####", @"dlldldRuurrddrrddllldlluRRRllUUluurrrddrrddLLLdlUr
rrruullDurrddlLLdlluRRRuuuulllddrRlluurrrdDllUdrrr
rddLLLdlluRRRllUUrrrrddLLLrrruullllluuRRurDlllddrr
rrrddllldlU"));
        }

        private void AddLevel0()
        {
            levels.Add(new LevelData(@"#####
#@  #
# $.#
# $.#
#####", @"drldr"));
        }
        public void AddLevel(LevelData levelData)
        {
            AddLevel(levelData.Level,levelData.SolvePath);
        }
        public void AddLevel(string level, string solvePath = "")
        {
            levels.Add(new LevelData(level, solvePath));
        }

        public LevelData GetLEvel(int index)
        {
            if (index < levels.Count)
            {
                return levels.ElementAt(index);
            }
            else
            {
                return levels.ElementAtOrDefault(0);
            }
        }
    }
}
