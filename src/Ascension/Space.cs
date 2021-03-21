using System;

namespace Ascension{
    class Space{
        public Monster Monster{ get; set; }
        public bool isOccupied{ get; set; }
        public bool isExplored{ get; set; }

        public Space()
        {
            isOccupied = false;
            isExplored = false;
        }

        public Space(Monster monster)
        {
            if(monster != null)
            {
                Monster = monster;
                isOccupied = true;
            }
        }

        public string ExploreStr()
        {
            string output = isExplored ? "Explored" : "Unexplored";
            return output;
        }
    }
}