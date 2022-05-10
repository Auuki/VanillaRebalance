using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class BrilliantBehemoth : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("BrilliantBehemoth", "Enable Changes"), true, new ConfigDescription("Enables changes to Brilliant Behemoth.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitAll += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(1.5f)
					);
				ilcursor.Next.Operand = 2f;
				ilcursor.Index++;
				ilcursor.Next.Operand = 2f;
			};

			string desc = string.Format("All your <style=cIsDamage>attacks explode</style> in a <style=cIsDamage>4m</style> <style=cStack>(+2m per stack)</style> radius for a bonus <style=cIsDamage>60%</style> TOTAL damage to nearby enemies.");
			LanguageAPI.Add("ITEM_BEHEMOTH_DESC", desc);
		}
	}
}
