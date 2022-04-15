﻿using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class HarvestersScythe
    {
        public static void Changes()
        {
            IL.RoR2.GlobalEventManager.OnCrit += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(4f),
                    x => x.MatchLdloc(4)
                    );
                ilcursor.Next.Operand = 0f;
            };

            string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical strikes</style> <style=cIsHealing>heal</style> for <style=cIsHealing>4</style> <style=cStack>(+4 per stack)</style> <style=cIsHealing>health</style>.");
            LanguageAPI.Add("ITEM_HEALONCRIT_DESC", desc);
        }
    }
}