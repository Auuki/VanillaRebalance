using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    internal class BrilliantBehemoth
    {
        public static void Changes()
        {
            IL.RoR2.GlobalEventManager.OnHitAll += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(1.5f)
                    );
                ilcursor.Next.Operand = 2f;
                ilcursor.Index++;
                ilcursor.Next.Operand = 2f;
            };

            string desc = string.Format("All your <style=cIsDamage>attacks explode</style> in a <style=cIsDamage>4m</style> <style=cStack>(+2m per stack)</style> radius for a bonus <style=cIsDamage>60%</style> TOTAL damage to nearby enemies.");
            LanguageAPI.Add("ITEM_BEHEMOTH_DESC", desc);
        }
    }
}
