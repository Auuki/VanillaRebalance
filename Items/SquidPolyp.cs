using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class SquidPolyp : RebalanceComponent
	{
		/*protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("SquidPolyp", "Enable Changes"), true, new ConfigDescription("Enables changes to Squid Polyp.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnInteractionBegin += (il) =>
			{
				ILCursor ilcursor = new ILCursor(il);
				ilcursor.GotoNext(
					x => x.MatchLdloc(12),
					x => x.MatchDup()
					);
				ilcursor.Next.Operand = 300;
			};

			string desc = string.Format("Teleporters charge <style=cIsUtility>25%</style> <style=cStack>(+25% per stack)</style> <style=cIsUtility>faster</style>, but the size of the Teleporter zone is <style=cIsHealth>50%</style> <style=cStack>(-50% per stack)</style> smaller.");
			LanguageAPI.Add("ITEM_SQUID_DESC", desc);
		}*/
	}
}
