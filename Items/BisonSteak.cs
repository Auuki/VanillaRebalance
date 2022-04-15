using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class BisonSteak
    {
        public static void Changes()
        {
            IL.RoR2.CharacterBody.RecalculateStats += (il) =>
            //public static void IL_RecalculateStats(ILContext il)
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    //x => ILPatternMatchingExt.MatchLdsfld(x, "RoR2.RoR2Content/Items", "FlatHealth"),
                    //x => ILPatternMatchingExt.MatchLdloc(x, 36),
                    x => x.MatchLdcR4(25f)
                    );
                ilcursor.Next.Operand = 30f;
            };

            string pickup = string.Format("Gain <style=cIsHealing>30</style> max health.");
            string desc = string.Format("Increases <style=cIsHealing>maximum health</style> by <style=cIsHealing>30</style> <style=cStack>(+30 per stack)</style>.");
            LanguageAPI.Add("ITEM_FLATHEALTH_PICKUP", pickup);
            LanguageAPI.Add("ITEM_FLATHEALTH_DESC", desc);
        }
    }
}
