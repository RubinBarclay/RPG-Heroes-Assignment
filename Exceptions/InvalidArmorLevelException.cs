using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    [Serializable]
    internal class InvalidArmorLevelException : Exception
    {
        public InvalidArmorLevelException() : base(InvalidArmorLevelMessage()) { }

        private static string InvalidArmorLevelMessage()
        {
            return $"Hero does not meet the level requirement for this armor.";
        }
    }
}
