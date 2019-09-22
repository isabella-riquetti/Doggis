using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doggis.Data.Enum
{
    public class Pet
    {
        public enum Specie
        {
            Dog = 0,
            Cat = 1,
            Bird = 2,
            Bunny = 3,
            Snake = 4
        }

        public enum Size
        {
            Small = 0,
            Medium = 1,
            Large = 2
        }
    }
}
