using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class KjarosBand
    {
        public static void Changes()
        {
            IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(3f),
                    x => x.MatchLdloc(81)
                    );
                ilcursor.Next.Operand = 2f;
            };

            string desc = string.Format("Hits that deal <style=cIsDamage>more than 400% damage</style> also blast enemies with a <style=cIsDamage>runic flame tornado</style>, dealing <style=cIsHealing>200%</style> <style=cStack>(+200% per stack)</style> TOTAL damage over time. Recharges every <style=cIsUtility>10</style> seconds.");
            LanguageAPI.Add("ITEM_FIRERING_DESC", desc);
        }
    }
}
