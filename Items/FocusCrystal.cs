using MonoMod.Cil;
using R2API;
using System;
using System.Collections.Generic;
using System.Text;

namespace VanillaRebalance.Items
{
    internal class FocusCrystal
    {
        public static void Changes()
        {
            IL.RoR2.HealthComponent.TakeDamage += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(169f)
                    );
                ilcursor.Next.Operand = 144f;
            };

            string desc = string.Format("Increase damage to enemies within <style=cIsDamage>12m</style> by <style=cIsDamage>20%</style> <style=cStack>(+20% per stack)</style>.");
            LanguageAPI.Add("ITEM_NEARBYDAMAGEBONUS_DESC", desc);
        }
    }
}
