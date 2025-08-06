using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony12; // or HarmonyLib, matching your project

namespace CallOfTheWild.NewMechanics
{

    static class AttacksCountMutator
    {
        static readonly string Backing = "<MainAttacks>k__BackingField";
        public static void AddMainAttacks(object attacksCountObj, int delta)
        {
            var t = attacksCountObj.GetType();
            var f = AccessTools.Field(t, Backing);
            if (f == null) return; // or throw
            int current = (int)f.GetValue(attacksCountObj);
            f.SetValue(attacksCountObj, current + delta);
        }
    }

}
