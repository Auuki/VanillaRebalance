using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class RunaldsBand
    {
        public static void Changes()
        {
            IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(2.5f),
                    x => x.MatchLdloc(80)
                    );
                ilcursor.Next.Operand = 2f;
            };

            string desc = string.Format("Hits that deal <style=cIsDamage>more than 400% damage</style> also blast enemies with a <style=cIsDamage>runic ice blast</style>, <style=cIsUtility>slowing</style> them by <style=cIsUtility>80%</style> for <style=cIsUtility>3s</style> <style=cStack>(+3s per stack)</style> and dealing <style=cIsDamage>200%</style> <style=cStack>(+200% per stack)</style> TOTAL damage. Recharges every <style=cIsUtility>10</style> seconds.");
            LanguageAPI.Add("ITEM_ICERING_DESC", desc);
        }
    }
}
