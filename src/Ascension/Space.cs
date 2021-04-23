using System;

namespace Ascension
{
    class Space
    {
        public Enemy Enemy{ get; set; }
        public bool isOccupied{ get; set; }
        public bool isExplored{ get; set; }

        public Space()
        {
            isOccupied = false;
            isExplored = false;
        }

        public Space(Enemy enemy)
        {
            if(enemy != null)
            {
                Enemy = enemy;
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