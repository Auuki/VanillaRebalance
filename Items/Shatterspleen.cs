using BepInEx.Configuration;
using MonoMod.Cil;
using R2API;
using System;

namespace VanillaRebalance.Items
{
	internal class Shatterspleen : RebalanceComponent
	{
		protected override ConfigEntry<bool> GetConfigToggle(ConfigFile configFile)
		{
			return configFile.Bind<bool>(new ConfigDefinition("Shatterspleen", "Enable Changes"), true, new ConfigDescription("Enables changes to Shatterspleen.", null, Array.Empty<object>()));
		}

		public override void Load()
		{
			IL.RoR2.GlobalEventManager.OnCharacterDeath += (il) =>
			{
				ILCursor ilcursor = new(il);
				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(0.15f)))
				{
					ilcursor.Next.Operand = 0f;
				}

				if (ilcursor.TryGotoNext(MoveType.Before,
					x => x.MatchLdcR4(16f)))
				{
					ilcursor.Next.Operand = 12f;
				}
			};

			string desc = string.Format("Gain <style=cIsDamage>5% critical chance</style>. <style=cIsDamage>Critical Strikes bleed</style> enemies for <style=cIsDamage>240%</style> base damage. <style=cIsDamage>Bleeding</style> enemies <style=cIsDamage>explode</style> on death for <style=cIsDamage>400%</style> <style=cStack>(+400% per stack)</style> damage.");
			LanguageAPI.Add("ITEM_BLEEDONHITANDEXPLODE_DESC", desc);
		}
	}
}
