using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    [Serializable]
    internal class InvalidArmorTypeException : Exception
    {
        public InvalidArmorTypeException(HeroClass HeroType, ArmorType ArmorType)
            : base(InvalidArmorTypeMessage(HeroType, ArmorType)) { }

        private static string InvalidArmorTypeMessage(HeroClass HeroClass, ArmorType ArmorType)
        {
            return $"Hero of class {HeroClass} can not equip armor of type: {ArmorType}";
        }
    }
}
