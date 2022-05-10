using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class WaxQuail : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("WaxQuail", "Enable Changes"), true, new ConfigDescription("Enables changes to Wax Quail.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.EntityStates.GenericCharacterMain.ProcessJump += (il) =>
			{
				ILCursor ilcursor = new(il);
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
