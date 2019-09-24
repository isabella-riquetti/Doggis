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
        public enum Specie
        {
            [Description("Cachorro")]
            Dog = 0,
            [Description("Gato")]
            Cat = 1,
            [Description("Pássaro")]
            Bird = 2,
            [Description("Coelho")]
            Bunny = 3,
            [Description("Cobra")]
            Snake = 4
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
