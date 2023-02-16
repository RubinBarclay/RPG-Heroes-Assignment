using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    [Serializable]
    internal class InvalidWeaponLevelException : Exception
    {
        public InvalidWeaponLevelException() : base(InvalidWeaponLevelMessage()) { }

        private static string InvalidWeaponLevelMessage()
        {
            return $"Hero does not meet the level requirement for this weapon.";
        }
    }
}
