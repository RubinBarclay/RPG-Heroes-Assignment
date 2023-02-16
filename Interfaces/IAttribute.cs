using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Interfaces
{
    internal interface IAttribute
    {
        int Strength { get; }
        int Dexterity { get; }
        int Intelligence { get; }
    }
}
