using System.Collections.Generic;

namespace MMR.Randomizer.Models.Rom
{
    public class Map
    {
        public int File;
        public int Header;
        public int ActorAddr;
        public int ObjAddr;
        public List<int> Objects = new List<int>();
        public List<Actor> Actors = new List<Actor>();
    }
}
