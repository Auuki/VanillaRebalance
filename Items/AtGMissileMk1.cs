using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
	public class AtGMissileMk1
	{
		public static void Changes()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(3f),
					x => x.MatchLdloc(32)
					);
				ilcursor.Next.Operand = 2f;
			};

			string desc = string.Format("<style=cIsDamage>10%</style> chance to fire a missile that deals <style=cIsDamage>200%</style> <style=cStack>(+200% per stack)</style> TOTAL damage.");
			LanguageAPI.Add("ITEM_MISSILE_DESC", desc);
		}
	}
}
