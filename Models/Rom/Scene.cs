using System.Collections.Generic;

namespace MMRandomizer.Models.Rom
{
    public class Scene
    {
        public int File;
        public int Number;
        public List<Map> Maps = new List<Map>();
    }
}
