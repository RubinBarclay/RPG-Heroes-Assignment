using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Exceptions
{
    [Serializable]
    internal class InvalidWeaponTypeException : Exception
    {
        public InvalidWeaponTypeException(HeroType HeroType, WeaponType WeaponType)
            : base(InvalidWeaponTypeMessage(HeroType, WeaponType)) { }

        private static string InvalidWeaponTypeMessage(HeroType HeroType, WeaponType WeaponType)
        {
            return $"Hero of type {HeroType} can not equip weapon of type: {WeaponType}";
        }
    }
}
