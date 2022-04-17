using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;

namespace VanillaRebalance.Items
{
	internal class WaxQuail
	{
		public static void Changes()
		{
			IL.EntityStates.GenericCharacterMain.ProcessJump += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(10f)
					);
				ilcursor.Next.Operand = 7f;
				ilcursor.Index += 4;
				ilcursor.Emit(OpCodes.Ldc_R4, 7f);
				ilcursor.Emit(OpCodes.Add);
			};

			string desc = string.Format("<style=cIsUtility>Jumping</style> while <style=cIsUtility>sprinting</style> boosts you forward by <style=cIsUtility>14m</style> <style=cStack>(+7m per stack)</style>.");
			LanguageAPI.Add("ITEM_JUMPBOOST_DESC", desc);
		}
	}
}
