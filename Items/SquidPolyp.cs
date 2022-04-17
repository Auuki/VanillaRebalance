using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
	internal class SquidPolyp
	{
		public static void Changes()
		{
			IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdloc(11),
					x => x.MatchDup()
					);
				ilcursor.Next.Operand = 300;
			};

			string desc = string.Format("Teleporters charge <style=cIsUtility>25%</style> <style=cStack>(+25% per stack)</style> <style=cIsUtility>faster</style>, but the size of the Teleporter zone is <style=cIsHealth>50%</style> <style=cStack>(-50% per stack)</style> smaller.");
			LanguageAPI.Add("ITEM_SQUID_DESC", desc);
		}
	}
}
