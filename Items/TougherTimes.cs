using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    internal class TougherTimes
    {
        public static void Changes()
        {
            IL.RoR2.HealthComponent.TakeDamage += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(15f),
                    x => x.MatchLdarg(0)
                    );
                ilcursor.Next.Operand = 11f;
            };

            string desc = string.Format("<style=cIsHealing>10%</style> <style=cStack>(+10% per stack)</style> chance to <style=cIsHealing>block</style> incoming damage. <style=cIsUtility>Unaffected by luck</style>.");
            LanguageAPI.Add("ITEM_BEAR_DESC", desc);
        }
    }
}
