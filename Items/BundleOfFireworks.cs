using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
    public class BundleOfFireworks
    {
        public static void Changes()
        {
            IL.RoR2.FireworkLauncher.FireMissile += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => ILPatternMatchingExt.MatchLdfld(x, "RoR2.FireworkLauncher", "damageCoefficient")
                    );
                ilcursor.Index++;
                ilcursor.Emit(OpCodes.Ldc_R4, 1f);
                ilcursor.Emit(OpCodes.Add);
            };

            IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
            {
                ILCursor ilcursor = new ILCursor(il);
                ilcursor.GotoNext(
                    x => x.MatchStloc(8)
                    );
                ilcursor.Index++;
                ilcursor.Remove();
                ilcursor.Emit(OpCodes.Ldc_I4, 0);
            };

            string desc = string.Format("Activating an interactable <style=cIsDamage>launches 4</style> <style=cStack>(+4 per stack)</style> <style=cIsDamage>fireworks</style> that deal <style=cIsDamage>400%</style> base damage. ");
            LanguageAPI.Add("ITEM_FIREWORK_DESC", desc);
        }
    }
}
