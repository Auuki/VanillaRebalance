using R2API;

namespace VanillaRebalance.Items
{
    public class BundleOfFireworks
    {
        public static void Changes()
        {
            /*IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    //x => ILPatternMatchingExt.MatchLdsfld(x, "RoR2.RoR2Content/Items", "FlatHealth"),
                    //x => ILPatternMatchingExt.MatchLdloc(x, 36),
                    x => x.MatchLdloc(4),
                    x => x.MatchLdloc()
                    );
                ilcursor.Next.Operand = 30f;
            };*/

            string desc = string.Format("Increases <style=cIsHealing>maximum health</style> by <style=cIsHealing>30</style> <style=cStack>(+30 per stack)</style>.");
            LanguageAPI.Add("ITEM_FIREWORKS_DESC", desc);
        }
    }
}
