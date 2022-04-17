using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
	internal class Razorwire
	{
		public static void Changes()
		{
			IL.RoR2.HealthComponent.TakeDamage += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcI4(5),
					x => x.MatchLdcI4(2)
					);
				ilcursor.Next.Operand = 3;

				ilcursor.GotoNext(
					x => x.MatchLdcR4(25f),
					x => x.MatchLdcR4(10f)
					);
				ilcursor.Next.Operand = 20f;
				ilcursor.Index++;
				ilcursor.Next.Operand = 2f;
			};

			string desc = string.Format("Getting hit causes you to explode in a burst of razors, dealing <style=cIsDamage>160%</style> damage. Hits up to <style=cIsDamage>3</style> <style=cStack>(+2 per stack)</style> targets in a <style=cIsDamage>20m</style> <style=cStack>(+2m per stack)</style> radius.");
			LanguageAPI.Add("ITEM_THORNS_DESC", desc);
		}
	}
}
