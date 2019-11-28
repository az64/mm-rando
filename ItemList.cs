using MMRando.GameObjects;
using MMRando.Models;
using System.Collections.Generic;
using System.Linq;

namespace MMRando
{
    public class ItemList : List<ItemObject>
    {
        public ItemObject this[Item key]
        {
            get
            {
                return this[(int)key];
            }
            set
            {
                this[(int)key] = value;
            }
        }

        public ItemObject this[string key]
        {
            get
            {
                return this.FirstOrDefault(io => io.Name == key);
            }
        }
    }

}