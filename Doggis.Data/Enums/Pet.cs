using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public class Pet
    {
        [Flags]
        public enum Specie
        {
            [Description("Cachorro")]
            Dog = 1 << 0,
            [Description("Gato")]
            Cat = 1 << 1,
            [Description("Pássaro")]
            Bird = 1 << 2,
            [Description("Coelho")]
            Bunny = 1 << 3,
            [Description("Cobra")]
            Snake = 1 << 4
        }

        public enum Size
        {
            [Description("Padrão")]
            Default = 0,
            [Description("Pequeno")]
            Small = 1,
            [Description("Médio")]
            Medium = 2,
            [Description("Grande")]
            Large = 3
        }
    }
}
