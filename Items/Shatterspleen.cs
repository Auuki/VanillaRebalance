using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
	internal class Shatterspleen
	{
		public static void Changes()
		{
			IL.RoR2.GlobalEventManager.OnCharacterDeath += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(0.15f)
					);
				ilcursor.Next.Operand = 0f;

				ilcursor.GotoNext(
					x => x.MatchLdcR4(16f)
					);
				ilcursor.Next.Operand = 12f;
			};

			string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical Strikes bleed</style> enemies for <style=cIsDamage>240%</style> base damage. <style=cIsDamage>Bleeding</style> enemies <style=cIsDamage>explode</style> on death for <style=cIsDamage>400%</style> <style=cStack>(+400% per stack)</style> damage.");
			LanguageAPI.Add("ITEM_BLEEDONHITANDEXPLODE_DESC", desc);
		}
	}
}
