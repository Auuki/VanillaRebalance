using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class Razorwire : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Razorwire", "Enable Changes"), true, new ConfigDescription("Enables changes to Razorwire.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.HealthComponent.TakeDamage += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(25f)))
				{
					ilcursor.Next.Operand = 20f;
				}

				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(10f)))
				{
					ilcursor.Next.Operand = 2f;
				}
			};

			string desc = string.Format("Getting hit causes you to explode in a burst of razors, dealing <style=cIsDamage>160%</style> damage. Hits up to <style=cIsDamage>5</style> <style=cStack>(+2 per stack)</style> targets in a <style=cIsDamage>20m</style> <style=cStack>(+2m per stack)</style> radius.");
			LanguageAPI.Add("ITEM_THORNS_DESC", desc);
		}
	}
}
