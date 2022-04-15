using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    internal class PredatoryInstincts
    {
        public static void Changes()
        {
            IL.RoR2.CharacterBody.RecalculateStats += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(0.12f)
                    );
                ilcursor.Next.Operand = 0.1f;
            };

            string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical strikes</style> increase <style=cIsDamage>attack speed</style> by <style=cIsDamage>10%</style>. Maximum cap of <style=cIsDamage>30%</style> <style=cStack>(+20% per stack)</style>.");
            LanguageAPI.Add("ITEM_ATTACKSPEEDONCRIT_DESC", desc);
        }
    }
}
