using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    internal class Needletick
    {
        public static void Changes()
        {
            IL.RoR2.DotController.InitDotCatalog += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchLdcR4(4f)
                    );
                ilcursor.Next.Operand = 3f;
            };

            string desc = string.Format("<style=cIsDamage>10%</style> <style=cStack>(+10% per stack)</style> chance to <style=cIsDamage>collapse</style> an enemy for <style=cIsDamage>300%</style> base damage. <style=cIsVoid>Corrupts all Tri-Tip Daggers</style>.");
            LanguageAPI.Add("ITEM_BLEEDONHITVOID_DESC", desc);
        }
    }
}
