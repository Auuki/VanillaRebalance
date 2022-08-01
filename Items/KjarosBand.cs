using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	public class KjarosBand : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("KjarosBand", "Enable Changes"), true, new ConfigDescription("Enables changes to Kjaro's Band.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnHitEnemy += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(3f),
					x => x.MatchLdloc(81)))
				{
					ilcursor.Next.Operand = 2.5f;
				}
			};

			string desc = string.Format("Hits that deal <style=cIsDamage>more than 400% damage</style> also blast enemies with a <style=cIsDamage>runic flame tornado</style>, dealing <style=cIsDamage>250%</style> <style=cStack>(+250% per stack)</style> TOTAL damage over time. Recharges every <style=cIsUtility>10</style> seconds.");
			LanguageAPI.Add("ITEM_FIRERING_DESC", desc);
		}
	}
}
