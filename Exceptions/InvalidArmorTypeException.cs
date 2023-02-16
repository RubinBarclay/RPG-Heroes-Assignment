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
        public InvalidArmorTypeException(HeroType HeroType, ArmorType ArmorType)
            : base(InvalidArmorTypeMessage(HeroType, ArmorType)) { }

        private static string InvalidArmorTypeMessage(HeroType HeroType, ArmorType ArmorType)
        {
            return $"Hero of type {HeroType} can not equip weapon of type: {ArmorType}";
        }
    }
}
