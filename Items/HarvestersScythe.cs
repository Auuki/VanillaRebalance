using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	public class HarvestersScythe : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("HarvestersScythe", "Enable Changes"), true, new ConfigDescription("Enables changes to Harvester's Scythe.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnCrit += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(4f),
					x => x.MatchLdloc(4)))
				{
					ilcursor.Next.Operand = 0f;
				}
			};

			string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical strikes</style> <style=cIsHealing>heal</style> for <style=cIsHealing>4</style> <style=cStack>(+4 per stack)</style> <style=cIsHealing>health</style>.");
			LanguageAPI.Add("ITEM_HEALONCRIT_DESC", desc);
		}
	}
}
