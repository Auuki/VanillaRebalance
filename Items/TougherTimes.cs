using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class TougherTimes : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("TougherTimes", "Enable Changes"), true, new ConfigDescription("Enables changes to Tougher Times.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.HealthComponent.TakeDamage += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(15f),
					x => x.MatchLdarg(0)))
				{
					ilcursor.Next.Operand = 11f;
				}
			};

			string desc = string.Format("<style=cIsHealing>10%</style> <style=cStack>(+10% per stack)</style> chance to <style=cIsHealing>block</style> incoming damage. <style=cIsUtility>Unaffected by luck</style>.");
			LanguageAPI.Add("ITEM_BEAR_DESC", desc);
		}
	}
}
