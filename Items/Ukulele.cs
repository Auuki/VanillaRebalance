using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class Ukulele : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Ukulele", "Enable Changes"), true, new ConfigDescription("Enables changes to Ukulele.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(25f),
					x => x.MatchStloc(50)
					);
				ilcursor.Next.Operand = 20f;
			};

			string desc = string.Format("<style=cIsDamage>20%</style> chance to fire <style=cIsDamage>chain lightning</style> for <style=cIsDamage>80%</style> TOTAL damage on up to <style=cIsDamage>3</style> <style=cStack>(+2 per stack)</style> targets within <style=cIsDamage>20m</style> <style=cStack>(+2m per stack)</style>.");
			LanguageAPI.Add("ITEM_CHAINLIGHTNING_DESC", desc);
		}
	}
}
