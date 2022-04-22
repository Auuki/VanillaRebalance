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
				ilcursor.Emit(OpCodes.Ldc_R4, 0.6f);
				ilcursor.Emit(OpCodes.Add);
			};

			IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchStloc(9)
					);
				ilcursor.Index++;
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 0);
				ilcursor.Index++; //removed instruction doesn't count so we only skip 1
				ilcursor.Remove();
				ilcursor.Emit(OpCodes.Ldc_I4, 5);
			};

			string desc = string.Format("Activating an interactable <style=cIsDamage>launches 5</style> <style=cStack>(+5 per stack)</style> <style=cIsDamage>fireworks</style> that deal <style=cIsDamage>360%</style> base damage.");
			LanguageAPI.Add("ITEM_FIREWORK_DESC", desc);
		}
	}
}
