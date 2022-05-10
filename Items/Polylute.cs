using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class Polylute : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Polylute", "Enable Changes"), true, new ConfigDescription("Enables changes to Polylute.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				ilcursor.GotoNext(
					x => x.MatchLdcR4(25f),
					x => x.MatchStloc(56)
					);
				ilcursor.Next.Operand = 20f;
			};

			string desc = string.Format("<style=cIsDamage>20%</style> chance to fire <style=cIsDamage>lightning</style> for <style=cIsDamage>60%</style> TOTAL damage up to <style=cIsDamage>3</style> <style=cStack>(+3 per stack)</style> times. <style=cIsVoid>Corrupts all Ukuleles</style>.");
			LanguageAPI.Add("ITEM_CHAINLIGHTNINGVOID_DESC", desc);
		}
	}
}
